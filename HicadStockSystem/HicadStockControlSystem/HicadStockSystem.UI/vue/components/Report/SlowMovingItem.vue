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
          <h4 style="text-align:center">Slow Moving Items</h4>
          <br /><br />
          <div class="row">
            <div class="col-md-4">
              <label for="unit" class="form-check-label mb-1">Select Date</label>
              <input class="form-control" type="date" v-model="postBody.selectedDate" name="selectedDate">
            </div>
            
            <div class="col-md-4">
             <input
              @click="enterItemCode = true"
              class="form-check-input"
              type="radio"
              name="exampleRadios"
              id="exampleRadios2"
              value="option2"
              />
              <label for="unit" class="mb-1">Enter Item Code</label>
              <input v-if="enterItemCode" class="form-control" type="text" v-model="postBody.itemCode" name="itemCode">
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
      enterItemCode: null,
      responseMessage: "",
      postBody: {
        selectedDate: "",
        itemCode: "",
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
      if(this.postBody.itemCode){
       window.open(`/SlowMovingItems/PrintSingleItemReport/${this.postBody.selectedDate}/${this.postBody.itemCode}/`, "_blank")
      }else{
        window.open(`/SlowMovingItems/PrintReport/${this.postBody.selectedDate}/`, "_blank")
      }
    }

   
  },
};
</script>
