<template>
  <div>
    <div class="card col-sm-6">
      <div class="p-4 ml-2">
        <div class="form-check">
          <input
            v-model="RequisitionList"
            class="form-check-input"
            type="radio"
            name="exampleRadios"
            id="exampleRadios1"
            value="option1"
            
          />
          <label class="form-check-label" for="exampleRadios1">
            All
          </label>
        </div>
        <div class="form-check">
          <input
            v-model="postBody.requisitionAge"
            @click="selectDate = true"
            class="form-check-input"
            type="radio"
            name="exampleRadios"
            id="exampleRadios2"
            value="option2"
          />
          <label class="form-check-label" for="exampleRadios2">
            Before Specific Date
          </label>
          <input  v-model="postBody.requisitionAge" v-if="selectDate" type="date" class="col-4" />
        </div>
        <div class="form-check">
          <input
            @click="selectRequisition = true"
            class="form-check-input"
            type="radio"
            name="exampleRadios"
            id="exampleRadios2"
            value="option2"
          />
          <label class="form-check-label" for="exampleRadios2">
            Specific Requisition
          </label>
          <div class="col-6" v-if="selectRequisition">
            <select
              class="form-control"
              v-model="postBody.requisitionNo"
              name="requisitionNo"
              :class="{ 'is-invalid': !requisitionNoIsValid && reqblur }"
              v-on:blur="reqblur = true"
            >
              <option>
                --select Requisition No.--
              </option>
              <option
                v-for="requisition in RequisitionList"
                v-bind:value="requisition"
                v-bind:key="requisition"
              >
                {{ requisition }}
              </option>
            </select>
          </div>
        </div>
        <div role="group">
          <button
            class="btn btn-submit btn-primary float-right"
            v-on:click="checkForm"
            type="submit"
          >
            Process
          </button>
        </div>
      </div>
    </div>

    <!-- <div class="card">
      <div class="card-header">
        <h1 class="card-title  text-center"><b>Request Items</b></h1>
      </div>
      <div class="card-body">
        <div class="table-responsive-sm">
          <table class="table table-bordered table-hover">
            <thead>
              <tr>
                <th>Item Code</th>
                <th>Quantity</th>
                <th>unit</th>
                <th>Option</th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="lineItem in postBody.lineItems"
                :key="lineItem.itemCode"
              >
                <td>{{ lineItem.itemCode }}</td>
                <td>{{ lineItem.quantity }}</td>
                <td>{{ lineItem.unit }}</td>
                <td>
                  <button
                    @click="removeItem(lineItem.itemCode)"
                    class="btn btn-danger"
                  >
                    Remove Item
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
          <div v-if="postBody.lineItems.length > 0" role="group">
            <button
              class="btn btn-submit btn-primary float-right"
              v-on:click="checkForm"
              type="submit"
            >
              Process
            </button>
          </div>
        </div>
      </div>
    </div>-->
    <!--Line Items -->
  </div>
</template>
<script>
import Datepicker from "vuejs-datepicker";
import VueSimpleAlert from "vue-simple-alert";
export default {
  components: {
    Datepicker,
    VueSimpleAlert,
  },
  data() {
    return {
      errors: null,
      responseMessage: "",
      submitorUpdate: "Submit",
      canProcess: true,
      selectDate: false,
      selectRequisition: false,
      reqblur: false,
      RequisitionList: null,
      ReqList: null,

      // lineItems: [],
      // locationCode: "",
      currentBal: "",

      postBody: {
        requisitionNo: "",
        RequisitionList: [],
        requisitionAge: "",
      },

      newItem: {
        quantity: 0,
        itemCode: "",
        unit: "",
        // itemDesc:""
      },
    };
  },

  mounted() {
    this.getUnissuedReq();
    // this.getUnissuedReqs();
    // this.getItemCode();
  },
  // watch: {
  //   "$store.state.objectToUpdate": function(newVal, oldVal) {
  //     (this.postBody.locationCode = this.$store.state.objectToUpdate.locationCode),
  //       (this.postBody.itemCode = this.$store.state.objectToUpdate.itemCode),
  //       (this.postBody.itemCode = this.$store.state.objectToUpdate.itemDesc),
  //       (this.postBody.qtyInTransaction = this.$store.state.objectToUpdate.qtyInTransaction),
  //       (this.postBody.quantity = this.$store.state.objectToUpdate.quantity);
  //     this.postBody.unit = this.$store.state.objectToUpdate.unit;
  //     this.submitorUpdate = "Update";
  //   },
  // },
  methods: {
    checkForm() {
      console.log(this.ReqList);
      this.validate();
      if (this.postBody) {
        // e.preventDefault();
        axios
          .patch(`/api/requisition/DeleteUnissuedRequisition`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.requisitionNo = "";
              this.postBody.requisitionAge = "";
              this.RequisitionList = [];
            }
            window.location.reload();
          })
          .catch((e) => {
            this.errors.push(e);
          });
        this.$alert("Submit Form", "Ok", "info");
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
        this.errors = [];
        this.errors.push("Supply all the required field");
      }
    },
    // postPost() {
    //   if (this.submitorUpdate == "Submit") {
    //     axios
    //       .post(`/api/requisition/`, this.postBody)
    //       .then((response) => {
    //         this.responseMessage = response.data.responseDescription;
    //         this.canProcess = true;
    //         if (response.data.responseCode == "200") {
    //           // this.postBody.locationCode = "";
    //           // this.postBody.itemCode = "";
    //           // this.postBody.itemDesc = "";
    //           // this.postBody.quantity = "";
    //           // this.postBody.unit = "";
    //           // this.$store.stateName.objectToUpdate = "create";
    //           location = this.locationCode;
    //           this.lineItems = [];
    //         }
    //         // this.document.getElementById('#requestForm').value = "";
    //         // this.$refs.requestForm.reset();
    //         // window.location.reload();
    //       })
    //       .catch((e) => {
    //         if (e) this.errors.push(e);
    //       });
    //   }
    //   if (this.submitorUpdate == "Update") {
    //     alert("Ready to Update");
    //     axios
    //       .put(`/api/requisition/`, this.postBody)
    //       .then((response) => {
    //         this.responseMessage = response.data.responseDescription;
    //         this.canProcess = true;
    //         if (response.data.responseCode == "200") {
    //           this.submitorUpdate = "Submit";
    //           this.postBody.locationCode = "";
    //           this.postBody.itemCode = "";
    //           this.postBody.itemDesc = "";
    //           this.postBody.quantity = 0;
    //           this.postBody.unit = "";
    //           this.$store.state.objectToUpdate = "update";
    //         }
    //         window.location.reload();
    //       })
    //       .catch((e) => {
    //         this.errors.push(e);
    //       });
    //   }
    // },

    //gets the unit, currentBal of item

    getUnissuedReq() {
      axios.get(`/api/requisition/GetUnissuedRequisitions`).then((response) => {
        this.RequisitionList = response.data;
        // console.log(this.RequisitionList);
        this.postBody.RequisitionList = response.data;
      });
    },

    // getUnissuedReqs() {
    //   axios.get(`/api/requisition/GetUnissuedReq`).then((response) => {
    //     this.ReqList = response.data.result.observer;
    //     console.log(this.ReqList)
    //     // this.postBody.ReqList = response.data;
    //   });
    // },

    validate() {
      this.reqblur = true;
      if (this.requisitionNoIsValid) {
        this.valid = true;
      } else {
        this.valid = false;
        return;
      }
    },
  },

  computed: {
    requisitionNoIsValid() {
      return this.postBody.requisitionNo != "";
    },
  },
};
</script>
