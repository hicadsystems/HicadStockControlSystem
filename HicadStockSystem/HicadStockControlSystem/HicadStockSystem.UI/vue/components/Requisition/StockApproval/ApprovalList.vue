<template>
  <!-- WRAPPER -->
  <div>
    <table class="table table-striped table-bordered table-hover">
      <thead>
        <tr>
          <th>Requisition Number</th>
          <th>Item Description</th>
          <th>Requested Quantity</th>
          <th>Approved Qty</th>
          <th>Options</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(status, index) in statusList" :key="index">
          <td>{{ status.requisitionNo }}</td>
          <td>{{ status.description }}</td>
          <td>{{ status.quantity }}</td>
          <td>{{ status.approvedQty }}</td>
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
              @click="processDelete(status.requisitionNo)"
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
      responseMessage: '',
    };
  },
  created() {
    this.$store.state.objectToUpdate = null;
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      // this.getAllSuppliers();
      this.processDelete();
    },
  },
  mounted() {
    this.getAllRequisition();
  },
  methods: {
    processRetrieve: function(Status) {
      // alert(Status)
      alert(Status.itemCode)
      this.$store.state.objectToUpdate = Status;
    },
    processDelete: function(requisitionNo) {
      //alert(companyCode);
      axios
        .delete(`/api/issueapprove/${requisitionNo}`)
        .then((response) => {
          if (response.data.responseCode == "200") {
            alert("Supplier successfully deleted");
            this.getAllSuppliers();
          }
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    
    getAllRequisition: function() {
      axios
        .get('/api/issueapprove/')
        .then((response) => (this.statusList = response.data));
    },
  },
};
</script>
