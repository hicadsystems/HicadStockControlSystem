<template>
  <div>
    <div>
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-3">
              <label for="docDate" class="mb-1">Date</label>
              <input
                type="date"
                class="form-control"
                name="docDate"
                v-model="postBody.docDate"
                :class="{ 'is-invalid': !dateIsValid && dateblur }"
                v-on:bind="dateblur = true"
                 @change="isSelectedDate = true"
                v-bind:disabled="isSelectedDate"
              />
            </div>
            <div class="col-3">
              <label for="quantity" class="mb-1">Quantity</label>
              <input
              type="number"
                class="form-control"
                name="quantity"
                v-model="newItem.quantity"
                :class="{ 'is-invalid': !quantityIsValid && qtyblur }"
                v-on:blur="qtyblur = true"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5">Invalid Entry</span>
              </div>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-9">
              <label for="itemCode" class="mb-1">Stock Item</label>
              <select
                class="form-control"
                v-model="newItem.itemCode"
                name="itemCode"
                :class="{ 'is-invalid': !itemIsValid && codeblur }"
                v-on:blur="codeblur = true"
              >
                <option
                  v-for="item in itemList"
                  v-bind:value="item.itemDesc"
                  v-bind:key="item.itemCode"
                >
                  {{ item.itemDesc }}
                </option>
              </select>
              <div class="invalid-feedback">
                <span class="text-danger h5">Please select Item</span>
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-9">
              <label for="itemCode" class="mb-1">Department</label>
              <select
                class="form-control"
                v-model="postBody.location"
                name="locationCode"
                :class="{ 'is-invalid': !departmentIsValid && locationblur }"
                v-on:blur="locationblur = true"
                @change="isSelectedItem = true"
                v-bind:disabled="isSelectedItem"
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
            <div class="col-9">
              <label for="itemCode" class="mb-1">Remarks</label>
              <select
                class="form-control"
                v-model="newItem.remark"
                name="locationCode"
                :class="{ 'is-invalid': !remarkIsValid && remarkblur }"
                v-on:blur="remarkblur = true"
              >
                <option>
                  --select remark--
                </option>
                <option
                  v-for="remark in RemarkList"
                  v-bind:value="remark.remark"
                  :key="remark.id"
                >
                  {{ remark.remark }}
                </option>
              </select>
              <div class="invalid-feedback">
                <span class="text-danger h5">Please select department</span>
              </div>
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
        </div>
      </div>
    </div>

    <!--Line Items -->
    <div class="card">
      <div class="card-header">
        <h1 class="card-title  text-center"><b>Return Items</b></h1>
      </div>
      <div class="card-body">
        <div class="table-responsive-sm">
          <table class="table table-bordered table-hover">
            <thead>
              <tr>
                <th>Item Code</th>
                <th>Quantity</th>
                <th>Remarks</th>
                <!--<th>Unit</th>-->
                <!--<th>Option</th>-->
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="lineItem in postBody.lineItems"
                :key="lineItem.itemCode"
              >
                <td>{{ lineItem.itemCode }}</td>
                <td>{{ lineItem.quantity }}</td>
                <td>{{ lineItem.remark }}</td>
                <!--<td>{{ lineItem.units }}</td>-->
                <!--<td>
                  <button
                    @click="removeItem(lineItem.itemCode)"
                    class="btn btn-danger"
                  >
                    Remove Item
                  </button>
                </td>-->
              </tr>
            </tbody>
          </table>
          <div v-if="this.postBody.lineItems.length > 0" role="group">
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
export default {
  components: {
    Datepicker,
  },
  data() {
    return {
      errors: null,
      valid: false,
      codeblur: false,
      locationblur: false,
      dateblur: false,
      qtyblur: false,
      isSelectedItem: false,
      isSelectedDate: false,
      remarkblur: false,
      responseMessage: "",
      submitorUpdate: "Submit",
      canProcess: true,
      DepartmentList: null,
      itemList: null,
      RemarkList: null,
      postBody: {
        // itemCode: "",
        docDate: "",
        location: "",
        // price: "",
        quantity: "",
        remark: "",
        lineItems: [],
      },
      
      newItem: {
        quantity: 0,
        itemCode: "",
        // unit: "",
        remark: "",
      },
    };
  },
  mounted() {
    this.getStockItem();
    this.getDepartment();
    this.getRemark();
  },
  //   watch: {
  //     "$store.state.objectToUpdate": function(newVal, oldVal) {
  //       (this.postBody.itemCode = this.$store.state.objectToUpdate.itemCode),
  //         (this.postBody.docDate = this.$store.state.objectToUpdate.docDate),
  //         (this.postBody.locationCode = this.$store.state.objectToUpdate.locationCode),
  //         // (this.postBody.price = this.$store.state.objectToUpdate.price);
  //       this.postBody.quantity = this.$store.state.objectToUpdate.quantity;
  //       this.submitorUpdate = "Update";
  //     },
  //   },
  methods: {
    checkForm: function(e) {
      console.log(this.postBody.lineItems);
      axios
        .put(`/api/stockhistory/`, this.postBody)
        .then((response) => {
          this.responseMessage = response.data.responseDescription;
          this.canProcess = true;
          if (response.data.responseCode == "200") {
            // this.postBody.itemCode = "";
            this.postBody.docDate = "";
            this.postBody.location = "";
            this.postBody.lineItems = [];
            // this.postBody.quantity = "";
            // this.postBody.remark = "";
            //   this.$store.stateName.objectToUpdate = "create";
          }
          // this.$alert("Submit Form", "Ok", "info");
          window.location.reload();
        })
        .catch((e) => {
          this.errors.push(e);
        });
      // this.$alert("Submit Form", "Ok", "info");
    },

    getStockItem() {
      axios.get(`/api/itemmaster/`).then((response) => {
        this.itemList = response.data;
      });
    },

    getDepartment() {
      axios.get(`/api/requisition/getcostcentre`).then((response) => {
        this.DepartmentList = response.data;
      });
    },

    getRemark() {
      axios.get(`/api/remarks/`).then((response) => {
        this.RemarkList = response.data;
      });
    },

    addLineItem() {
      this.validate();
      if (this.valid) {
        let newItem = {
          itemCode: this.newItem.itemCode,
          quantity: Number(this.newItem.quantity),
          // unit: this.newItem.unit,
          remark: this.newItem.remark,
        };

        //checking for duplicate item
        let existingItems = this.postBody.lineItems.map(
          (item) => item.itemCode
        );

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

        this.newItem = { itemCode: "", quantity: "", remark: "" };
        // this.newItem = [{ itemCode: "", quantity: "", unit: "" }];
        this.isAddItem = true;

        // this.currentBal -= this.quantity
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
      }
      // alert(this.newItem.itemCode)
    },
    /*removeItem(itemCode) {
      this.postBody.lineItems.splice(this.itemCode, 1);
    },*/

    validate() {
      this.codeblur = true;
      this.qtyblur = true;
      this.dateblur = true;
      this.locationblur = true;
      this.remarkblur = true;
      if (
        this.itemIsValid &&
        this.quantityIsValid &&
        this.departmentIsValid &&
        this.remarkIsValid &&
        this.dateIsValid
      ) {
        this.valid = true;
      } else {
        this.valid = false;
        return;
      }
    },
  },

  computed: {
    itemIsValid() {
      return this.newItem.itemCode != "" && this.newItem.itemCode.length >= 1;
    },

    departmentIsValid() {
      return this.postBody.location != "";
    },

    // priceIsValid() {
    //   return (
    //     this.postBody.price == "" ||
    //     (this.postBody.price.length >= 1 && parseInt(this.postBody.price) >= 1)
    //   );
    // },

    dateIsValid() {
      return (
        this.postBody.docDate != ""
        // (this.postBody.price.length >= 1 && parseInt(this.postBody.price) >= 1)
      );
    },

    quantityIsValid() {
      return (
        this.newItem.quantity != "" && parseInt(this.newItem.quantity) >= 0
      );
    },

    remarkIsValid() {
      return this.newItem.remark != "";
    },
    // setter() {
    //   let objecttoedit = this.$store.state.objectToUpdate;
    //   if (objecttoedit.itemCode) {
    //     this.postBody.itemCode = objecttoedit.itemCode;
    //     this.postBody.docDate = objecttoedit.docDate;
    //     this.postBody.address = objecttoedit.address;
    //     this.postBody.email = objecttoedit.email;
    //     this.postBody.contact = objecttoedit.contact;
    //     this.postBody.phone = objecttoedit.phone;
    //     this.postBody.sup_Last_Num = objecttoedit.sup_Last_Num;
    //     this.postBody.sup_Last_Num = objecttoedit.sup_Last_Num;
    //   }
    // },
  },
};
</script>
