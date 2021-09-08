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
            @click="setAll()"
          />
          <label class="form-check-label" for="exampleRadios1">
            All
          </label>
        </div>
        <div class="form-check">
          <input
            v-model="postBody.requisitionAge"
            @click="setDate()"
            class="form-check-input"
            type="radio"
            name="exampleRadios"
            id="exampleRadios2"
            value="option2"
          />
          <label class="form-check-label" for="exampleRadios2">
            Before Specific Date
          </label>
          <input  v-model="postBody.requisitionAge" v-if="selectDate" type="date" class="form-control col-4" />
        </div>
        <div class="form-check">
          <input
            @click="setRequisition()"
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
      selectAll: false,
      selectRequisition: false,
      reqblur: false,
      RequisitionList: null,
      ReqList: null,
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
      },
    };
  },

  mounted() {
    this.getUnissuedReq();
  },
 
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

    setDate(){
      this.selectDate = true;
      this.selectRequisition = false;
      this.selectAll = false;
      this.postBody.requisitionNo = "";
      this.postBody.RequisitionList = null;
      this.postBody.requisitionAge = this.postBody.requisitionAge;
    },

    setRequisition(){
      this.selectDate = false;
      this.selectAll = false;
      this.selectRequisition = true;
      this.postBody.requisitionAge = null;
      this.postBody.RequisitionList = null;
    },

    setAll(){
      this.selectDate = false;
      this.selectRequisition = false;
      this.selectAll = true;
      this.postBody.requisitionAge = "";
      this.postBody.requisitionNo = "";
      this.postBody.RequisitionList = this.RequisitionList;
    },

       getUnissuedReq() {
      axios.get(`/api/requisition/GetUnissuedRequisitions`).then((response) => {
        this.RequisitionList = response.data;
        // console.log(this.RequisitionList);
        this.postBody.RequisitionList = response.data;
      });
    },
    

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
