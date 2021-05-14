<template>
  <div>
    <form>
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-4">
              <label for="requisitionNo">Requisition No.</label>
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
                  v-for="(requisition, index) in RequisitionList"
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
              <label for="requisitionBy">Requisition By</label>
              <input
                class="form-control"
                name="requisitionBy "
                readonly="readonly"
                v-model="postBody.requisitionBy"
                placeholder="Requisition By"
              />
            </div>
            <div class="col-4">
              <label for="department">Department</label>
              <input
                class="form-control"
                name="department "
                readonly="readonly"
                v-model="postBody.department"
                placeholder="department"
              />
            </div>
            <div class="col-4">
              <label for="dateAndTime" class="ml-0">Date And Time</label>
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
                    <div role="group">
                      <button
                        class="btn btn-submit btn-primary float-right"
                        @submit="ApproveRequisition(postBody)"
                      >
                        Approve
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
      responseMessage: "",
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

  methods: {
    ApproveRequisition(postBody) {
      alert(this.postBody.itemCode)
      axios
        .put(`/api/requisition/${itemCode}`, this.postBody)
        .then((response) => {
          this.responseMessage = response.data.responseDescription;
          if (response.data.responseCode == "200") {
            this.postBody.itemCode = response.data.itemCode;
            this.postBody.quantity = response.data.quantity;
          }
        })
        .catch((response) => {
          this.errors.push(response);
        });
    },

    getRequisitionApproval() {
      // this.postBody.itemCode="1234"
      // alert(this.postBody.itemCode)
      axios
        .get(`/api/requisition/RequisitionApproval/${this.postBody.requisitionNo}`)
        .then((response) => {
          this.ItemApprovalList = response.data;
          this.postBody.requisitionBy = response.data.requisitionBy;
          this.postBody.department = response.data.department;
          this.postBody.dateAndTime = response.data.dateAndTime;
          this.postBody.itemCode = response.data.requisitionNo;
          this.postBody.itemCode = response.data.itemCode;
          this.postBody.description = response.data.itemDescription;
          this.postBody.quantity = response.data.requested;
        });
    },
    getRequisition() {
      axios.get(`/api/requisition/`).then((response) => {
        this.RequisitionList = response.data;
      });
    },
  },
};
</script>
