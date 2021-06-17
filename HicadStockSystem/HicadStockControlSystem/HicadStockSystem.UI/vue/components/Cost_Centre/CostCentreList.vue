<template>
  <!-- WRAPPER -->
  <div>
    <table class="table table-striped table-bordered table-hover">
      <thead>
        <tr>
          <th>Unit Code</th>
          <th>Unit Description</th>
          <th>Unit Division</th>
          <th>Unit Division Description</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(status, index) in statusList" :key="index">
          <td>{{ status.unitCode }}</td>
          <td>{{ status.unitDesc }}</td>
          <td>{{ status.unitDiv }}</td>
          <td>{{ status.unitDivDesc }}</td>
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
        .get("/api/ac_costcenter/")
        .then((response) => (this.statusList = response.data));
    },
  },
};
</script>
