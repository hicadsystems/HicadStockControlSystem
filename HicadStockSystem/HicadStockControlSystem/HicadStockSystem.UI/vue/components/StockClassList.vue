<template>
  <!-- WRAPPER -->
  <div>
    <table class="table table-striped table-bordered table-hover">
      <thead>
        <tr>
          <th>Stock Class</th>
          <th>Options</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(status, index) in statusList" :key="index">
          <td>{{ status.sktClass }}</td>
          <td>
            <button
              type="button"
              class="btn btn-submit btn-danger align-item-end"
              @click="processDelete(status.sktClass)"
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
      this.processDelete();
    },
  },
  mounted() {
    this.getStockClass();
  },
  methods: {
    processRetrieve: function(Status) {
      // alert(Status)
      this.$store.state.objectToUpdate = Status;
    },
    processDelete: function(companyCode) {
      //alert(companyCode);
      axios
        .delete(`/api/stockclass/${companyCode}`)
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
    getStockClass: function() {
      axios
        .get("/api/stockclass/")
        .then((response) => (this.statusList = response.data));
    },
  },
};
</script>
