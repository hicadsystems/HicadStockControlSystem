<template>
  <!-- WRAPPER -->
  <div>
    <div class="card">
      <div class="card-body">
        <div>
          <h1 style="text-align:center" class="text-center display-4">
            {{ postBody.companyName }}
          </h1>
          <h3 style="text-align:center">{{ postBody.companyAddress }}</h3>
          <br />
          <h3 style="text-align:center">REPORTS</h3>
          <h4 style="text-align:center">Requisition Enquiry</h4>
          <br /><br />
          <div class="row">
            <div class="col-md-4">
              <label for="unit" class="mb-1">Enter Requisition No.</label>
              <input class="form-control" v-model="postBody.requisitionNo" name="requisitionNo">
            </div>
            <br><br><br>
            <div role="group">
              <button
                class="btn btn-submit btn-primary"
                v-on:click="generateReport"
                type="submit"
              >
                Print
              </button>
            </div>
          </div>
        </div>
      </div>
      </div>
    </div>
  </div>

  <!-- END WRAPPER -->
</template>
<script>


export default {
  data() {
    return {
      system: null,
      responseMessage: "",
      postBody: {
        requisitionNo: "",
        companyName: "",
        companyAddress: "",
        
      },
    };
  },
  mounted() {
     
      axios.get("/api/st_stksystem/system/").then((response) => {
        this.system = response.data
        this.postBody.companyName = response.data.companyName
        this.postBody.companyAddress = response.data.companyAddress
        // this.postBody.companyName = response.data
      });
    // this.getSystem();
  },
  methods: {
    generateReport(){
       window.open(`/RequisitionEnquiry/PrintEquiryReport/${this.postBody.requisitionNo}/`, "_blank")
    }
  },
};
</script>
