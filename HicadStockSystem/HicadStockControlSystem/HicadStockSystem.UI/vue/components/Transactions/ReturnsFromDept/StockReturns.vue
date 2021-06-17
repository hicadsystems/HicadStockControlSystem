<template>
  <div>
    <form @submit.prevent="checkForm" method="post">
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
              />
            </div>
            <div class="col-3">
              <label for="quantity" class="mb-1">Quantity</label>
              <input
                class="form-control"
                name="quantity"
                v-model="postBody.quantity"
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
                v-model="postBody.itemCode"
                name="itemCode"
                :class="{ 'is-invalid': !itemIsValid && codeblur }"
                v-on:blur="codeblur = true"
              >
                <option
                  v-for="item in itemList"
                  v-bind:value="item.itemCode"
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
          <div role="group">
            <button
              class="btn btn-submit btn-primary float-right"
              v-on:click="checkForm"
              type="button"
            >
              Submit
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
      valid: false,
      codeblur: false,
      locationblur: false,
      dateblur: false,
      qtyblur: false,
      responseMessage: "",
      submitorUpdate: "Submit",
      canProcess: true,
      DepartmentList: null,
      itemList: null,
      postBody: {
        itemCode: "",
        docDate: "",
        location: "",
        // price: "",
        quantity: "",
      },
    };
  },
  mounted() {
    this.getStockItem();
    this.getDepartment();
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
      this.validate();
      if (this.valid) {
        // e.preventDefault();
        // alert(this.postBody.quantity);

        axios
          .put(`/api/stockhistory/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            // this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.itemCode = "";
              this.postBody.docDate = "";
              this.postBody.location = "";
              //   this.postBody.price = "";
              this.postBody.quantity = "";
              //   this.$store.stateName.objectToUpdate = "create";
            }
            // this.$alert("Submit Form", "Ok", "info");
            window.location.reload();
          })
          .catch((e) => {
            this.errors.push(e);
          });
        // this.$alert("Submit Form", "Ok", "info");
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
        this.errors = [];
        this.errors.push("Supply all the required field");
      }
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

    validate() {
      this.codeblur = true;
      this.qtyblur = true;
      this.dateblur = true;
      this.locationblur = true;
      if (
        this.itemIsValid &&
        this.quantityIsValid &&
        this.departmentIsValid &&
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
      return this.postBody.itemCode != "" && this.postBody.itemCode.length >= 1;
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
        this.postBody.quantity != "" && parseInt(this.postBody.quantity) >= 0
      );
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
