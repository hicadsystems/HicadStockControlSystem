<template>
  <div>
    <div class="row">
      <!--  <div class="col-6">
        <label for="locationCode" class="mb-1">Department</label>
        <select
          class="form-control"
          v-model="locationCode"
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
      </div> -->
    </div>
    <div class="card">
      <!--<div class="card-header">
        <h3 class="card-title  text-center">Stock Request Form</h3>
      </div>-->
      <div>
        <div class="p-5" id="vertical-form">
          <div class="preview">
            <div class="row">
              <div class="col-6">
                <label for="locationCode" class="mb-1">Department</label>
                <select
                  class="form-control"
                  v-model="postBody.locationCode"
                  name="locationCode"
                  :class="{
                    'is-invalid': !departmentIsValid && locationblur,
                  }"
                  v-on:blur="locationblur = true"
                  @change="isSelected = true"
                  :disabled="isSelected"
                >
                  <option>
                    --select department code--
                  </option>
                  <option
                    v-for="costcentre in DepartmentList"
                    v-bind:value="costcentre.unitCode"
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
                  v-model="newItem.itemCode"
                  name="itemCode"
                  placeholder="item code"
                  @change="getStockItems"
                  :class="{ 'is-invalid': !itemCodeIsValid && itemCodeblur && isAddItem }"
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
              <!--  <div class="col-2">
              <label for="qtyInTransaction" class="mb-1">Current Balance</label>
              <input
                class="form-control"
                name="qtyInTransaction "
                readonly="readonly"
                v-model="postBody.qtyInTransaction"
                placeholder="current bal"
              />
            </div>  -->
              <div class="col-2">
                <label for="qtyInTransaction" class="mb-1"
                  >Current Balance</label
                >
                <input
                  class="form-control"
                  name="qtyInTransaction "
                  readonly="readonly"
                  v-model="currentBal"
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
                  type="number"
                  class="form-control"
                  name="quantity"
                  v-model="newItem.quantity"
                  :class="{ 'is-invalid': !quantityIsValid && quantityblur && isAddItem}"
                  v-on:blur="quantityblur = true"
                />
                {{ quantityIsValid }}
                <div class="invalid-feedback">
                  <span class="text-danger h5">Invalid Entry Or</span> <br />
                  <span class="text-danger h5"
                    >quantity requested is more than current quantity</span
                  >
                </div>
              </div>
              <div class="col-1"></div>
              <div class="col-2">
                <label for="unit" class="mb-1">unit</label>
                <input
                  class="form-control"
                  name="unit"
                  readonly="readonly"
                  v-model="newItem.unit"
                  placeholder="unit"
                />
              </div>
            </div>

            <br />
            <div role="group">
              <button
                class="btn btn-submit btn-primary float-right"
                v-on:click="addLineItem"
                type="submit"
              >
                Add item
              </button>
            </div>
            <!-- <div v-if="canProcess" role="group">
            <button
              class="btn btn-submit btn-primary float-right"
              v-on:click="checkForm"
              type="submit"
            >
              {{ submitorUpdate }}
            </button>
          </div> -->
          </div>
        </div>
      </div>
      <!--<div class="card-body">
        
      </div>-->
    </div>

    <div class="card">
      <div class="card-header">
        <h1 class="card-title  text-center"><b>Request Items</b></h1>
      </div>
      <div class="card-body">
        <div class="table-responsive-sm">
          <table class="table table-bordered table-hover">
            <thead>
              <tr>
                <th>Item Code</th>
                <th>Quantity</th>
                <th>unit</th>
               <!-- <th>Option</th>-->
              </tr>
            </thead>
            <tbody>
              <tr v-for="lineItem in postBody.lineItems" :key="lineItem.itemCode">
                <td>{{ lineItem.itemCode }}</td>
                <td>{{ lineItem.quantity }}</td>
                <td>{{ lineItem.unit }}</td>
                <!--<td>
                <button @click="removeItem(lineItem.itemCode)" class="btn btn-danger">Remove Item</button>
                </td>-->
              </tr>
            </tbody>
          </table>
          <div v-if="postBody.lineItems.length > 0" role="group">
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
    <!--Line Items -->
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
      quantityblur: false,
      valid: false,
      isSelected: false,
      isAddItem: false,

      // lineItems: [],
      // locationCode: "",
      currentBal: "",

      postBody: {
        // itemCode: "",
        // quantity: "",
        // unit: "",
        locationCode: "",
        lineItems: [],
        // itemDesc: "",
        // qtyInTransaction: 0,
      },

      newItem: {
        quantity: 0,
        itemCode: "",
        unit: "",
        // itemDesc:""
      },
    };
  },

  mounted() {
    this.getDepartment();
    this.getItemCode();
  },
  // watch: {
  //   "$store.state.objectToUpdate": function(newVal, oldVal) {
  //     (this.postBody.locationCode = this.$store.state.objectToUpdate.locationCode),
  //       (this.postBody.itemCode = this.$store.state.objectToUpdate.itemCode),
  //       (this.postBody.itemCode = this.$store.state.objectToUpdate.itemDesc),
  //       (this.postBody.qtyInTransaction = this.$store.state.objectToUpdate.qtyInTransaction),
  //       (this.postBody.quantity = this.$store.state.objectToUpdate.quantity);
  //     this.postBody.unit = this.$store.state.objectToUpdate.unit;
  //     this.submitorUpdate = "Update";
  //   },
  // },
  methods: {
    checkForm() {
      // alert(this.postBody);
      // console.log(this.postBody);
      // console.log(this.postBody.locationCode);
      axios
          .post(`/api/requisition/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.locationCode = "",
              this.postBody.lineItems=[]
            }
            // window.location.reload();
          })
          .catch((e) => {
            this.errors.push(e);
          });

    },
    postPost() {
      if (this.submitorUpdate == "Submit") {
        axios
          .post(`/api/requisition/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              // this.postBody.locationCode = "";
              // this.postBody.itemCode = "";
              // this.postBody.itemDesc = "";
              // this.postBody.quantity = "";
              // this.postBody.unit = "";
              // this.$store.stateName.objectToUpdate = "create";
              location = this.locationCode;
              this.lineItems = [];
            }
            // this.document.getElementById('#requestForm').value = "";
            // this.$refs.requestForm.reset();
            // window.location.reload();
          })
          .catch((e) => {
            if (e) this.errors.push(e);
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
            window.location.reload();
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
      // alert(this.postBody.itemCode);
      axios
        .get(`/api/requisition/getStockItems/${this.newItem.itemCode}`)
        .then((response) => {
          this.StockItemsList = response.data;
          this.currentBal = response.data.currentBalance;
          this.newItem.unit = response.data.unit;
          // this.postBody.currentBal = response.data.currentBalance;
          // this.postBody.unit = response.data.unit;
        });
        
    },
    getItemCode() {
      axios.get(`/api/itemmaster`).then((response) => {
        this.ItemList = response.data;
      });
    },

    validate() {
      this.locationblur = true;
      this.itemCodeblur = true;
      this.quantityblur = true;
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

    addLineItem() {
      this.validate();
      if (this.valid) {
        let newItem = {
          itemCode: this.newItem.itemCode,
          quantity: Number(this.newItem.quantity),
          unit: this.newItem.unit,
        };

        //checking for duplicate item
        let existingItems = this.postBody.lineItems.map((item) => item.itemCode);

        if (existingItems.includes(newItem.itemCode)) {
          let lineItem = this.postBody.lineItems.find(
            (item) => item.itemCode === newItem.itemCode
          );

          let currentQuantity = Number(lineItem.quantity);
          let updateQuantity = (currentQuantity += newItem.quantity);
          lineItem.quantity = updateQuantity;
        } else {
          let result = this.postBody.lineItems.push(this.newItem);
          console.log(result);
        }

        this.newItem = { itemCode: "", quantity: "", /*unit: ""*/ };
        // this.newItem = [{ itemCode: "", quantity: "", unit: "" }];
        this.isAddItem = true;

        // this.currentBal -= this.quantity
      }else{
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
      }
      // alert(this.newItem.itemCode)
    },

    removeItem(itemCode){
      this.lineItems.splice(this.itemCode, 1)
    }
  },
  computed: {
    departmentIsValid() {
      // return this.postBody.locationCode != "";
      return this.locationCode != "";
    },

    itemCodeIsValid() {
      // return this.postBody.itemCode != "";
      return this.newItem.itemCode != "";
    },

    quantityIsValid() {
      return (
        this.newItem.quantity != "" &&
       ( parseInt(this.newItem.quantity) >= 0 || this.newItem.quantity == null) &&
        parseInt(this.newItem.quantity) <= parseInt(this.currentBal)
      );
    },

    // isDisabled() {
    //   return (this.isSelected = true);
    // },
    // setter() {
    //   let objecttoedit = this.$store.state.objectToUpdate;
    //   if (objecttoedit.supplierCode) {
    //     this.postBody.locationCode = objecttoedit.locationCode;
    //     this.postBody.itemCode = objecttoedit.itemCode;
    //     this.postBody.itemCode = objecttoedit.itemDesc;
    //     this.postBody.quantity = objecttoedit.quantity;
    //     this.postBody.unit = objecttoedit.unit;
    //   }
    // },
  },
};
</script>
