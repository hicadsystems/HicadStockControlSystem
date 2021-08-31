<template>
  <div>
    <div class="card">
      <div class="card-body">
        <div>
          <div class="p-2" id="vertical-form">
            <div class="preview">
              <div class="row">
                <div class="col-6">
                  <label for="supplier" class="mb-1">Receipt No</label>
                  <select
                    class="form-control"
                    v-model="postBody.docNo"
                    name="supplier"
                    :class="{ 'is-invalid': !receiptIsValid && receiptblur }"
                    v-on:blur="receiptblur = true"
                    @change="(isSelected = true), getStockItem()"
                    :disabled="isSelected"
                  >
                    <option
                      v-for="receipt in receiptList"
                      v-bind:value="receipt"
                      v-bind:key="receipt"
                    >
                      {{ receipt }}
                    </option>
                  </select>
                  <div class="invalid-feedback">
                    <span class="text-danger h5">Please select supplier</span>
                  </div>
                </div>
              </div>
              <br />
              <div class="row">
                <div class="col-6">
                  <label for="itemCode" class="mb-1">Item Code</label>
                  <select
                    class="form-control"
                    v-model="postBody.itemCode"
                    name="itemCode"
                  >
                    <option
                      v-for="item in itemList"
                      v-bind:value="item.itemCode"
                      v-bind:key="item.itemCode"
                    >
                      {{ item.itemCode }}
                    </option>
                  </select>
                  <div class="invalid-feedback">
                    <span class="text-danger h5">Please select Item</span>
                  </div>
                </div>
              </div>
              <br />
              <div class="row">
                <div class="col-6">
                  <p>
                    Partial reversal of receipt is allowed
                    <br />
                    i.e if a receipt has many item on it <br />one item shall be
                    reversed at a time <br />otherwise select the receipt No.
                    and reverse
                  </p>
                </div>
                <div class="col-2">
                  <button
                    class="btn btn-submit btn-primary float-right"
                    v-on:click="checkForm"
                    type="submit"
                  >
                    Reverse
                  </button>
                </div>
              </div>
              <br />
              <!-- <div role="group">
                <button
                  class="btn btn-submit btn-primary float-right"
                  v-on:click="checkForm"
                  type="submit"
                >
                  Reverse
                </button>
              </div>-->
            </div>
          </div>
        </div>
      </div>
    </div>
    <!--End Of Form -->
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
      receiptblur: false,
      responseMessage: "",
      submitorUpdate: "Submit",
      canProcess: true,
      receiptList: null,
      itemList: null,
      isSelected: false,
      postBody: {
        itemCode: "",
        docNo: "",
      },
    };
  },
  mounted() {
    // this.getStockItem();
    this.getReceipt();
  },

  methods: {
    checkForm: function(e) {
      // alert(this.postBody);
      console.log(this.postBody);
      // console.log(this.postBody.locationCode);
      this.$confirm("Confirm Reversal").then(() => {
        axios
          .post(`/api/stockhistory/receiptreversal`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.docNo = "";
              this.postBody.itemCode = "";
            }
            //   window.location.reload();
          })
          .catch((e) => {
            this.errors.push(e);
          });
      });

      // window.location.reload();
    },

    getStockItem() {
      axios
        .get(`/api/stockhistory/getbyreceiptno/${this.postBody.docNo}`)
        .then((response) => {
          this.itemList = response.data;
        });
    },

    getReceipt() {
      axios.get(`/api/stockhistory/receiptsno/`).then((response) => {
        this.receiptList = response.data;
      });
    },

    validate() {
      this.codeblur = true;
      this.receiptblur = true;

      if (this.receiptIsValid) {
        this.valid = true;
      } else {
        this.valid = false;
        return;
      }
    },
  },

  computed: {
    receiptIsValid() {
      return this.postBody.docNo != "" && this.postBody.docNo.length >= 1;
    },
  },
};
</script>
