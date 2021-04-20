<template>
  <div>
    <div v-if="errors" class="has-error">{{ [errors] }}</div>
    <div v-if="responseMessage" class="has-error">{{ responseMessage }}</div>
    <form @submit="checkForm" method="post">
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-6">
              <input
                class="form-control"
                name="companyCode"
                v-model="postBody.companyCode"
                placeholder="company code"
              />
            </div>
            <div class="col-6">
              <input
                class="form-control"
                name="companyName "
                v-model="postBody.companyName"
                placeholder="company name"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <textarea
                class="form-control"
                name="companyAddress"
                v-model="postBody.companyAddress"
                placeholder="company address"
              >
              </textarea>
            </div>
            <div class="col-6">
              <input
                class="form-control"
                name="companyTelephone "
                v-model="postBody.phone"
                placeholder="telephone number"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <input
                class="form-control"
                name="email"
                v-model="postBody.email"
                placeholder="company email"
              />
            </div>
            <div class="col-6">
              <select class="form-control"
                v-model="postBody.stateName"
                name="stateName"
                placeholder="state"
                required
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
              <input
                class="form-control"
                name="city"
                v-model="postBody.city"
                placeholder="city"
              />
            </div>

            <div class="col-6">
              <datepicker
                name="installDate "
                v-model="postBody.installDate"
                placeholder="Install Date"
              ></datepicker>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <input
                class="form-control"
                name="serialNumber"
                v-model="postBody.serialNumber"
                placeholder="Serial Number"
              />
            </div>
            <div class="col-6">
              <input
                class="form-control"
                name="processYear "
                v-model="postBody.processYear"
                placeholder="Process Year"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <input
                class="form-control"
                name="processMonth"
                v-model="postBody.processMonth"
                placeholder="Process Month"
              />
            </div>
            <div class="col-6">
              <input
                class="form-control"
                name="expenseCode "
                v-model="postBody.expenseCode"
                placeholder="Expense Code"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <input
                class="form-control"
                name="writeoffLoc"
                v-model="postBody.writeoffLoc"
                placeholder="Write off Location"
              />
            </div>
            <div class="col-6">
              <input
                class="form-control"
                name="creditorsCode "
                v-model="postBody.creditorsCode"
                placeholder="Creditors Code"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <input
                class="form-control"
                name="busLine"
                v-model="postBody.businessLine"
                placeholder="Business Line That Fund The Stocks"
              />
            </div>
            <div class="col-3">
              <input
                class="form-control"
                name="holdDays "
                v-model="postBody.holdDays"
                placeholder="Hold Days"
              />
            </div>
            <div class="col-3">
              <input
                class="form-control"
                name="approvedDay "
                v-model="postBody.approvedDay"
                placeholder="Approved Day"
              />
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
import Datepicker from 'vuejs-datepicker';
export default {
     components: {
    Datepicker
  },
  data() {
    return {
      errors: null,
      responseMessage: "",
      submitorUpdate: "Submit",
      canProcess: true,
      stateList:null,
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
        serialNumber: "",
        processYear: "",
        processMonth: "",
        expenseCode: "",
        writeoffLoc: "",
        creditorsCode: "",
        businessLine: "",
        holdDays: "",
        approvedDay: ""
      },
    };
  },
  mounted(){
    axios.get(`/api/st_stksystem/getstates`)
           .then(response=>{
               this.stateList= response.data
           })
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      (this.postBody.companyCode = this.$store.state.objectToUpdate.companyCode),
        (this.postBody.companyName = this.$store.state.objectToUpdate.companyName),
        (this.postBody.companyAddress = this.$store.state.objectToUpdate.companyAddress),
        (this.postBody.phone = this.$store.state.objectToUpdate.phone);
        (this.postBody.email = this.$store.state.objectToUpdate.email);
        (this.postBody.stateName = this.$store.state.objectToUpdate.stateName);
        (this.postBody.city = this.$store.state.objectToUpdate.city);
        (this.postBody.installDate = this.$store.state.objectToUpdate.installDate);
        (this.postBody.serialNumber = this.$store.state.objectToUpdate.serialNumber);
        (this.postBody.processYear = this.$store.state.objectToUpdate.processYear);
        (this.postBody.processMonth = this.$store.state.objectToUpdate.processMonth);
        (this.postBody.expenseCode = this.$store.state.objectToUpdate.expenseCode);
        (this.postBody.writeoffLoc = this.$store.state.objectToUpdate.writeoffLoc);
        (this.postBody.creditorsCode = this.$store.state.objectToUpdate.creditorsCode);
        (this.postBody.businessLine = this.$store.state.objectToUpdate.businessLine);
        (this.postBody.holdDays = this.$store.state.objectToUpdate.holdDays);
        (this.postBody.approvedDay = this.$store.state.objectToUpdate.approvedDay);
      this.submitorUpdate = "Update";
    },
  },
  methods: {
    checkForm: function(e) {
      if (this.postBody.companyCode)
      {
        e.preventDefault();
        this.canProcess = false;
        alert(this.postBody.companyCode,"i am here")
        this.postPost();
      } else {
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
              this.postBody.processYear = "";
              this.postBody.processMonth = "";
              this.postBody.expenseCode = "";
              this.postBody.writeoffLoc = "";
              this.postBody.creditorsCode = "";
              this.postBody.businessLine = "";
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
              this.postBody.processYear = "";
              this.postBody.processMonth = "";
              this.postBody.expenseCode = "";
              this.postBody.writeoffLoc = "";
              this.postBody.creditorsCode = "";
              this.postBody.businessLine = "";
              this.postBody.holdDays = "";
              this.postBody.approvedDay = "";
              this.$store.state.objectToUpdate = "update";
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      }
    }
  },
  computed: {
    setter() {
      let objecttoedit = this.$store.state.objectToUpdate;
      if (objecttoedit.companyCode) {
        this.postBody.companyCode = objecttoedit.companyCode;
        this.postBody.companyName = objecttoedit.companyName;
        this.postBody.companyAddress = objecttoedit.companyAddress;
        this.postBody.companyType = objecttoedit.phone;
        this.postBody.companyType = objecttoedit.email;
        this.postBody.companyType = objecttoedit.stateName;
        this.postBody.companyType = objecttoedit.city;
        this.postBody.companyType = objecttoedit.installDate;
        this.postBody.companyType = objecttoedit.processYear;
        this.postBody.companyType = objecttoedit.processMonth;
        this.postBody.companyType = objecttoedit.expenseCode;
        this.postBody.companyType = objecttoedit.businessLine;
        this.postBody.companyType = objecttoedit.holdDays;
        this.postBody.companyType = objecttoedit.approvedDay;
      }
    }
  },
};
</script>
