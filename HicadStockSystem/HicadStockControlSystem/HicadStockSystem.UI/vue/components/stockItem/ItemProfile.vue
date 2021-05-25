<template>
  <div>
    <form @submit.prevent="checkForm" method="post">
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-3">
              <label for="itemCode" class="mb-1">Item Code</label>
              <input
                class="form-control"
                name="itemCode"
                placeholder="Item Code"
                v-model="postBody.itemCode"
                v-bind:class="{ 'is-invalid': !itemCodeIsValid && codeblur }"
                v-on:blur="codeblur = true"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Please enter supplier code not more than 6 characters</span
                >
              </div>
            </div>
            <div class="col-6">
              <label for="itemDesc" class="mb-1">Item Description</label>
              <input
                class="form-control"
                name="itemDesc "
                v-model="postBody.itemDesc"
                placeholder="Item Description"
                :class="{ 'is-invalid': !itemDescIsValid && itemDescblur }"
                v-on:blur="itemDescblur = true"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Please enter Item Description not more than 40
                  characters</span
                >
              </div>
            </div>

            <div class="col-3">
              <label for="class" class="mb-1">Class Description</label>
              <select
                class="form-control"
                v-model="postBody.sktClass"
                name="class"
                :class="{ 'is-invalid': !stkClassIsValid && stkClassblur }"
                v-on:blur="stkClassblur = true"
              >
                <option>
                  --select stock class--
                </option>
                <option
                  v-for="stockclass in ClassList"
                  :value="stockclass.stkClass"
                  :key="stockclass.sktClass"
                >
                  {{ stockclass.sktClass }}
                </option>
              </select>
              <div class="invalid-feedback">
                <span class="text-danger h5">Please select stock class</span>
              </div>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <label for="Store" class="mb-1">Store Location</label>
              <input
                class="form-control"
                name="Store "
                v-model="postBody.storeLoc"
                v-bind:class="{ 'is-invalid': !storeLocIsValid }"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Entry cannot be more than 5 characters</span
                >
              </div>
            </div>

            <div class="col-3">
              <label for="storerack" class="mb-1">Store Rack</label>
              <input
                class="form-control"
                name="storerack "
                v-model="postBody.storerack"
                v-bind:class="{ 'is-invalid': !storeRackIsValid }"
              />
               <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Entry cannot be more than 5 characters</span
                >
              </div>
            </div>

            <div class="col-3">
              <label for="storebin" class="mb-1">Store Bin</label>
              <input
                class="form-control"
                name="storebin "
                v-model="postBody.storebin"
                v-bind:class="{ 'is-invalid': !storeBinIsValid }"
              />
               <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Entry can not be more than 5 characters</span
                >
              </div>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6"></div>
            <div class="col-3">
              <label for="reOrderLevel" class="mb-1">Reorder Level</label>
              <input
                class="form-control"
                name="reOrderLevel"
                v-model="postBody.reOrderLevel"
                placeholder="Reorder Level"
                :class="{ 'is-invalid': !reOrderLevelIsValid }"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5">Invalid Entry</span>
              </div>
            </div>
            <div class="col-3">
              <label for="reOrderQty" class="mb-1">Reorder Quantity</label>
              <input
                class="form-control"
                name="reOrderQty"
                v-model="postBody.reOrderQty"
                placeholder="Reorder Qty"
                :class="{ 'is-invalid': !reOrderQtyIsValid }"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5">invalid entry</span>
              </div>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-2">
              <label for="units" class="mb-1">Unit</label>
              <input
                class="form-control"
                name="units"
                v-model="postBody.units"
                v-bind:class="{ 'is-invalid': !unitIsValid }"
              />
               <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Entry can not be more than 10 characters</span
                >
              </div>
            </div>

            <div class="col-3">
              <label for="xRef" class="mb-1">Cross Reference</label>
              <input
                class="form-control"
                name="xRef"
                v-model="postBody.xRef"
                v-bind:class="{ 'is-invalid': !XRefIsValid }"
              />
               <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Entry can not be more than 12 characters</span
                >
              </div>
            </div>

            <div class="col-3">
              <label for="partNo." class="mb-1">Part No.</label>
              <input
                class="form-control"
                name="partNo."
                v-model="postBody.xRef"
                placeholder="Part No.(404)"
              />
            </div>

            <div class="col-4">
              <label for="class" class="mb-1">Business Line</label>
              <select
                v-model="postBody.busLine"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !busLineIsValid,
                }"
                v-on:bind="busLineblur = true"
              >
                <option>
                  --select businessLine--
                </option>
                <option
                  v-for="businessLine in BusinessLineList"
                  v-bind:value="businessLine.businessLine"
                  :key="businessLine.businessLine"
                >
                  {{ businessLine.businessDesc }}
                </option>
              </select>
            </div>
          </div>
          <br />
          <div v-if="canProcess" role="group">
            <button
              class="btn btn-submit btn-primary float-right"
              v-on:click="checkForm"
              type="submit"
            >
              {{ submitorUpdate }}
            </button>
          </div>
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
      minReorderQty: 1,
      errors: null,
      responseMessage: "",
      submitorUpdate: "Submit",
      canProcess: true,
      ClassList: null,
      BusinessLineList: null,
      postBody: {
        itemCode: "",
        itemDesc: "",
        storeLoc: "",
        storerack: "",
        storebin: "",
        reOrderLevel: "",
        reOrderQty: "",
        units: "",
        xRef: "",
        sktClass: "",
        businessLine: "",
      },
      codeblur: false,
      itemDescblur: false,
      stkClassblur: false,
      busLineblur: false,
    };
  },
  mounted() {
    this.getBusinessLine();
    this.getStockClass();
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      (this.postBody.itemCode = this.$store.state.objectToUpdate.itemCode),
        (this.postBody.itemDesc = this.$store.state.objectToUpdate.itemDesc),
        (this.postBody.storeLoc = this.$store.state.objectToUpdate.storeLoc),
        (this.postBody.storerack = this.$store.state.objectToUpdate.storerack);
      this.postBody.storebin = this.$store.state.objectToUpdate.storebin;
      this.postBody.reOrderLevel = this.$store.state.objectToUpdate.reOrderLevel;
      this.postBody.reOrderQty = this.$store.state.objectToUpdate.reOrderQty;
      this.postBody.units = this.$store.state.objectToUpdate.units;
      this.postBody.xRef = this.$store.state.objectToUpdate.xRef;
      this.postBody.class = this.$store.state.objectToUpdate.sktClass;
      this.postBody.busLine = this.$store.state.objectToUpdate.businessLine;
      this.submitorUpdate = "Update";
    },
  },
  methods: {
    checkForm: function(e) {
      this.validate();
      if (this.valid) {
        // e.preventDefault();
        this.canProcess = false;
        this.$alert("Submit Form", "Ok", "info");

        this.postPost();
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
        this.errors = [];
        this.errors.push("Supply all the required field");
      }
    },

    postPost() {
      if (this.submitorUpdate == "Submit") {
        axios
          .post(`/api/itemmaster/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.itemCode = "";
              this.postBody.itemDesc = "";
              this.postBody.storeLoc = "";
              this.postBody.storerack = "";
              this.postBody.storebin = "";
              this.postBody.reOrderLevel = "";
              this.postBody.reOrderQty = "";
              this.postBody.units = new Date();
              (this.postBody.xRef = ""), (this.postBody.sktClass = "");
              this.postBody.businessLine = "";
              this.$store.stateName.objectToUpdate = "create";
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      }
      if (this.submitorUpdate == "Update") {
        alert("Raedy to Update");
        axios
          .put(`/api/itemmaster/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.submitorUpdate = "Submit";
              this.postBody.itemCode = "";
              this.postBody.itemDesc = "";
              this.postBody.storeLoc = "";
              this.postBody.storerack = "";
              this.postBody.storebin = "";
              this.postBody.reOrderLevel = "";
              this.postBody.reOrderQty = "";
              this.postBody.units = "";
              this.postBody.xRef = "";
              this.postBody.sktClass = "";
              this.postBody.businessLine = "";
              this.$store.state.objectToUpdate = "update";
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      }
    },

    getStockClass() {
      axios.get(`/api/stockclass/`).then((response) => {
        this.ClassList = response.data;
      });
    },

    getBusinessLine() {
      axios.get(`/api/ac_businessline/`).then((response) => {
        this.BusinessLineList = response.data;
      });
    },

    validate() {
      this.codeblur = true;
      this.itemDescblur = true;
      this.stkClassblur = true;
      this.busLineblur = true;
      if (
        this.itemCodeIsValid &&
        this.itemDescIsValid &&
        this.reOrderQtyIsValid &&
        this.reOrderLevelIsValid &&
        this.stkClassIsValid &&
        this.busLineIsValid &&
        this.storeLocIsValid &&
        this.storeRackIsValid &&
        this.storeBinIsValid &&
        this.unitIsValid &&
        this.XRefIsValid
      ) {
        this.valid = true;
      } else {
        this.valid = false;
        return;
      }
    },
  },

  computed: {
    itemCodeIsValid() {
      return (
        this.postBody.itemCode != "" &&
        this.postBody.itemCode.length >= 1 &&
        this.postBody.itemCode.length <= 6
      );
    },

    itemDescIsValid() {
      return (
        this.postBody.itemDesc != "" &&
        this.postBody.itemDesc.length >= 1 &&
        this.postBody.itemDesc.length <= 40
      );
    },
    storeLocIsValid() {
      return (
        this.postBody.storeLoc == "" ||
        (this.postBody.storeLoc.length >= 1 &&
          this.postBody.storeLoc.length <= 5)
      );
    },
    storeRackIsValid() {
      return (
        this.postBody.storerack == "" ||
        (this.postBody.storerack.length >= 1 &&
          this.postBody.storerack.length <= 5)
      );
    },
    storeBinIsValid() {
      return (
        this.postBody.storebin == "" ||
        (this.postBody.storebin.length >= 1 &&
          this.postBody.storebin.length <= 5)
      );
    },
    unitIsValid() {
      return (
        this.postBody.units == "" ||
        (this.postBody.units.length >= 1 &&
          this.postBody.units.length <= 10)
      );
    },
    XRefIsValid() {
      return (
        this.postBody.xRef == "" ||
        (this.postBody.xRef.length >= 1 &&
        this.postBody.xRef.length <= 12)
      );
    },

    stkClassIsValid() {
      return this.postBody.sktClass != "";
    },

    busLineIsValid() {
      return this.postBody.busLine != "";
    },

    reOrderQtyIsValid() {
      return (
        this.postBody.reOrderQty == "" ||
        parseInt(this.postBody.reOrderQty) >= 1
      );
    },

    reOrderLevelIsValid() {
      return (
        this.postBody.reOrderLevel == "" ||
        parseInt(this.postBody.reOrderLevel) >= 1
      );
    },

    setter() {
      let objecttoedit = this.$store.state.objectToUpdate;
      if (objecttoedit.itemCode) {
        this.postBody.itemCode = objecttoedit.itemCode;
        this.postBody.itemDesc = objecttoedit.itemDesc;
        this.postBody.storeLoc = objecttoedit.storeLoc;
        this.postBody.storerack = objecttoedit.storerack;
        this.postBody.storebin = objecttoedit.storebin;
        this.postBody.reOrderLevel = objecttoedit.reOrderLevel;
        this.postBody.reOrderQty = objecttoedit.reOrderQty;
        this.postBody.units = objecttoedit.units;
        this.postBody.xRef = objecttoedit.xRef;
        this.postBody.class = objecttoedit.sktClass;
        this.postBody.busLine = objecttoedit.businessLine;
      }
    },
  },
};
</script>
