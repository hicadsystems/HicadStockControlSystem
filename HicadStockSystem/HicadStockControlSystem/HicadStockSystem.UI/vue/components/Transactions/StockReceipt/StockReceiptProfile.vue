<template>
  <div>
    <div v-if="errors" class="has-error">{{ [errors] }}</div>
    <div v-if="responseMessage" class="has-error">{{ responseMessage }}</div>
    <form @submit="checkForm" method="post">
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-3">
            <label for="supplierCode" class="mb-1">Doc Number</label>
              <input
                class="form-control"
                name="supplierCode"
                v-model="postBody.docNo"
                placeholder="Doc Number"
              />
            </div>
            <div class="col-3 offset-3">
            <label for="name" class="mb-1">Date</label>
              <input
                type="date"
                class="form-control"
                name="name"
                v-model="postBody.docDate"
                placeholder="supplier name"
              />
            </div>
            <div class="col-6 offset-3">
            <label for="name" class="mb-1">Supplier</label>
            <select
                class="form-control"
                v-model="postBody.supplier"
                name="stateName"
                placeholder="state"
                required
              >
                <option
                  v-for="businessLine in BusinessLineList"
                  v-bind:value="businessLine.businessLine"
                  v-bind:key="businessLine.businessLine"
                >
                  {{ businessLine.supplier }}
                </option>
              </select>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-9">
          <label for="address" class="mb-1">Stock Item</label>
             <select
                class="form-control"
                v-model="postBody.itemCode"
                name="stateName"
                placeholder="state"
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
          <div class="col-4"></div>
            <div class="col-3">
          <label for="email" class="mb-1">Quantity</label>
              <input
                class="form-control"
                name="email"
                v-model="postBody.quantity"
                placeholder="email"
              />
            </div>
            <div class="col-1"></div>
            <div class="col-3">
            <label for="phone" class="mb-1">Price</label>
              <input
                class="form-control"
                name="phone"
                v-model="postBody.price"
                placeholder="phone number"
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
      postBody: {
        docNo: "",
        name: "",
        address: "",
        email: "",
        contact: "",
        phone: "",
        city: "",
        sup_Last_Num: "",
        sup_Last_Num: "",
      },
    };
  },
  //   mounted() {
  //     axios.get(`/api/st_stksystem/getstates`).then((response) => {
  //       this.stateList = response.data;
  //     });
  //   },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
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
      if (this.postBody.supplierCode) {
        e.preventDefault();
        this.canProcess = false;
        alert(this.postBody.supplierCode, "i am here");
        this.postPost();
      } else {
        this.errors = [];
        this.errors.push("Supply all the required field");
      }
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
  },
  computed: {
    setter() {
      let objecttoedit = this.$store.state.objectToUpdate;
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
