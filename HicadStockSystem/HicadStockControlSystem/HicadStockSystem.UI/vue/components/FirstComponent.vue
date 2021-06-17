<template>
  <!-- WRAPPER -->
  <div>
    <div class="text-center" v-for="system in statusList">
      <h1 class="display-4">{{system.companyName}}</h1>
      <h3>{{system.companyAddress}}</h3>
    </div>
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
    this.getCompanyProfile();
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
    getCompanyProfile() {
      axios
        .get("/api/st_stksystem/")
        .then((response) => (this.statusList = response.data));
    },
  },
};
</script>
