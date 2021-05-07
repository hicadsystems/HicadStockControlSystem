<template>
  <div>
    <div v-if="errors" class="has-error">{{ [errors] }}</div>
    <div v-if="responseMessage" class="has-error">{{ responseMessage }}</div>
    <form @submit="checkForm" method="post">
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-6">
              <select
                class="form-control"
                v-model="postBody.locationCode"
                name="locationCode"
                placeholder="department code"
                required
              >
                <option>
                  --select department code--
                </option>
                <option
                  v-for="costcentre in DepartmentList"
                  v-bind:value="costcentre"
                  :key="costcentre"
                >
                  {{ costcentre }}
                </option>
              </select>
            </div>
          </div>
         <br>
          <div class="row">
          <div class="col-4">
           <input
                class="form-control"
                name="qtyInTransaction "
                 readonly="readonly"
                v-model="postBody.qtyInTransaction"
                placeholder="current bal"
              />
          </div>
          <div class="col-4">
           <input
                class="form-control"
                name="qtyInTransaction "
                 readonly="readonly"
                v-model="postBody.qtyInTransaction"
                placeholder="current bal"
              />
          </div>
          <div class="col-4">
           <input
                class="form-control"
                name="qtyInTransaction "
                 readonly="readonly"
                v-model="postBody.qtyInTransaction"
                placeholder="current bal"
              />
          </div>
          </div>
          <br>
          <div class="row">
            <table class="table table-striped table-bordered table-hover">
              <thead>
                <tr>
                  <th>Requisition Number</th>
                  <th>Item Code</th>
                  <th>Quantity</th>
                  <th>unit</th>
                  <th>Options</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(status, index) in statusList" :key="index">
                  <td>{{ status.requisitionNo }}</td>
                  <td>{{ status.itemcode }}</td>
                  <td>{{ status.quantity }}</td>
                  <td>{{ status.unit }}</td>
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
                      class="btn btn-submit btn-primary"
                      @click="processDelete(status.requisitionNo)"
                    >
                      Delete
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
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
      ItemDescList: null,
      StockItemsList: null,
      postBody: {
        locationCode: "",
        itemCode: "",
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
    getStockItems() {
      // this.postBody.itemCode="1234"
      // alert(this.postBody.itemCode)
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
        this.ItemDescList = response.data;
      });
    },
  },
  computed: {
    setter() {
      let objecttoedit = this.$store.state.objectToUpdate;
      if (objecttoedit.supplierCode) {
        this.postBody.locationCode = objecttoedit.locationCode;
        this.postBody.itemCode = objecttoedit.itemCode;
        this.postBody.quantity = objecttoedit.quantity;
        this.postBody.unit = objecttoedit.unit;
      }
    },
  },
};
</script>
