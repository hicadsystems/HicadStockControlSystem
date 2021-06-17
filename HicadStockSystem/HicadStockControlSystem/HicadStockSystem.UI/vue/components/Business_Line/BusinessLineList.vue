<template>
  <!-- WRAPPER -->
  <div>
    <table class="table table-striped table-bordered table-hover">
      <thead>
        <tr>
          <th>Business Line</th>
          <th>Business Description</th>
          <th>Status</th>
          <th>Cashier Account</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(status, index) in statusList" :key="index">
          <td>{{ status.businessLine }}</td>
          <td>{{ status.businessDesc }}</td>
          <td>{{ status.status }}</td>
          <td>{{ status.cashier_Ac }}</td>
        <!--  <td>
            <button
              type="button"
              class="btn btn-submit btn-primary"
              @click="processRetrieve(status.supplierCode)"
            >
              Edit
            </button>
            <button
              type="button"
              class="btn btn-submit btn-primary"
              @click="processDelete(status.companyCode)"
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
      responseMessage: "",
    };
  },
//   created() {
//     this.$store.state.objectToUpdate = null;
//   },
//   watch: {
//     "$store.state.objectToUpdate": function(newVal, oldVal) {
//       this.getAllCompany();
//       this.processDelete();
//       // this.processRetrieve();
//     },
//   },
  mounted() {
    this.getCostCentre();
  },
  methods: {
    // processRetrieve: function(Status) {
    //   // alert(Status)
    //   this.$store.state.objectToUpdate = Status;
    // },
    // // processRetrieve: function(Status) {
    // //   // alert(Status)
    // //   this.$store.state.objectToUpdate = Status;
    // // },
    // processDelete: function(companyCode) {
    //   //alert(companyCode);
    //   axios
    //     .delete(`/api/st_stksystem/${companyCode}`)
    //     .then((response) => {
    //       if (response.data.responseCode == "200") {
    //         alert("company successfully deleted");
    //         this.getAllCompany();
    //       }
    //     })
    //     .catch((e) => {
    //       this.errors.push(e);
    //     });
    // },
    getCostCentre() {
      axios
        .get("/api/ac_businessline/")
        .then((response) => (this.statusList = response.data));
    },
  },
};
</script>
