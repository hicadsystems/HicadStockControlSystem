<template>
  <div>
    <form @submit="checkForm" method="post">
      <div id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-3">
              <label class="mb-1" for="companyCode">Company Code</label>
              <br />
              <input
                class="form-control"
                name="companyCode"
                v-model="postBody.companyCode"
                v-bind:class="{'is-invalid': missingCompanyCode}"
              />
              <div class="invalid-feedback">
                Please enter company code not more than 10 characters.
              </div>
            </div>
            <div class="col-6 offset-3">
              <label class="mb-1" for="companyName">Company Name</label>
              <br />
              <input
                class="form-control"
                name="companyName "
                v-model="postBody.companyName"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label class="mb-1" for="companyAddress">Company Address</label>
              <textarea
                class="form-control"
                id="companyAddress"
                v-model="postBody.companyAddress"
                rows="5"
              >
              </textarea>
            </div>
            <div class="col-6">
              <label class="mb-1" for="companyTelephone"
                >Telephone Number</label
              >
              <input
                class="form-control"
                nameid="companyTelephone "
                v-model="postBody.phone"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label class="mb-1" for="email">Company Email</label>
              <input class="form-control" id="email" v-model="postBody.email" />
            </div>
            <div class="col-6">
              <label class="mb-1" for="stateName">State</label>
              <select
                class="form-control"
                id="stateName"
                v-model="postBody.stateName"
              >
                <option
                  v-for="state in stateList"
                  v-bind:value="state.stateName"
                  v-bind:key="state.id"
                >
                  {{ state.stateName }}
                </option>
              </select>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label class="mb-1" for="city">City</label>
              <input class="form-control" id="city" v-model="postBody.city" />
            </div>
            <div class="col-6">
              <label class="mb-1" for="city">Install Date</label>
              <input
                class="form-control"
                type="date"
                id="installDate "
                v-model="postBody.installDate"
              />
            </div>
          </div>

          <br />
          <div class="row">
            <div class="col-6">
              <label class="mb-1" for="city">Serial Number</label>
              <input
                class="form-control"
                id="serialNumber"
                v-model="postBody.serialNumber"
              />
            </div>
            <div class="col-6">
              <label class="mb-1" for="city">GL Code</label>
              <select class="form-control" v-model="postBody.glCode" id="city">
                <option
                  v-for="gLCode in GLCodeList"
                  v-bind:value="gLCode.acctNumber"
                  v-bind:key="gLCode.acctNumber"
                >
                  {{ gLCode.description }}
                </option>
              </select>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label class="mb-1" for="processYear">Process Year</label>
              <input
                class="form-control"
                id="processYear"
                v-model="postBody.processYear"
              />
            </div>

            <div class="col-6">
              <label class="mb-1" for="processMonth">Process Month</label>
              <input
                class="form-control"
                id="processMonth"
                v-model="postBody.processMonth"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label class="mb-1" for="expenseCode">Expense Code</label>
              <select
                class="form-control"
                v-model="postBody.expenseCode"
                id="expenseCode"
              >
                <option
                  v-for="expCode in ExpenseCodeList"
                  v-bind:value="expCode.acctNumber"
                  v-bind:key="expCode.acctNumber"
                >
                  {{ expCode.description }}
                </option>
              </select>
            </div>
            <div class="col-6">
              <label class="mb-1" for="writeOffLoc">Write Off Location</label>
              <select
                class="form-control"
                v-model="postBody.writeoffLoc"
                id="writeOffLoc"
                required
              >
                <option
                  v-for="writeOff in writeoffLocList"
                  v-bind:value="writeOff.unitCode"
                  v-bind:key="writeOff.unitCode"
                >
                  {{ writeOff.unitDesc }}
                </option>
              </select>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label class="mb-1" for="creditorsCode">Creditors Code</label>
              <select
                class="form-control"
                v-model="postBody.creditorsCode"
                id="creditorsCode"
                required
              >
                <option
                  v-for="crCode in CreditorCodeList"
                  v-bind:value="crCode.acctNumber"
                  v-bind:key="crCode.acctNumber"
                >
                  {{ crCode.description }}
                </option>
              </select>
            </div>
            <div class="col-6">
              <label class="mb-1" for="busLine"
                >Business Line That Fund The Stocks</label
              >
              <select
                class="form-control"
                v-model="postBody.busLine"
                id="busLine"
                required
              >
                <option
                  v-for="businessLine in BusinessLineList"
                  v-bind:value="businessLine.businessLine"
                  v-bind:key="businessLine.businessLine"
                >
                  {{ businessLine.businessDesc }}
                </option>
              </select>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-3">
              <label for="busLine">Hold Un-Approved Request For</label>
            </div>
            <div class="col-1">
              <input
                class="form-control"
                name="holdDays "
                v-model="postBody.holdDays"
                placeholder="0"
              />
            </div>
            <div class="col-1 ml-0">
              <label for="busLine">Days</label>
            </div>
            <div class="col-1">
              <label for="busLine">Approved</label>
            </div>
            <div class="col-1">
              <input
                class="form-control"
                name="approvedDay "
                v-model="postBody.approvedDay"
                placeholder="0"
              />
            </div>
            <div class="col-1">
              <label for="busLine">Days</label>
            </div>
          </div>
          <br />
          <div v-if="canProcess" role="group">
            <button
              class="btn btn-submit btn-primary float-right"
              v-on:click="checkForm"
              type="submit"
            >
              {{ submitorUpdate }}
            </button>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>
