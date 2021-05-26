<template>
  <!-- WRAPPER -->
  <div>
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
export default {
  data() {
    return {
      statusList: null,
      responseMessage: "",
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
      // alert(Status)
      this.$store.state.objectToUpdate = Status;
    },
    processDelete: function(itemCode) {
      //alert(companyCode);
      axios
        .patch(`/api/itemmaster/${itemCode}`)
        .then((response) => {
          if (response.data.responseCode == "200") {
            alert("company successfully deleted");
            this.getAllStockItems();
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
  },
};
</script>
