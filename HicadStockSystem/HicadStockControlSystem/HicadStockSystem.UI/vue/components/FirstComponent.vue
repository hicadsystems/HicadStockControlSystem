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
 
  mounted() {
    this.getCompanyProfile();
  },
  methods: {
   
    getCompanyProfile() {
      axios
        .get("/api/st_stksystem/")
        .then((response) => (this.statusList = response.data));
    },
  },
};
</script>
