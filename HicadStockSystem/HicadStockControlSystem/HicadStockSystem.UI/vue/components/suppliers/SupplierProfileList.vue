<template>
  <!-- WRAPPER -->
  <!-- FORM DIV -->
  <div>
    <div v-if="isFormVisible">
      <form @submit.prevent="checkForm()" ref="supplierForm" method="post">
        <div class="p-5" id="vertical-form">
          <div class="preview">
            <div class="row">
              <div class="col-3">
                <label for="supplierCode" class="mb-1">Supplier Code</label>
                <input
                  ref="supplierCode"
                  class="form-control"
                  name="supplierCode"
                  v-model="postBody.supplierCode"
                  v-bind:class="{
                    'form-control': true,
                    'is-invalid': !supplierCodeIsValid && codeblur,
                  }"
                  v-on:blur="codeblur = true"
                  :readonly="isEdit"
                />
                <div class="invalid-feedback">
                  <span class="text-danger h5"
                    >Please enter supplier code not more than 15
                    characters</span
                  >
                </div>
              </div>
              <div class="col-6 offset-3">
                <label for="name" class="mb-1">Supplier Name</label>
                <input
                  ref="supplierCode"
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
                    >Please enter supplier name not more than 50
                    characters</span
                  >
                </div>
              </div>
            </div>
            <br />
            <div class="row">
              <div class="col-6">
                <label for="address" class="mb-1">Supplier Address</label>
                <input
                  ref="address"
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
                  ref="contact"
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
                  ref="email"
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
                  ref="phone"
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
                    >Phone number is required not more than 20 characters</span
                  >
                </div>
              </div>
            </div>

            <br />
            <div v-if="canProcess" role="group">
              <button
                class="btn btn-submit btn-primary float-right"
                v-on:click="checkForm()"
                type="submit"
              >
                {{ submitorUpdate }}
              </button>
            </div>
          </div>
        </div>
      </form>
    </div>
    <!--END OF FORM DIV -->

    <!-- NAV DIV -->
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item" aria-current="page">
          <a @click="showForm()"><span class="h4">Create Supplier</span></a>
        </li>
        <li class="breadcrumb-item active" aria-current="page">
          <span class="h4">Supplier List</span>
        </li>
      </ol>
    </nav>
    <!-- NAV DIV -->

    <!-- TABLE LIST DIV -->
    <table class="table table-striped table-bordered table-hover">
      <thead>
        <tr>
          <th>Supplier Code</th>
          <th>Supplier name</th>
          <th>Supplier Address</th>
          <th>Contact</th>
          <th>Phone Number</th>
          <th>Option</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(status, index) in statusList" :key="index">
          <td>{{ status.supplierCode }}</td>
          <td>{{ status.name }}</td>
          <td>{{ status.address }}</td>
          <td>{{ status.contact }}</td>
          <td>{{ status.phone }}</td>
          <td>
            <button
              type="button"
              class="btn btn-submit btn-primary"
              @click="processRetrieve(status)"
            >
              Edit
            </button>
            <button
              type="button"
              class="btn btn-submit btn-danger"
              @click="processDelete(status.supplierCode)"
            >
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>

  <!-- END WRAPPER -->
</template>
<script>
import SupplierProfile from "/vue/components/suppliers/SupplierProfile";
import Datepicker from "vuejs-datepicker";
import VueSimpleAlert from "vue-simple-alert";
export default {
  components: {
    Datepicker,
    VueSimpleAlert,
  },
  data() {
    return {
      statusList: null,
      responseMessage: "",
      isFormVisible: false,
      isEdit: false,
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
  created() {
    this.$store.state.objectToUpdate = null;
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      // this.getAllSuppliers();
      // this.processDelete();
    },
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
  mounted() {
    this.getAllSuppliers();
  },
  methods: {
    processRetrieve: function(Status) {
      // alert(Status.supplierCode);
      this.$store.state.objectToUpdate = Status;
      this.isFormVisible = true;
      this.isEdit = true;
      // if ((this.$store.state.objectToUpdate = Status)) {
      //   this.isFormVisible = true;
      // }
    },
    processDelete: function(supplierCode) {
      // alert(supplierCode);
      this.$confirm("Are you sure?").then(() => {
        axios
          .patch(`/api/supplier/${supplierCode}`)
          .then((response) => {
            if (response.data.responseCode == "200") {
              alert("Supplier successfully deleted");
              // this.getAllSuppliers();
            }
            this.getAllSuppliers();
            // window.location.reload();
          })
          .catch((e) => {
            this.errors.push(e);
          });
      });
    },
    getAllSuppliers: function() {
      axios
        .get("/api/supplier/")
        .then((response) => (this.statusList = response.data));
    },
    getBySupplierCode() {
      axios.get(`"/api/supplier/"${status.supplierCode}`).then(response);
    },
    showForm() {
      this.isFormVisible = true;
      // this.resetForm();
      //  window.location.reload();
    },
    checkForm: function(e) {
      this.validate();
      if (this.valid) {
        this.$confirm("Are you sure?").then(() => {
          this.canProcess = false;
          this.postPost();
          this.isFormVisible = false;
          // window.location.reload()
          // this.$refs.supplierForm.reset();
        });
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
        this.errors = [];
        this.errors.push("Supply all the required field");
      }
      // this.isFormVisible=false;
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
            this.getAllSuppliers();
            window.location.reload();
            // this.resetForm();
            // this.$refs.supplierForm.reset();
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
            this.getAllSuppliers();
            // this.$refs.supplierForm.reset();
            window.location.reload();
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
        this.postBody.supplierCode.length <= 15
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
        this.postBody.phone.length <= 20
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
