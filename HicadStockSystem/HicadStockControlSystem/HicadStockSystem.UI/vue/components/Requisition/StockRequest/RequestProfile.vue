<template>
  <div>
    <form @submit.prevent="checkForm" method="post">
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-6">
              <label for="locationCode" class="mb-1">Department</label>
              <select
                class="form-control"
                v-model="postBody.locationCode"
                name="locationCode"
                :class="{ 'is-invalid': !departmentIsValid && locationblur }"
                v-on:blur="locationblur = true"
              >
                <option>
                  --select department code--
                </option>
                <option
                  v-for="costcentre in DepartmentList"
                  v-bind:value="costcentre.unitCode"
                  :key="costcentre.unitCode"
                >
                  {{ costcentre.unitDesc }}
                </option>
              </select>
              <div class="invalid-feedback">
                <span class="text-danger h5">Please select department</span>
              </div>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label for="itemCode" class="mb-1">Item Description</label>
              <select
                class="form-control"
                v-model="postBody.itemCode"
                name="itemCode"
                placeholder="item code"
                @change="getStockItems"
                :class="{ 'is-invalid': !itemCodeIsValid && itemCodeblur }"
                v-on:blur="itemCodeblur = true"
              >
                <option>
                  --select Item code--
                </option>
                <option
                  v-for="item in ItemList"
                  v-bind:value="item.itemCode"
                  :key="item.itemCode"
                >
                  {{ item.itemDesc }}
                </option>
              </select>
                <div class="invalid-feedback">
                <span class="text-danger h5">Please select item</span>
              </div>
            </div>
            <div class="col-1"></div>
            <div class="col-2">
              <label for="qtyInTransaction" class="mb-1">Current Balance</label>
              <input
                class="form-control"
                name="qtyInTransaction "
                readonly="readonly"
                v-model="postBody.qtyInTransaction"
                placeholder="current bal"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-4"></div>
            <div class="col-2">
              <label for="quantity" class="mb-1">Quantity Required</label>
              <input
                class="form-control"
                name="quantity"
                v-model="postBody.quantity"
                :class="{ 'is-invalid': !quantityIsValid }"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5">Invalid Entry</span>
              </div>
            </div>
            <div class="col-1"></div>
            <div class="col-2">
              <label for="unit" class="mb-1">unit</label>
              <input
                class="form-control"
                name="unit"
                readonly="readonly"
                v-model="postBody.unit"
                placeholder="unit"
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
      DepartmentList: null,
      ItemList: null,
      StockItemsList: null,
      locationblur: false,
      itemCodeblur: false,
      valid: false,
      postBody: {
        locationCode: "",
        itemCode: "",
        itemDesc: "",
        qtyInTransaction: 0,
        quantity: "",
        unit: "",
      },
    };
  },
  mounted() {
    this.getDepartment();
    this.getItemCode();
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      (this.postBody.locationCode = this.$store.state.objectToUpdate.locationCode),
        (this.postBody.itemCode = this.$store.state.objectToUpdate.itemCode),
        (this.postBody.itemCode = this.$store.state.objectToUpdate.itemDesc),
        (this.postBody.qtyInTransaction = this.$store.state.objectToUpdate.qtyInTransaction),
        (this.postBody.quantity = this.$store.state.objectToUpdate.quantity);
      this.postBody.unit = this.$store.state.objectToUpdate.unit;
      this.submitorUpdate = "Update";
    },
  },
  methods: {
    checkForm: function(e) {
      this.validate();
      if (this.valid) {
        e.preventDefault();
        this.canProcess = false;
        this.$alert("Submit Form", "Ok", "info");
        this.postPost();
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
        this.errors = [];
        this.errors.push("Supply all the required field");
      }
    },
    postPost() {
      if (this.submitorUpdate == "Submit") {
        axios
          .post(`/api/requisition/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.locationCode = "";
              this.postBody.itemCode = "";
              this.postBody.itemDesc = "";
              this.postBody.quantity = "";
              this.postBody.unit = "";
              this.$store.stateName.objectToUpdate = "create";
            }
          })
          .catch((e) => {
            if(e)
            this.errors.push(e);
          });
      }
      if (this.submitorUpdate == "Update") {
        alert("Ready to Update");
        axios
          .put(`/api/requisition/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.submitorUpdate = "Submit";
              this.postBody.locationCode = "";
              this.postBody.itemCode = "";
              this.postBody.itemDesc = "";
              this.postBody.quantity = 0;
              this.postBody.unit = "";
              this.$store.state.objectToUpdate = "update";
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      }
    },
    getDepartment() {
      axios.get(`/api/requisition/getcostcentre`).then((response) => {
        this.DepartmentList = response.data;
      });
    },
    //gets the unit, currentBal of item
    getStockItems() {
      // this.postBody.itemCode="1234"
      alert(this.postBody.itemCode);
      axios
        .get(`/api/requisition/getStockItems/${this.postBody.itemCode}`)
        .then((response) => {
          this.StockItemsList = response.data;
          this.postBody.qtyInTransaction = response.data.currentBalance;
          this.postBody.unit = response.data.unit;
        });
    },
    getItemCode() {
      axios.get(`/api/requisition/getItemCode`).then((response) => {
        this.ItemList = response.data;
      });
    },
    validate() {
      this.locationblur = true;
      this.itemCodeblur = true;
      if (
        this.departmentIsValid &&
        this.itemCodeIsValid &&
        this.quantityIsValid
      ) {
        this.valid = true;
      } else {
        this.valid = false;
        return;
      }
    },
  },
  computed: {
    departmentIsValid() {
      return this.postBody.locationCode != "";
    },

    itemCodeIsValid() {
      return this.postBody.itemCode != "";
    },

    quantityIsValid() {
      return (
        this.postBody.quantity == "" || parseInt(this.postBody.quantity) >= 1
      );
    },
    setter() {
      let objecttoedit = this.$store.state.objectToUpdate;
      if (objecttoedit.supplierCode) {
        this.postBody.locationCode = objecttoedit.locationCode;
        this.postBody.itemCode = objecttoedit.itemCode;
        this.postBody.itemCode = objecttoedit.itemDesc;
        this.postBody.quantity = objecttoedit.quantity;
        this.postBody.unit = objecttoedit.unit;
      }
    },
  },
};
</script>