<script>
import Datepicker from "vuejs-datepicker";
export default {
  components: {
    Datepicker,
  },
  
  data() {
    return {
      errors: null,
      responseMessage: "",
      submitorUpdate: "Submit",
      canProcess: true,
      stateList: null,
      writeoffLocList: null,
      BusinessLineList: null,
      GLCodeList: null,
      CreditorCodeList: null,
      ExpenseCodeList: null,
      isCrCode: false,
      isGLCode:false,
      isExpenseCode:false,
      postBody: {
        companyCode: "",
        companyName: "",
        companyAddress: "",
        phone: "",
        email: "",
        stateName: "",
        city: "",
        // datepicker
        installDate: new Date(),
        glCode: "",
        serialNumber: "",
        processYear: "",
        processMonth: "",
        expenseCode: "",
        writeoffLoc: "",
        creditorsCode: "",
        busLine: "",
        holdDays: "",
        approvedDay: "",
      },
    };
  },
  attemptedSubmit: false,

  mounted() {
    this.getStates();
    this.getWriteOffLoc();
    this.getBusinessLine();
    this.getAccChart();
    // this.getCreditorCode();
    // this.getExpenseCode();
    // this.getGLCode();
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      (this.postBody.companyCode = this.$store.state.objectToUpdate.companyCode),
        (this.postBody.companyName = this.$store.state.objectToUpdate.companyName),
        (this.postBody.companyAddress = this.$store.state.objectToUpdate.companyAddress),
        (this.postBody.phone = this.$store.state.objectToUpdate.phone);
      this.postBody.email = this.$store.state.objectToUpdate.email;
      this.postBody.stateName = this.$store.state.objectToUpdate.stateName;
      this.postBody.city = this.$store.state.objectToUpdate.city;
      this.postBody.installDate = this.$store.state.objectToUpdate.installDate;
      this.postBody.glCode = this.$store.state.objectToUpdate.glCode;
      this.postBody.serialNumber = this.$store.state.objectToUpdate.serialNumber;
      this.postBody.processYear = this.$store.state.objectToUpdate.processYear;
      this.postBody.processMonth = this.$store.state.objectToUpdate.processMonth;
      this.postBody.expenseCode = this.$store.state.objectToUpdate.expenseCode;
      this.postBody.writeoffLoc = this.$store.state.objectToUpdate.writeoffLoc;
      this.postBody.creditorsCode = this.$store.state.objectToUpdate.creditorsCode;
      this.postBody.busLine = this.$store.state.objectToUpdate.busLine;
      this.postBody.holdDays = this.$store.state.objectToUpdate.holdDays;
      this.postBody.approvedDay = this.$store.state.objectToUpdate.approvedDay;
      this.submitorUpdate = "Update";
    },
  },
  methods: {

    checkForm: function(e) {
      if(this.missingCompanyCode && this.missingCompanyName && this.missingCompanyAddress){
           e.preventDefault();
        }
       else {

        if (this.postBody.companyCode && this.postBody.companyName && this.postBody.companyAddress) {
        e.preventDefault();
        this.canProcess = false;
        alert(this.postBody.companyCode, "i am here");
        this.postPost();
      }
        //  e.preventDefault();
        // this.errors = [];
        // this.errors.push("Supply all the required field");
      }
    },
    postPost() {
      if (this.submitorUpdate == "Submit") {
        axios
          .post(`/api/st_stksystem/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.companyCode = "";
              this.postBody.companyName = "";
              this.postBody.companyAddress = "";
              this.postBody.phone = "";
              this.postBody.email = "";
              this.postBody.stateName = "";
              this.postBody.city = "";
              this.postBody.installDate = new Date();
              (this.postBody.glCode = ""), (this.postBody.processYear = "");
              this.postBody.processMonth = "";
              this.postBody.expenseCode = "";
              this.postBody.writeoffLoc = "";
              this.postBody.creditorsCode = "";
              this.postBody.busLine = "";
              this.postBody.holdDays = "";
              this.postBody.approvedDay = "";
              this.$store.stateName.objectToUpdate = "create";
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      }
      if (this.submitorUpdate == "Update") {
        alert("Raedy to Update");
        axios
          .put(`/api/st_stksystem/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.submitorUpdate = "Submit";
              this.postBody.companyCode = "";
              this.postBody.companyName = "";
              this.postBody.companyAddress = "";
              this.postBody.phone = "";
              this.postBody.email = "";
              this.postBody.stateName = "";
              this.postBody.city = "";
              this.postBody.installDate = "";
              this.postBody.glCode = "";
              this.postBody.processYear = "";
              this.postBody.processMonth = "";
              this.postBody.expenseCode = "";
              this.postBody.writeoffLoc = "";
              this.postBody.creditorsCode = "";
              this.postBody.busLine = "";
              this.postBody.holdDays = "";
              this.postBody.approvedDay = "";
              this.$store.state.objectToUpdate = "update";
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      }
    },
    //function for number check
     isNumeric: function (n) {
      return !isNaN(parseFloat(n)) && isFinite(n);
    },

    getStates() {
      axios.get(`/api/st_stksystem/getstates`).then((response) => {
        this.stateList = response.data;
      });
    },

    getWriteOffLoc() {
      axios.get(`/api/st_stksystem/GetWriteOffLoc`).then((response) => {
        this.writeoffLocList = response.data;
      });
    },

    getBusinessLine() {
      axios.get(`/api/st_stksystem/GetBusinessLine`).then((response) => {
        this.BusinessLineList = response.data;
      });
    },

    getAccChart() {
      axios.get(`/api/st_stksystem/GetAccChart`).then((response) => {
        this.GLCodeList = response.data;
        this.CreditorCodeList = response.data;
        this.ExpenseCodeList = response.data;
      });
    },
  },
  computed: {
    missingCompanyCode: function(){
      return this.companyCode === "";
    },

    missingCompanyName: function(){
      return this.companyName === "";
    },

    missingCompanyAddress: function(){
      return this.companyAddress === "";
    },

    setter() {
      let objecttoedit = this.$store.state.objectToUpdate;
      if (objecttoedit.companyCode) {
        this.postBody.companyCode = objecttoedit.companyCode;
        this.postBody.companyName = objecttoedit.companyName;
        this.postBody.companyAddress = objecttoedit.companyAddress;
        this.postBody.phone = objecttoedit.phone;
        this.postBody.email = objecttoedit.email;
        this.postBody.stateName = objecttoedit.stateName;
        this.postBody.city = objecttoedit.city;
        this.postBody.installDate = objecttoedit.installDate;
        this.postBody.glCode = objecttoedit.glCode;
        this.postBody.processYear = objecttoedit.processYear;
        this.postBody.processMonth = objecttoedit.processMonth;
        this.postBody.expenseCode = objecttoedit.expenseCode;
        // this.postBody.businessLine = objecttoedit.busLine;
        this.postBody.holdDays = objecttoedit.holdDays;
        this.postBody.approvedDay = objecttoedit.approvedDay;
      }
    },
  },
};
</script>
