<template>
  <div>
    <div class="card">
      <div class="card-body">
      <div>
       <h1 style="text-align:center" class="text-center display-4">
            {{ postBody.companyName }}
          </h1>
          <h3 style="text-align:center">{{ postBody.companyAddress }}</h3>
          <br />
          <h3 style="text-align:center">Month End Processing</h3>
          <h4 style="text-align:center">Physical Count Input/Upload</h4>
          <br /><br />
      <input type="file" name="" id="" class="form-control w-50"> <br> <button class="btn btn-primary">Upload File</button>
      <br> <br>
      <button @click="showForm()" class="btn btn-primary">Input Physical Count</button> 
      <p>Click To Manually Input Quantity</p>
      </div>
      <div v-if="isFormVisible">
      
        <div class="p-5" id="vertical-form">
          <div class="preview">
            <div class="row">
              <table class="table table-striped table-bordered table-hover">
                <thead>
                  <tr>
                    <th>Item Code</th>
                    <th>Item Description</th>
                    <th>Input Quantity</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="item in postBody.physicalCountSheet" :key="item.itemcode">
                    <td>
                      <!--<input
                      class="form-control"
                      name="itemCode "
                      readonly="readonly"
                      v-model="item.itemCode"
                    />-->
                      {{ item.itemCode }}
                    </td>
                    <td>
                      <!--<input
                      class="form-control"
                      name="description "
                      readonly="readonly"
                      v-model="item.itemDescription"
                    />-->
                      {{ item.itemDesc }}
                    </td>
                    <td>
                      <input
                      type="number"
                        class="form-control"
                        v-model="item.quantity"
                        name="physicalQty"
                      />
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
            <div role="group">
              <button
                class="btn btn-submit btn-primary float-right"
                v-on:click="checkForm()"
                type="submit"
              >
                Process
              </button>
            </div>
            <br />
          </div>
        </div>
     
      </div>
      </div>
      
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      system: null,
      statusList: null,
      isFormVisible: false,
      responseMessage: "",
      postBody: {
        companyName: "",
        companyAddress: "",
        quantity:"",
        physicalCountSheet: []
        // ItemCode: "",
        // ItemDesc: "",
        // Quantity: "",
        
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
    this.getphysicalcount();
  },
  methods: {
    generateReport(){
       window.open(`/PhysicalCountSheet/PhysicalCount/`, "_blank")
    },
    showForm(){
        this.isFormVisible = true
    },
    getphysicalcount(){
         axios
        .get("/api/stockmaster/physicalcount/")
        .then((response) =>{
            this.postBody.physicalCountSheet = response.data;
            // this.postBody.itemCode = response.data.itemCode;
            // this.postBody.itemDesc = response.data.itemDesc;
        });
    },
        checkForm() {
            // alert("seen")
        axios
          .put(`/api/stockmaster/UpdatePhysicalCount`, this.postBody)
          .then((response) => {
              this.postBody.physicalCountSheet = [];
            // this.responseMessage = response.data.responseDescription;
            // this.canProcess = true;
            // if (response.data.responseCode == "200") {
            // }
            window.location.reload();
          })
        //   .catch((e) => {
        //     this.errors.push(e);
        //   });
        // this.$alert("Submit Form", "Ok", "info");
      
    },
  },
};
</script>