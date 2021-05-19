<template>
  <div>
    <div v-if="errors" class="has-error">{{ [errors] }}</div>
    <div v-if="responseMessage" class="has-error">{{ responseMessage }}</div>
    <form @submit="checkForm" method="post">
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-4">
              <label for="unit" class="mb-1">Requisition No.</label>
              <select
                class="form-control"
                v-model="postBody.requisitionNo"
                name="requisitionNo"
                placeholder="Requisition No."
                required
                @change="getRequisitionApproval"
              >
                <option>
                  --select Requisition No.--
                </option>
                <option
                  v-for="requisition in RequisitionList"
                  v-bind:value="requisition.requisitionNo"
                  v-bind:key="requisition.requisitionNo"
                >
                  {{ requisition.requisitionNo }}
                </option>
              </select>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-4">
              <label for="unit" class="mb-1">Requisition By</label>
              <input
                class="form-control"
                name="requisitionBy "
                readonly="readonly"
                v-model="postBody.requisitionBy"
                placeholder="Requisition By"
              />
            </div>
            <div class="col-4">
              <label for="unit" class="mb-1">Department</label>
              <input
                class="form-control"
                name="department "
                readonly="readonly"
                v-model="postBody.department"
                placeholder="department"
              />
            </div>
            <div class="col-4">
              <label for="unit" class="mb-1">Date and Time</label>
              <input
                class="form-control"
                name="dateAndTime "
                readonly="readonly"
                v-model="postBody.dateAndTime"
                placeholder="Date And Time"
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
                <tr>
                  <td>
                    <input
                      class="form-control"
                      name="itemCode "
                      readonly="readonly"
                      v-model="postBody.itemCode"
                      placeholder="item code"
                    />
                  </td>
                  <td>
                    <input
                      class="form-control"
                      name="description "
                      readonly="readonly"
                      v-model="postBody.description"
                      placeholder="description"
                    />
                  </td>
                  <td>
                    <input
                      class="form-control"
                      name="quantity"
                      readonly="readonly"
                      v-model="postBody.quantity"
                      placeholder="quantity"
                    />
                  </td>
                  <td>
                    <input
                      class="form-control"
                      v-model="postBody.approvedQty"
                      name="approvedQty"
                    />
                  </td>
                  <td>
                    <div v-if="canProcess" role="group">
                      <button
                        class="btn btn-submit btn-primary float-right"
                        v-on:click="checkForm"
                        type="submit"
                      >
                        {{ submitorUpdate }}
                      </button>
                    </div>
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
      RequisitionList: null,
      ItemApprovalList: null,
      postBody: {
        locationCode: "",
        requisitionNo: "",
        requisitionBy: "",
        department: "",
        dateAndTime: "",
        itemCode: "",
        description: "",
        quantity: "",
        approvedQty: "",
      },
    };
  },
  mounted() {
    this.getRequisition();
    // this.getItemCode();
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      (this.postBody.locationCode = this.$store.state.objectToUpdate.locationCode),
        (this.postBody.itemCode = this.$store.state.objectToUpdate.itemCode),
        (this.postBody.requisitionNo = this.$store.state.objectToUpdate.requisitionNo),
        (this.postBody.requisitionBy = this.$store.state.objectToUpdate.requisitionBy),
        (this.postBody.department = this.$store.state.objectToUpdate.department);
      this.postBody.dateAndTime = this.$store.state.objectToUpdate.dateAndTime;
      this.postBody.description = this.$store.state.objectToUpdate.description;
      this.postBody.quantity = this.$store.state.objectToUpdate.quantity;
      this.postBody.approvedQty = this.$store.state.objectToUpdate.approvedQty;
      this.submitorUpdate = "Update";
    },
  },
  methods: {
    checkForm: function(e) {
      if (this.postBody.itemCode) {
        e.preventDefault();
        this.canProcess = false;
        alert(this.postBody.requisitionNo, "i am here");
        this.postPost();
      } else {
        this.errors = [];
        this.errors.push("Supply all the required field");
      }
    },
    postPost() {
      if (this.submitorUpdate == "Submit") {
        axios
          .post(`/api/issueapprove/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.requisitionNo = "";
              this.postBody.itemCode = "";
              this.postBody.quantity = "";
              this.postBody.description = "";
              this.postBody.approvedQty = "";
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
          .put(`/api/issueapprove/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.submitorUpdate = "Submit";
              this.postBody.requisitionNo = "";
              this.postBody.itemCode = "";
              this.postBody.description = "";
              this.postBody.quantity = 0;
              this.postBody.approvedQty = "";
              this.$store.state.objectToUpdate = "update";
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      }
    },
    getRequisitionApproval() {
      // this.postBody.itemCode="1234"
      // alert(this.postBody.itemCode)
      axios
        .get(
          `/api/issueapprove/RequisitionApproval/${this.postBody.requisitionNo}`
        )
        .then((response) => {
          this.ItemApprovalList = response.data;
          this.postBody.requisitionBy = response.data.requisitionBy;
          this.postBody.department = response.data.department;
          this.postBody.dateAndTime = response.data.dateAndTime;
          this.postBody.requisitionNo = response.data.requisitionNo;
          this.postBody.itemCode = response.data.itemCode;
          this.postBody.description = response.data.itemDescription;
          this.postBody.quantity = response.data.requested;
        });
    },
    getRequisition() {
      axios.get(`/api/issueapprove/GetRequisition`).then((response) => {
        this.RequisitionList = response.data;
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
