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
          <h4 style="text-align:center">Buyers Guide</h4>
          <br /><br />
         <!-- <div class="row">
            <div class="col-md-4">
              <label for="unit" class="mb-1">Select Item</label>
              <select
                class="form-control"
                v-model="postBody.itemCode"
                name="requisitionNo"
              >
                <option>
                  --select Requisition No.--
                </option>
                <option
                  v-for="item in itemList"
                  v-bind:value="item.itemCode"
                  v-bind:key="item.itemCode"
                >
                  {{ item.itemDesc }}
                </option>
              </select>
            </div>-->
            <!--<br><br>-->
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
import jsPDF from "jspdf";
import html2canvas from "html2canvas";

export default {
  data() {
    return {
      system: null,
      itemList: null,
      supplierList: null,
      select: true,
      report: false,
      downloadPdf: true,
      responseMessage: "",
      postBody: {
        itemCode: "",
        companyName: "",
        companyAddress: "",


      },
    };
  },
  mounted() {
    this.getStockItems();
    this.getSystem();
  },
  methods: {
    getSystem() {
      axios.get("/api/st_stksystem/system/").then((response) => {
        this.system = response.data;
        this.postBody.companyName = response.data.companyName;
        this.postBody.companyAddress = response.data.companyAddress;
        // this.postBody.companyName = response.data
      });
    },
    getStockItems() {
      axios.get("/api/itemmaster/getitemcodes/").then((response) => {
        this.itemList = response.data;
      });
    },
  
    // generateReport(){
    //    window.open(`/BuyersGuide/GetGuide/${this.postBody.itemCode}/`, "_blank")
    // }

    generateReport(){
       window.open(`/BuyersGuide/PrintBuyerGuide/`, "_blank")
    }

   
  },
};
</script>
