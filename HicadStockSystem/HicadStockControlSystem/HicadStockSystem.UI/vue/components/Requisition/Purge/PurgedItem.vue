<template>
  <div>
    <div class="card col-sm-6">
      <div class="p-4 ml-2">
        <div class="form-check">
          <input
            class="form-check-input"
            type="radio"
            name="exampleRadios"
            id="exampleRadios1"
            value="option1"
            checked
          />
          <label class="form-check-label" for="exampleRadios1">
            All
          </label>
        </div>
        <div class="form-check">
          <input
            class="form-check-input"
            type="radio"
            name="exampleRadios"
            id="exampleRadios2"
            value="option2"
          />
          <label class="form-check-label" for="exampleRadios2">
           Before Specific Code
          </label>
        </div>
       <div class="form-check">
          <input
            class="form-check-input"
            type="radio"
            name="exampleRadios"
            id="exampleRadios2"
            value="option2"
          />
          <label class="form-check-label" for="exampleRadios2">
           Specific Requisition
          </label>
        </div>
        <div  role="group">
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

    <!-- <div class="card">
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
                <th>Option</th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="lineItem in postBody.lineItems"
                :key="lineItem.itemCode"
              >
                <td>{{ lineItem.itemCode }}</td>
                <td>{{ lineItem.quantity }}</td>
                <td>{{ lineItem.unit }}</td>
                <td>
                  <button
                    @click="removeItem(lineItem.itemCode)"
                    class="btn btn-danger"
                  >
                    Remove Item
                  </button>
                </td>
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
    </div>-->
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
      alert(this.postBody);
      console.log(this.postBody);
      // console.log(this.postBody.locationCode);
      axios
        .post(`/api/requisition/`, this.postBody)
        .then((response) => {
          this.responseMessage = response.data.responseDescription;
          this.canProcess = true;
          if (response.data.responseCode == "200") {
            (this.postBody.locationCode = ""), (this.postBody.lineItems = []);
          }
        })
        .catch((e) => {
          this.errors.push(e);
        });
      // this.validate();
      // if (this.valid) {
      //   e.preventDefault();
      //   this.canProcess = false;

      //   // axios
      //   //   .post(`/api/requisition/`, this.postBody)
      //   //   .then((response) => {
      //   //     this.responseMessage = response.data.responseDescription;
      //   //     this.canProcess = true;
      //   //     if (response.data.responseCode == "200") {

      //   //       // this.postBody.locationCode = "";
      //   //       // this.postBody.itemCode = "";
      //   //       // this.postBody.itemDesc = "";
      //   //       // this.postBody.quantity = "";
      //   //       // this.postBody.unit = "";
      //   //       // this.$store.stateName.objectToUpdate = "create";
      //   //       location = this.locationCode;
      //   //       this.lineItems = [];
      //   //     }
      //   //     // this.document.getElementById('#requestForm').value = "";
      //   //     // this.$refs.requestForm.reset();
      //   //     // window.location.reload();
      //   //   })
      //   //   .catch((e) => {
      //   //     if (e) this.errors.push(e);
      //   //   });
      //   // // this.$alert("Submit Form", "Ok", "info");
      //   this.postPost();
      // } else {
      //   this.$alert("Please Fill Highlighted Fields", "missing", "error");
      //   this.errors = [];
      //   this.errors.push("Supply all the required field");
      // }
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
      axios.get(`/api/requisition/getItemCode`).then((response) => {
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

    /* addLineItem() {
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

        this.newItem = { itemCode: "", quantity: "", unit: "" };
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
    }*/
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
        (parseInt(this.newItem.quantity) >= 0 ||
          this.newItem.quantity == null) &&
        parseInt(this.newItem.quantity) <= parseInt(this.currentBal)
      );
    },
  },
};
</script>
