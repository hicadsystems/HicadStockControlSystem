<template>
  <!-- WRAPPER -->
  <div>
    <table class="table table-striped table-bordered table-hover">
      <thead>
        <tr>
          <th>Item Code</th>
          <th>Item Description</th>
          <th>Unit</th>
          <th>Re-order Level</th>
          <th>Re-order Quantity</th>
          <!--<th>Options</th>-->
        </tr>
      </thead>
      <tbody>
        <tr v-for="status  in statusList" :key="status.itemCode">
          <td>{{ status.itemCode }}</td>
          <td>{{ status.itemDesc }}</td>
          <td>{{ status.units }}</td>
          <td>{{ status.reOrderLevel }}</td>
          <td>{{ status.reOrderQty }}</td>
          <!--<td>
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
              @click="processDelete(status.requisitionNo)"
            >
              Delete
            </button>
          </td>-->
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
      responseMessage: '',
    };
  },
  /*created() {
    this.$store.state.objectToUpdate = null;
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      // this.getAllSuppliers();
      this.processDelete();
    },
  },*/
  mounted() {
    this.getAllStockItem();
  },
  methods: {
    /*processRetrieve: function(Status) {
      // alert(Status)
      alert(Status)
      this.$store.state.objectToUpdate = Status;
    },
    processDelete: function(requisitionNo) {
      //alert(companyCode);
      axios
        .delete(`/api/requisition/${requisitionNo}`)
        .then((response) => {
          if (response.data.responseCode == "200") {
            alert("Supplier successfully deleted");
            this.getAllSuppliers();
          }
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },*/

    getAllStockItem: function() {
      axios
        .get('/api/itemmaster/')
        .then((response) => (this.statusList = response.data));
    },
  },
};
</script>
