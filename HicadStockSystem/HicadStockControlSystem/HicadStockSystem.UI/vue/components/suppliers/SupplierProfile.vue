<template>
  <div>
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-3">
              <label for="supplierCode" class="mb-1">Supplier Code</label>
              <input
                class="form-control"
                name="supplierCode"
                v-model="postBody.supplierCode"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !supplierCodeIsValid && codeblur,
                }"
                v-on:blur="codeblur = true"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Please enter supplier code not more than 3 characters</span
                >
              </div>
            </div>
            <div class="col-6 offset-3">
              <label for="name" class="mb-1">Supplier Name</label>
              <input
                class="form-control"
                name="name"
                v-model="postBody.name"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !supplierNameIsValid && nameblur,
                }"
                v-on:blur="nameblur = true"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Please enter supplier name not more than 50 characters</span
                >
              </div>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label for="address" class="mb-1">Supplier Address</label>
              <input
                class="form-control"
                name="address"
                v-model="postBody.address"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !supplierAddressIsValid && addressblur,
                }"
                v-on:blur="addressblur = true"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Please enter supplier address not more than 50
                  characters</span
                >
              </div>
            </div>
            <div class="col-6">
              <label for="contact" class="mb-1">Contact</label>
              <input
                class="form-control"
                name="contact "
                v-model="postBody.contact"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !supplierContactAddressIsValid,
                }"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Please enter supplier address not more than 20
                  characters</span
                >
              </div>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label for="email" class="mb-1">Email</label>
              <input
                class="form-control"
                name="email"
                v-model="postBody.email"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !EmailIsValid,
                }"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5">Invalid Email</span>
              </div>
            </div>
            <div class="col-6">
              <label for="phone" class="mb-1">Phone No.</label>
              <input
                class="form-control"
                v-model="postBody.phone"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !PhoneNoIsvalid && phoneblur,
                }"
                v-on:blur="phoneblur = true"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Phone number is required not more than 12 numbers</span
                >
              </div>
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
  </div>
</template>
<script>
import Datepicker from "vuejs-datepicker";
import VueSimpleAlert from "vue-simple-alert";
export default {
  props:['isFormVisible'],
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
      stateList: null,
      postBody: {
        supplierCode: "",
        name: "",
        address: "",
        email: "",
        contact: "",
        phone: "",
        city: "",
        sup_Last_Num: "",
        sup_Last_Num: "",
      },
      valid: false,
      codeblur: false,
      nameblur: false,
      addressblur: false,
      phoneblur: false,
    };
  },
  //   mounted() {
  //     axios.get(`/api/st_stksystem/getstates`).then((response) => {
  //       this.stateList = response.data;
  //     });
  //   },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      alert("watch");
      this.isFormVisible = true;
      (this.postBody.supplierCode = this.$store.state.objectToUpdate.supplierCode),
        (this.postBody.name = this.$store.state.objectToUpdate.name),
        (this.postBody.address = this.$store.state.objectToUpdate.address),
        (this.postBody.email = this.$store.state.objectToUpdate.email);
      this.postBody.address = this.$store.state.objectToUpdate.address;
      this.postBody.contact = this.$store.state.objectToUpdate.contact;
      this.postBody.phone = this.$store.state.objectToUpdate.phone;
      this.postBody.sup_Last_Num = this.$store.state.objectToUpdate.installDate;
      this.postBody.sup_Last_Num = this.$store.state.objectToUpdate.sup_Last_Num;
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
      this.isFormVisible=false;
    },
    postPost() {
      if (this.submitorUpdate == "Submit") {
        axios
          .post(`/api/supplier/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.supplierCode = "";
              this.postBody.name = "";
              this.postBody.address = "";
              this.postBody.email = "";
              this.postBody.contact = "";
              this.postBody.phone = "";
              this.postBody.sup_Last_Num = "";
              this.postBody.sup_Last_Num = "";
              this.$store.stateName.objectToUpdate = "create";
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      }
      if (this.submitorUpdate == "Update") {
        alert("Ready to Update");
        axios
          .put(`/api/supplier/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.submitorUpdate = "Submit";
              this.postBody.supplierCode = "";
              this.postBody.name = "";
              this.postBody.address = "";
              this.postBody.email = "";
              this.postBody.contact = "";
              this.postBody.phone = "";
              this.postBody.sup_Last_Num = "";
              this.postBody.sup_Last_Num = "";
              this.$store.state.objectToUpdate = "update";
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      }
    },
    validate() {
      this.codeblur = true;
      this.nameblur = true;
      this.addressblur = true;
      this.phoneblur = true;
      if (
        this.supplierCodeIsValid &&
        this.supplierNameIsValid &&
        this.supplierAddressIsValid &&
        this.supplierContactAddressIsValid &&
        this.EmailIsValid &&
        this.supplierNameIsValid &&
        this.PhoneNoIsvalid
      ) {
        this.valid = true;
      } else {
        this.valid = false;
        return;
      }
    },
  },
  computed: {
    supplierCodeIsValid() {
      return (
        this.postBody.supplierCode != "" &&
        this.postBody.supplierCode.length >= 1 &&
        this.postBody.supplierCode.length <= 5
      );
    },

    supplierNameIsValid() {
      return (
        this.postBody.name != "" &&
        this.postBody.name.length >= 1 &&
        this.postBody.name.length <= 50
      );
    },

    supplierAddressIsValid() {
      return (
        this.postBody.address != "" &&
        this.postBody.address.length >= 1 &&
        this.postBody.name.length <= 50
      );
    },

    supplierContactAddressIsValid() {
      return (
        this.postBody.contact == "" ||
        (this.postBody.contact.length >= 1 &&
          this.postBody.contact.length <= 20)
      );
    },

    EmailIsValid() {
      var re = /(.+)@(.+){2,}\.(.+){2,}/;
      return (
        this.postBody.email == "" || re.test(this.postBody.email.toLowerCase())
      );
    },

    PhoneNoIsvalid() {
      var phoneno = /^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
      return (
        this.postBody.phone != "" &&
        this.postBody.phone.length >= 1 &&
        this.postBody.phone.length <= 15
        // this.postBody.phone.match(phoneno))
      );
    },
    setter() {
      let objecttoedit = this.$store.state.objectToUpdate;
       alert("setter");
      if (objecttoedit.supplierCode) {
        this.postBody.supplierCode = objecttoedit.supplierCode;
        this.postBody.name = objecttoedit.name;
        this.postBody.address = objecttoedit.address;
        this.postBody.email = objecttoedit.email;
        this.postBody.contact = objecttoedit.contact;
        this.postBody.phone = objecttoedit.phone;
        this.postBody.sup_Last_Num = objecttoedit.sup_Last_Num;
        this.postBody.sup_Last_Num = objecttoedit.sup_Last_Num;
      }
    },
  },
};
</script>
