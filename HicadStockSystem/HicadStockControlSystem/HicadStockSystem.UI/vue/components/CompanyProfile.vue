<template>
  <div>
    <form @submit.prevent="checkForm" method="post">
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
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !companyCodeIsValid && codeblur,
                }"
                v-on:blur="codeblur = true"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >company code is required not more than 10 characters.</span
                >
              </div>
            </div>
            <div class="col-6 offset-3">
              <label class="mb-1" for="companyName">Company Name</label>
              <br />
              <input
                class="form-control"
                name="companyName "
                v-model="postBody.companyName"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !companyNameIsValid && nameblur,
                }"
                v-on:blur="nameblur = true"
                maxLength="50"
              />
              <div class="invalid-feedback text-danger h5">
                <span class="text-danger h5"
                  >company name is required not more than 50 characters.</span
                >
              </div>
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
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !companyAddressIsValid && addressblur,
                }"
                v-on:blur="addressblur = true"
                rows="5"
                required
              >
              </textarea>
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Please enter company address not more than 60
                  characters.</span
                >
              </div>
            </div>
            <div class="col-6">
              <label class="mb-1" for="companyTelephone"
                >Telephone Number</label
              >
              <input
                class="form-control"
                name="companyTelephone "
                v-model="postBody.phone"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label class="mb-1" for="email">Company Email</label>
              <input
                class="form-control"
                id="email"
                v-model="postBody.email"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !EmailIsValid,
                }"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5">invalid Email</span>
              </div>
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
                type="number"
                class="form-control"
                id="processYear"
                v-model="postBody.processYear"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !processYearIsValid,
                }"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5">invalid Year</span>
              </div>
            </div>

            <div class="col-6">
              <label class="mb-1" for="processMonth">Process Month</label>
              <input
                type="number"
                class="form-control"
                id="processMonth"
                v-model="postBody.processMonth"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !processMonthIsValid,
                }"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5">invalid Month</span>
              </div>
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
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !holdDaysIsValid,
                }"
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
                name="approvedDay"
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
import VueSimpleAlert from "vue-simple-alert";
export default {
  components: {
    Datepicker,
    VueSimpleAlert
  },

  data() {
    return {
      numLength: 4,
      minYear: 1900,
      maxMonth: 12,
      minMonth: 1,
      minDay: 1,
      maxDay: 7,
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
      isGLCode: false,
      isExpenseCode: false,
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
        processYear: 0,
        processMonth: "",
        expenseCode: "",
        writeoffLoc: "",
        creditorsCode: "",
        busLine: "",
        holdDays: "",
        approvedDay: "",
      },
      valid: false,
      codeblur: false,
      nameblur: false,
      addressblur: false,
      
    };
  },

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
      this.validate();
      if (this.valid) {
        e.preventDefault();
        this.canProcess = false;
        this.postPost();
        this.$alert("Submit Form", "Ok", "info");
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
        this.errors = [];
        this.errors.push("Supply all the required field");
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
    isNumeric: function(n) {
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

    //validation functions
    validate() {
      this.codeblur = true;
      this.nameblur = true;
      this.addressblur = true;
      if (
        this.companyCodeIsValid &&
        this.companyNameIsValid &&
        this.companyAddressIsValid &&
        this.processYearIsValid &&
        this.processMonthIsValid &&
        this.holdDaysIsValid && 
        this.PhoneNoIsvalid && 
        this.validEmail
      ) {
        this.valid = true;
      } else {
        this.valid = false;
        return;
      }
    },

  },
  computed: {
    companyCodeIsValid() {
      return (
        this.postBody.companyCode != "" &&
        this.postBody.companyCode.length >= 1 &&
        this.postBody.companyCode.length <= 10
      );
    },
    companyNameIsValid() {
      return (
        this.postBody.companyName != "" &&
        this.postBody.companyName.length >= 1 &&
        this.postBody.companyName.length <= 50
      );
    },
    companyAddressIsValid() {
      return (
        this.postBody.companyAddress != "" &&
        this.postBody.companyAddress.length >= 1 &&
        this.postBody.companyAddress.length <= 60
      );
    },
    processYearIsValid() {
      return (
        this.postBody.processYear == "" ||
        (this.postBody.processYear.length == this.numLength &&
          parseInt(this.postBody.processYear) >= this.minYear)
      );
    },
    processMonthIsValid() {
      return (
        this.postBody.processMonth == "" ||
        (this.postBody.processMonth.length >= 1 &&
          parseInt(this.postBody.processMonth) >= this.minMonth &&
          parseInt(this.postBody.processMonth) <= this.maxMonth)
      );
    },
    holdDaysIsValid() {
      return (
        this.postBody.holdDays == "" ||
        (this.postBody.holdDays.length >= 1 &&
          this.postBody.holdDays.length <= 2 &&
          parseInt(this.postBody.holdDays) >= this.minDay &&
          parseInt(this.postBody.holdDays) <= this.maxDay)
      );
    },
    approvedDayIsValid() {
      return (
        this.postBody.approvedDay == "" ||
        (this.postBody.approvedDay.length >= 1 &&
          this.postBody.approvedDay.length <= 2 &&
          parseInt(this.postBody.approvedDay) >= this.minDay &&
          parseInt(this.postBody.approvedDay) <= this.maxDay)
      );
    },
    EmailIsValid() {
      var re = /(.+)@(.+){2,}\.(.+){2,}/;
      return (
        this.postBody.email == "" || re.test(this.postBody.email.toLowerCase())
      );
    },
    PhoneNoIsvalid() {
      var phoneno =  /^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
      return (
        this.postBody.phone == "" || 
        (this.postBody.phone.length >= 1 
        && this.postBody.phone.length <= 15 
        && this.postBody.phone.match(phoneno))
      );
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
