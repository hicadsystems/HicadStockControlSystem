<template>
  <!-- WRAPPER -->
  <div>
    <div>
      <item-profile v-if="isFormVisible" />
    </div>
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item active" aria-current="page">
         <span class="h4">Stock Item List</span> 
        </li>
      </ol>
    </nav>
    <div class="mb-2">
      <button class="btn btn-sm btn-success" @click="!showForm()">
        Add Stock Item
      </button>
    </div>

    <table class="table table-striped table-bordered table-hover">
      <thead>
        <tr>
          <th>Item Code</th>
          <th>Item Description</th>
          <th>store Location</th>
          <th>store Rack</th>
          <th>Options</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(status, index) in statusList" :key="index">
          <td>{{ status.itemCode }}</td>
          <td>{{ status.itemDesc }}</td>
          <td>{{ status.storeLoc }}</td>
          <td>{{ status.storerack }}</td>

          <td>
            <button
              type="button"
              class="btn btn-submit btn-primary"
              @click="processRetrieve(status)"
            >
              Edit
            </button>
            <button
              type="button"
              class="btn btn-submit btn-primary"
              @click="processDelete(status.itemCode)"
            >
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>

  <!-- END WRAPPER -->
</template>
<script>
import ItemProfile from "/vue/components/stockItem/ItemProfile";
export default {
  components: {
    ItemProfile,
  },
  data() {
    return {
      statusList: null,
      responseMessage: "",
      isFormVisible: false,
    };
  },
  created() {
    this.$store.state.objectToUpdate = null;
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      this.getAllStockItems();
      this.processDelete();
      // this.processRetrieve();
    },
  },
  mounted() {
    this.getAllStockItems();
  },
  methods: {
    processRetrieve: function(Status) {
      alert(Status)
      this.$store.state.objectToUpdate = Status;
      this.isFormVisible = true;
    },
    processDelete: function(itemCode) {
      alert(itemCode);
      axios
        .patch(`/api/itemmaster/${itemCode}`)
        .then((response) => {
          if (response.data.responseCode == "200") {
            alert("company successfully deleted");
            // this.getAllStockItems();
          }
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    getAllStockItems: function() {
      axios
        .get("/api/itemmaster/")
        .then((response) => (this.statusList = response.data));
    },
    showForm() {
      this.isFormVisible = true;
    },
  },
};
</script>
