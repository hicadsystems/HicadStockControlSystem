<template>
  <div>
    <div v-if="errors" class="has-error">{{ [errors] }}</div>
    <div v-if="responseMessage" class="has-error">{{ responseMessage }}</div>
    <form @submit="checkForm" method="post">
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-6">
              <label for="locationCode" class="mb-1">Department</label>
              <select
                class="form-control"
                v-model="postBody.locationCode"
                name="locationCode"
                placeholder="department"
                required
              >
                <option>
                  --select department code--
                </option>
                <option
                  v-for="(costcentre, index) in DepartmentList"
                  v-bind:value="costcentre.unitCode"
                  v-bind:selected="index === 0"
                >
                  {{ costcentre.unitDesc }}
                </option>
              </select>
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
                required
              >
                <option>
                  --select Item code--
                </option>
                <option
                  v-for="(item, index) in ItemList"
                  v-bind:value="item.itemCode"
                  v-bind:selected="index === 0"
                >
                  {{ item.itemDesc }}
                </option>
              </select>
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
                placeholder="quantity"
              />
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
      DepartmentList: null,
      ItemList: null,
      StockItemsList: null,
      postBody: {
        locationCode: "",
        itemCode: "",
        itemDesc: "",
        qtyInTransaction: 0,
        quantity: 0,
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
      if (this.postBody.itemCode) {
        e.preventDefault();
        this.canProcess = false;
        alert(this.postBody.itemCode, "i am here");
        this.postPost();
      } else {
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
              this.postBody.quantity = 0;
              this.postBody.unit = "";
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
  },
  computed: {
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
