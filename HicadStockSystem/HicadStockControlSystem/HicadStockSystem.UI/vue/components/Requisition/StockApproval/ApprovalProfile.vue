<template>
  <div>
    <div class="card">
      <div class="card-body">
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
                    <!--<th>Options</th>-->
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="item in postBody.itemLists" :key="item.itemcode">
                    <td>
                      <!--<input
                      class="form-control"
                      name="itemCode "
                      readonly="readonly"
                      v-model="item.itemCode"
                    />-->
                      {{ item.itemCode }}
                    </td>
                    <td>
                      <!--<input
                      class="form-control"
                      name="description "
                      readonly="readonly"
                      v-model="item.itemDescription"
                    />-->
                      {{ item.itemDescription }}
                    </td>
                    <td>
                      <!--<input
                      class="form-control"
                      name="quantity"
                      readonly="readonly"
                      v-model="item.requested"
                    />-->
                      {{ item.requested }}
                    </td>
                    <td>
                      <input
                      type="number"
                        class="form-control"
                        v-model="item.quantity"
                        name="approvedQty"
                        :class="{
                          'is-invalid':
                            item.quantity >
                            item.currentBalance /*&& isSubmitted*/,
                        }"
                        v-on:blur="qtyblur = true"
                      />
                      {{ quantityIsValid }}
                      <div class="invalid-feedback">
                        <span class="text-danger h5"
                          >Availaible quantity {{ item.currentBalance }}</span
                        >
                      </div>
                      <input
                        type="hidden"
                        name="locationCode"
                        class="form-control"
                        :value="item.unit"
                      />
                    </td>
                   <!-- <td>
                      <button
                        class="btn btn-submit btn-danger"
                        @click="dismissItem(item.itemcode)"
                        type="button"
                      >
                        Dismiss
                      </button>
                    </td>-->
                  </tr>
                </tbody>
              </table>
            </div>
            <div role="group">
              <button
                class="btn btn-submit btn-primary float-right"
                v-on:click="checkForm"
                type="submit"
                v-if="this.postBody.itemLists.length > 0"
              >
                Process
              </button>
            </div>
            <br />
          </div>
        </div>
      </form>
      </div>
      
    </div>
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
      isSubmitted: false,

      postBody: {
        locationCode: "",
        requisitionNo: "",
        userId: "",
        department: "",
        requisitionDate: "",
        quantity: "",
        createdOn: "",
        itemLists: [],
        unapprovedItems: [],
      },
      //an array of object from sliced array
      unapproveItem: [
        {
          currentBalance: "",
          itemCode: "",
          requested: "",
          unit: "",
          itemDescription: "",
          quantity: "",
        },
      ],
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
              this.postBody.itemLists = [];
            }
            // window.location.reload();
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
          this.postBody.createdOn = response.data.dateCreated;
          this.postBody.locationCode = response.data.costLocCode;
          this.postBody.itemLists = response.data.itemLists;
        });
    },

    
    getRequisition() {
      axios.get(`/api/requisition/`).then((response) => {
        this.RequisitionList = response.data;
      });
    },

    dismissItem(itemcode) {
      //dismissed items
      let item = this.postBody.itemLists.splice(this.itemCode, 1);
      //object of dismissed items
      this.unapproveItem = {
        itemCode: item[0].itemCode,
        requested: item[0].requested,
        unit: item[0].unit,
        itemDescription: item[0].itemDescription,
        quantity: item[0].quantity,
      };

      //array of dismissed items
      let result = this.postBody.unapprovedItems.push(this.unapproveItem);

      axios
        .patch(`/api/requisition/UnapprovedItems`, this.postBody)
        .then((response) => {
          this.responseMessage = response.data.responseDescription;
          this.canProcess = true;
          if (response.data.responseCode == "200") {
            this.postBody.requisitionNo = "";
            this.postBody.userId = "";
            this.postBody.requisitionDate = "";
            this.postBody.createdOn = "";
            this.postBody.quantity = "";
            this.postBody.locationCode = "";
            this.postBody.unapprovedItems = [];
          }
          // window.location.reload();
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    validate() {
      this.reqblur = true;
      this.qtyblur = true;
      if (this.requisitionNoIsValid /*&& this.quantityIsValid*/) {
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
      this.postBody.itemLists.forEach(function(item) {
        console.log(item.quantity != "" && item.currentBalance > item.quantity);
        /*if(item.quantity < item.currentBalance && item.quantity != "" )*/
        return (
          item.quantity != "" && item.currentBalance > item.quantity
          // this.postBody.itemLists.quantity != "" && parseInt(this.postBody.itemLists.quantity) >= 0
        );
      });
    },
  
  },
};
</script>
