<template>
  <div>
    <div class="card">
      <div class="card-body">
        <div>
          <div class="p-5" id="vertical-form">
            <div class="preview">
              <div class="row">
                <div class="col-6">
                  <label for="supplier" class="mb-1">Supplier</label>
                  <select
                    class="form-control"
                    v-model="postBody.supplier"
                    name="supplier"
                    :class="{ 'is-invalid': !supplierIsValid && supplierblur }"
                    v-on:blur="supplierblur = true"
                    @change="isSelected = true"
                    :disabled="isSelected"
                  >
                    <option
                      v-for="supplier in supplierList"
                      v-bind:value="supplier.supplierCode"
                      v-bind:key="supplier.supplierCode"
                    >
                      {{ supplier.name }}
                    </option>
                  </select>
                  <div class="invalid-feedback">
                    <span class="text-danger h5">Please select supplier</span>
                  </div>
                </div>
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
              <br />
              <div class="row">
                <div class="col-2"></div>
                <div class="col-3">
                  <label for="quantity" class="mb-1">Quantity</label>
                  <input
                    type="number"
                    class="form-control"
                    name="quantity"
                    v-model="newItem.quantity"
                    :class="{ 'is-invalid': !quantityIsValid && quantityblur }"
                    v-on:blur="quantityblur = true"
                  />
                  <div class="invalid-feedback">
                    <span class="text-danger h5">Invalid Entry</span>
                  </div>
                </div>
                <div class="col-1"></div>
                <div class="col-3">
                  <label for="price" class="mb-1">Price</label>
                  <input
                    type="number"
                    class="form-control"
                    name="price"
                    v-model="newItem.price"
                    :class="{ 'is-invalid': !priceIsValid && priceblur }"
                    v-on:blur="priceblur = true"
                  />
                  <div class="invalid-feedback">
                    <span class="text-danger h5">Invalid Entry</span>
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
      </div>
    </div>
    <!--End Of Form -->

    <!--Line Items -->
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
                <th>Unit Price</th>
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
                <td>{{ lineItem.price }}</td>
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
      supplierblur: false,
      dateblur: false,
      priceblur: false,
      quantityblur: false,
      responseMessage: "",
      submitorUpdate: "Submit",
      canProcess: true,
      supplierList: null,
      itemList: null,
      isSelected: false,
      isSelectedDate: false,

      postBody: {
        // itemCode: "",
        docDate: "",
        supplier: "",
        // price: "",
        // quantity: "",
        lineItems: [],
      },
      newItem: {
        quantity: 0,
        itemCode: "",
        // unit: "",
        price: "",
      },
    };
  },
  mounted() {
    this.getStockItem();
    this.getSuppliers();
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      (this.postBody.itemCode = this.$store.state.objectToUpdate.itemCode),
        (this.postBody.docDate = this.$store.state.objectToUpdate.docDate),
        (this.postBody.supplier = this.$store.state.objectToUpdate.supplier),
        (this.postBody.price = this.$store.state.objectToUpdate.price);
      this.postBody.quantity = this.$store.state.objectToUpdate.quantity;
      this.submitorUpdate = "Update";
    },
  },
  methods: {
    checkForm: function(e) {
      console.log(this.postBody);
      this.$confirm("Are you sure?").then(() => {
        axios
          .post(`/api/stockhistory/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              (this.postBody.docDate = ""),
                (this.postBody.supplier = ""),
                (this.postBody.lineItems = []);
            }
            window.location.reload();
          })
          .catch((e) => {
            this.errors.push(e);
          });
        // window.location.reload();
      });
    },

    getStockItem() {
      axios.get(`/api/itemmaster/`).then((response) => {
        this.itemList = response.data;
      });
    },

    getSuppliers() {
      axios.get(`/api/supplier/`).then((response) => {
        this.supplierList = response.data;
      });
    },

    validate() {
      this.codeblur = true;
      this.supplierblur = true;
      this.dateblur = true;
      this.priceblur = true;
      this.quantityblur = true;
      if (this.priceIsValid && this.itemIsValid && this.supplierIsValid) {
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
          // unit: this.newItem.unit,
          price: this.newItem.price,
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

        this.newItem = { itemCode: "", quantity: "", price: "" };
        // this.newItem = [{ itemCode: "", quantity: "", unit: "" }];
        this.isAddItem = true;

        // this.currentBal -= this.quantity
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
      }
      // alert(this.newItem.itemCode)
    },
    removeItem(itemCode) {
      this.postBody.lineItems.splice(this.itemCode, 1);
    },
  },

  computed: {
    itemIsValid() {
      return this.newItem.itemCode != "" && this.newItem.itemCode.length >= 1;
    },

    supplierIsValid() {
      return this.postBody.supplier != "" && this.postBody.supplier.length >= 1;
    },

    priceIsValid() {
      return (
        this.newItem.price != "" ||
        (this.newItem.price.length >= 1 && parseInt(this.newItem.price) >= 1)
      );
    },

    dateIsValid() {
      return (
        this.postBody.docDate != ""
        // (this.postBody.price.length >= 1 && parseInt(this.postBody.price) >= 1)
      );
    },
    quantityIsValid() {
      return (
        this.newItem.quantity != "" ||
        (this.newItem.quantity.length >= 1 &&
          parseInt(this.newItem.quantity) >= 1)
      );
    },
    setter() {
      let objecttoedit = this.$store.state.objectToUpdate;
      if (objecttoedit.itemCode) {
        this.postBody.itemCode = objecttoedit.itemCode;
        this.postBody.docDate = objecttoedit.docDate;
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
