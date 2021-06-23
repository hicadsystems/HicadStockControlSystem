<template>
  <div>
    <form @submit.prevent="checkForm" method="post">
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-4">
              <label for="unit" class="mb-1">Requisition No.</label>
              <select
                class="form-control"
                v-model="postBody.requisitionNo"
                name="requisitionNo"
                @change="getRequisitionApproval()"
                :class="{ 'is-invalid': !requisitionNoIsValid && reqblur }"
                v-on:blur="reqblur = true"
              >
                <option>
                  --select Requisition No.--
                </option>
                <option
                  v-for="requisition in RequisitionList"
                  v-bind:value="requisition"
                  v-bind:key="requisition"
                >
                  {{ requisition }}
                </option>
                <!-- <option
                  v-for="requisition in RequisitionList"
                  v-bind:value="requisition.index"
                  v-bind:key="requisition.index"
                >
                  {{ requisition.requisitionNo }}
                </option>-->
              </select>
              <div class="invalid-feedback">
                <span class="text-danger h5">Select requisition number</span>
              </div>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-4">
              <label for="unit" class="mb-1">Requisition By</label>
              <input
                class="form-control"
                name="userId "
                readonly="readonly"
                v-model="postBody.userId"
              />
            </div>
            <div class="col-4">
              <label for="unit" class="mb-1">Department</label>
              <input
                class="form-control"
                name="department "
                readonly="readonly"
                v-model="postBody.department"
              />
              <input
                type="hidden"
                name="locationCode"
                class="form-control"
                :value="postBody.locationCode"
              />
            </div>
            <div class="col-4">
              <label for="unit" class="mb-1">Date and Time</label>
              <input
                class="form-control"
                name="dateAndTime "
                readonly="readonly"
                v-model="postBody.requisitionDate"
              />
              <input
                type="hidden"
                name="createdOn"
                class="form-control"
                :value="postBody.createdOn"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <table class="table table-striped table-bordered table-hover">
              <thead>
                <tr>
                  <th>Item Code</th>
                  <th>Item Description</th>
                  <th>Request</th>
                  <th>Quantity Approved</th>
                  <th>Options</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="item in postBody.itemLists" :key="item.itemCode">
                  <td>
                    <input
                      class="form-control"
                      name="itemCode "
                      readonly="readonly"
                      v-model="item.itemCode"
                    />
                  </td>
                  <td>
                    <input
                      class="form-control"
                      name="description "
                      readonly="readonly"
                      v-model="item.itemDescription"
                    />
                  </td>
                  <td>
                    <input
                      class="form-control"
                      name="quantity"
                      readonly="readonly"
                      v-model="item.requested"
                    />
                  </td>
                  <td>
                    <input
                      class="form-control"
                      v-model="item.quantity"
                      name="approvedQty"
                      :class="{ 'is-invalid': !quantityIsValid && qtyblur }"
                      v-on:blur="qtyblur = true"
                    />
                    <div class="invalid-feedback">
                      <span class="text-danger h5">Invalid Entry</span>
                    </div>
                    <input
                      type="hidden"
                      name="locationCode"
                      class="form-control"
                      :value="item.unit"
                    />
                  </td>
                  <td>
                    <button
                      class="btn btn-submit btn-primary"
                      v-on:click="checkForm"
                      type="button"
                    >
                      Sign
                    </button>
                    <button
                      class="btn btn-submit btn-danger"
                      v-on:click="checkForm"
                      type="button"
                    >
                    Dismiss
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>

          <br />
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
      RequisitionList: null,
      ItemApprovalList: null,
      valid: false,
      reqblur: false,
      qtyblur: false,

      postBody: {
        locationCode: "",
        requisitionNo: "",
        userId: "",
        department: "",
        requisitionDate: "",
        // itemCode: "",
        // description: "",
        quantity: "",
        // Requestedquantity: "",
        createdOn: "",
        // itemList: {
        //   itemCode: "",
        //   description: "",
        //   Requestedquantity: "",
        //   unit: "",
        // },
        // unit:"",
        itemLists: [
          //   {
          //   itemCode: "",
          //   description: "",
          //   Requestedquantity: "",
          //   unit: "",
          // },
        ],
      },
    };
  },
  mounted() {
    this.getRequisition();
    // this.getItemCode();
  },

  methods: {
    checkForm() {
      this.validate();
      if (this.valid) {
        // e.preventDefault();
        axios
          .patch(`/api/requisition/RequisitionApproval`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.requisitionNo = "";
              this.postBody.userId = "";
              this.postBody.requisitionDate = "";
              this.postBody.createdOn = "";
              // this.postBody.itemCode = "";
              // this.postBody.description = "";
              // this.postBody.quantity = 0;
              this.postBody.quantity = "";
              this.postBody.locationCode = "";
              // this.postBody.unit = "";
              this.postBody.itemLists = [];
            }
            window.location.reload();
          })
          .catch((e) => {
            this.errors.push(e);
          });
        this.$alert("Submit Form", "Ok", "info");
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
        this.errors = [];
        this.errors.push("Supply all the required field");
      }
    },

    getRequisitionApproval() {
      // this.postBody.itemCode="1234"
      // alert(this.postBody.itemCode)
      axios
        .get(
          `/api/requisition/RequisitionApproval/${this.postBody.requisitionNo}`
        )
        .then((response) => {
          this.ItemApprovalList = response.data;
          this.postBody.userId = response.data.requisitionBy;
          this.postBody.department = response.data.department;
          this.postBody.requisitionDate = response.data.dateAndTime;
          this.postBody.requisitionNo = response.data.requisitionNo;
          // this.postBody.itemCode = response.data.itemCode;
          // this.postBody.description = response.data.itemDescription;
          // this.postBody.Requestedquantity = response.data.requested;
          this.postBody.createdOn = response.data.dateCreated;
          this.postBody.locationCode = response.data.costLocCode;
          // this.postBody.unit = response.data.unit;
          this.postBody.itemLists = response.data.itemLists;
        });
    },

    getRequisitionApprovalItems() {
      axios
        .get(
          `/api/requisition/RequisitionApprovalItems/${this.postBody.requisitionNo}`
        )
        .then((response) => {
          this.ItemApprovalList = response.data;
          this.postBody.itemCode = response.data.itemCode;
          this.postBody.description = response.data.itemDescription;
          this.postBody.Requestedquantity = response.data.requested;
          this.postBody.unit = response.data.unit;
        });
    },
    getRequisition() {
      axios.get(`/api/requisition/`).then((response) => {
        this.RequisitionList = response.data;
      });
    },
    validate() {
      this.reqblur = true;
      this.qtyblur = true;
      if (this.requisitionNoIsValid && this.quantityIsValid) {
        this.valid = true;
      } else {
        this.valid = false;
        return;
      }
    },
  },
  computed: {
    requisitionNoIsValid() {
      return this.postBody.requisitionNo != "";
    },
    //needs more validation
    quantityIsValid() {
      return (
        this.postBody.itemLists.quantity != "" &&
        parseInt(this.postBody.itemLists.quantity) >= 0
        // this.postBody.itemLists.quantity != "" && parseInt(this.postBody.itemLists.quantity) >= 0
      );
    },
    // setter() {
    //   let objecttoedit = this.$store.state.objectToUpdate;
    //   if (objecttoedit.supplierCode) {
    //     this.postBody.locationCode = objecttoedit.locationCode;
    //     this.postBody.itemCode = objecttoedit.itemCode;
    //     this.postBody.quantity = objecttoedit.quantity;
    //     this.postBody.unit = objecttoedit.unit;
    //   }
    // },
  },
};
</script>
