<template>
  <!-- WRAPPER -->
  <div>
    <table class="table table-striped table-bordered table-hover">
      <thead>
        <tr>
          <th>Company Code</th>
          <th>Company name</th>
          <th>Company Address</th>
          <th>Company Email</th>
          <th>Options</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(status, index) in statusList" :key="index">
          <td>{{ status.companyCode }}</td>
          <td>{{ status.companyName }}</td>
          <td>{{ status.companyAddress }}</td>
          <td>{{ status.email }}</td>

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
              @click="processDelete(status.companyCode)"
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
      this.getAllCompany();
      this.processDelete();
      // this.processRetrieve();
    },
  },
  mounted() {
    this.getAllCompany();
  },
  methods: {
    processRetrieve: function(Status) {
      // alert(Status)
      this.$store.state.objectToUpdate = Status;
    },
    processDelete: function(companyCode) {
      //alert(companyCode);
      axios
        .delete(`/api/st_stksystem/${companyCode}`)
        .then((response) => {
          if (response.data.responseCode == "200") {
            alert("company successfully deleted");
            this.getAllCompany();
          }
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    getAllCompany: function() {
      axios
        .get("/api/st_stksystem/")
        .then((response) => (this.statusList = response.data));
    },
  },
};
</script>
