<template>
  <div>
    <!--<form @submit.prevent="checkForm" method="post">-->
    <form>
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
            <div class="col-6">
              <label for="unit" class="mb-1">Authorised By</label>
              <input
                class="form-control"
                name="requisitionBy "
                readonly="readonly"
                v-model="postBody.approvedBy"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label for="unit" class="mb-1">Requisition By</label>
              <input
                class="form-control"
                name="requisitionBy "
                readonly="readonly"
                v-model="postBody.userId"
              />
            </div>
            <div class="col-6">
              <label for="unit" class="mb-1">Department</label>
              <input
                class="form-control"
                name="department "
                readonly="readonly"
                v-model="postBody.department"
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
                  <th>Quantity Required</th>
                  <th>Quantity Supplied</th>
                  <!--<th>Options</th>-->
                </tr>
              </thead>
              <tbody>
                <tr v-for="item in postBody.itemLists" :key="item.itemcode">
                  <td>
                    <!-- <input
                      class="form-control"
                      name="itemCode "
                      readonly="readonly"
                      v-model="postBody.itemCode"
                    />-->
                    {{ item.itemCode }}
                  </td>
                  <td>
                    <!--<input
                      class="form-control"
                      name="description "
                      readonly="readonly"
                      v-model="postBody.description"
                    />-->
                    {{ item.itemDescription }}
                  </td>
                  <td>
                    <!--<input
                      class="form-control"
                      name="quantity"
                      readonly="readonly"
                      v-model="postBody.quantity"
                    />-->
                    {{ item.requested }}
                  </td>
                  <td>
                    <input
                      type="number"
                      class="form-control"
                      v-model="item.quantity"
                      name="approvedQty"
                      :class="{ 'is-invalid': item.quantity > item.requested }"
                    />
                    <div class="invalid-feedback">
                      <span class="text-danger h5">Invalid Entry</span>
                    </div>
                  </td>
                  <!--<td>
                    <div role="group">
                      <button
                        class="btn btn-submit btn-primary float-right"
                        v-on:click="checkForm"
                        type="button"
                      >
                        Sign
                      </button>
                    </div>
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
        itemCode: "",
        description: "",
        requested: "",
        approvedBy: "",
        createdOn: "",
        quantity: "",
        itemLists: [],
        unit: "",
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
        this.$confirm("Confirm Supply").then(() => {
          axios
            .post(`/api/requisition/issue/`, this.postBody)
            .then((response) => {
              this.responseMessage = response.data.responseDescription;
              this.canProcess = true;
              if (response.data.responseCode == "200") {
                window.open(
                  `/ResponseErrorUI/Index/${response.data}`,
                  "_blank"
                );
                // this.postBody.requisitionNo = "";
                // this.postBody.ItemLists=[];
              } else if (response.data.responseCode != "200") {
                console.log(response.data);
                window.open(`/ResponseErrorUI/Index/${response.data}`,"_blank");
              }
              // window.location.reload();
            })
            .catch((e) => {
              this.errors.push(e);
              //  window.open(`/MonthEndBookClosure/BookClosure/${response.data}`, "_blank")
            });
          this.$alert("Submit Form", "Ok", "info");
        });
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
        this.errors = [];
        this.errors.push("Supply all the required field");
      }
    },

    getRequisitionApproval() {
      axios
        .get(
          `/api/requisition/RequisitionApproval/${this.postBody.requisitionNo}`
        )
        .then((response) => {
          this.ItemApprovalList = response.data;
          this.postBody.userId = response.data.requisitionBy;
          this.postBody.approvedBy = response.data.approvedBy;
          this.postBody.department = response.data.department;
          this.postBody.requisitionDate = response.data.dateAndTime;
          this.postBody.requisitionNo = response.data.requisitionNo;
          this.postBody.createdOn = response.data.dateCreated;
          this.postBody.locationCode = response.data.costLocCode;
          this.postBody.itemLists = response.data.itemLists;
        });
    },
    getRequisition() {
      axios.get(`/api/requisition/GetApprovedRequistion`).then((response) => {
        this.RequisitionList = response.data;
      });
    },
    validate() {
      this.reqblur = true;
      // this.qtyblur = true;
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
      return (
        this.postBody.quantity != "" && parseInt(this.postBody.quantity) >= 0
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
