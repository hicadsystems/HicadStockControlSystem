<template>
  <!-- WRAPPER -->
  <div>
    <div v-if="isFormVisible">
      <form @submit.prevent="checkForm" ref="itemForm" method="post">
        <div class="p-5" id="vertical-form">
          <div class="preview">
            <div class="row">
              <div class="col-3">
                <label for="itemCode" class="mb-1">Item Code</label>
                <input
                  class="form-control"
                  name="itemCode"
                  v-model="postBody.itemCode"
                  v-bind:class="{ 'is-invalid': !itemCodeIsValid && codeblur }"
                  v-on:blur="codeblur = true"
                  :readonly="isEdit"
                />
                <div class="invalid-feedback">
                  <span class="text-danger h5"
                    >Please enter supplier code not more than 15
                    characters</span
                  >
                  <span
                    v-bind:class="[
                      postBody.itemCode ? 'is-valid' : 'is-invalid',
                    ]"
                    >{{ responseMessage }}</span
                  >
                </div>
              </div>
              <div class="col-6">
                <label for="itemDesc" class="mb-1">Item Description</label>
                <input
                  class="form-control"
                  name="itemDesc "
                  v-model="postBody.itemDesc"
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
                  v-model="postBody.class"
                  name="class"
                  :class="{ 'is-invalid': !stkClassIsValid && stkClassblur }"
                  v-on:blur="stkClassblur = true"
                >
                  <option>
                    --select stock class--
                  </option>
                  <option
                    v-for="stockclass in ClassList"
                    :value="stockclass.sktClass"
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
                    >Entry cannot be more than 15 characters</span
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
                  type="number"
                  class="form-control"
                  name="reOrderLevel"
                  v-model="postBody.reOrderLevel"
                  :class="{ 'is-invalid': !reOrderLevelIsValid }"
                />
                <div class="invalid-feedback">
                  <span class="text-danger h5">Invalid Entry</span>
                </div>
              </div>
              <div class="col-3">
                <label for="reOrderQty" class="mb-1">Reorder Quantity</label>
                <input
                  type="number"
                  class="form-control"
                  name="reOrderQty"
                  v-model="postBody.reOrderQty"
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
                  v-model="postBody.partNo"
                  v-bind:class="{ 'is-invalid': !partNoIsValid }"
                  placeholder="Part No.(404)"
                />
                <div class="invalid-feedback">
                  <span class="text-danger h5"
                    >Entry can not be more than 30 characters</span
                  >
                </div>
              </div>

              <div class="col-4">
                <label for="class" class="mb-1">Business Line</label>
                <select
                  v-model="postBody.busLine"
                  v-bind:class="{
                    'form-control': true,
                    'is-invalid': !busLineIsValid,
                  }"
                >
                  <option>
                    --select businessLine--
                  </option>
                  <option
                    v-for="busLine in BusinessLineList"
                    v-bind:value="busLine.businessLine"
                    :key="busLine.businessLine"
                  >
                    {{ busLine.businessDesc }}
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
    <!-- END OF FORM DIV -->

    <!-- NAV DIV -->
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item" aria-current="page">
          <a @click="showForm()"><span class="h4">Create Stock Item</span></a>
        </li>
        <li class="breadcrumb-item active" aria-current="page">
          <span class="h4">Stock Item List</span>
        </li>
      </ol>
    </nav>
    <!--END OF NAV DIV -->

    <!-- TABLE LIST DIV -->
    <table class="table table-striped table-bordered table-hover">
      <thead>
        <tr>
          <th>Item Code</th>
          <th>Item Description</th>
          <th>store Location</th>
          <th>store Rack</th>
          <th>Options</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(status, index) in statusList" :key="index">
          <td>{{ status.itemCode }}</td>
          <td>{{ status.itemDesc }}</td>
          <td>{{ status.storeLoc }}</td>
          <td>{{ status.storerack }}</td>

          <td>
            <button
              type="button"
              class="btn btn-submit btn-primary"
              @click="processRetrieve(status)"
            >
              Edit
            </button>
            <button
              type="button"
              class="btn btn-submit btn-danger"
              @click="processDelete(status.itemCode)"
            >
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>

  <!-- END WRAPPER -->
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
      statusList: null,
      responseMessage: "",
      isFormVisible: false,
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
        partNo: "",
        class: "",
        busLine: "",
        isDeleted: false,
      },

      codeblur: false,
      itemDescblur: false,
      stkClassblur: false,
      busLineblur: false,
      isAvailable: false,
      isEdit: false,
    };
  },
  created() {
    this.$store.state.objectToUpdate = null;
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      this.getAllStockItems();
      this.processDelete();
      // this.processRetrieve();
    },
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
      this.postBody.partNo = this.$store.state.objectToUpdate.partNo;
      this.postBody.class = this.$store.state.objectToUpdate.class;
      this.postBody.busLine = this.$store.state.objectToUpdate.busLine;
      this.submitorUpdate = "Update";
    },
  },
  mounted() {
    this.getAllStockItems();
    this.getBusinessLine();
    this.getStockClass();
  },
  methods: {
    processRetrieve: function(Status) {
      alert(Status);
      this.isFormVisible = true;
      this.isEdit = true;
      this.$store.state.objectToUpdate = Status;
    },
    processDelete: function(itemCode) {
      this.$confirm("Are you sure?").then(() => {
        axios
          .patch(`/api/itemmaster/${itemCode}`)
          .then((response) => {
            if (response.data.responseCode == "200") {
              alert("company successfully deleted");
              this.getAllStockItems();
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      });
      // alert(itemCode);
    },
    getAllStockItems: function() {
      axios
        .get("/api/itemmaster/")
        .then((response) => (this.statusList = response.data));
    },
    showForm() {
      this.isFormVisible = true;
    },

    // Input form methods
    checkForm: function(e) {
      this.validate();
      if (this.valid) {
        this.$confirm("Create Item").then(() => {
          e.preventDefault();
          this.canProcess = false;
          // this.$alert("Submit Form", "Ok", "info");
          this.isFormVisible = false;
          this.postPost();
          // this.$refs.itemForm.reset();
        });
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
              (this.postBody.xRef = ""),
                (this.postBody.partNo = ""),
                (this.postBody.class = "");
              this.postBody.busLine = "";
              this.$store.stateName.objectToUpdate = "create";
            }
            this.getAllStockItems();
            // this.$alert("Submit Form", "Ok", "info");
            window.location.reload();
          })
          .catch((error) => {
            alert(error.response.message);
          });
        // .catch((e) => {
        //   alert(this.errors.push(e));
        // });
      }
      if (this.submitorUpdate == "Update") {
        // alert("Ready to Update");
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
              this.postBody.partNo = "";
              this.postBody.class = "";
              this.postBody.busLine = "";
              this.$store.state.objectToUpdate = "update";
            }
            this.getAllStockItems();
            window.location.reload();
          })
          .catch((error) => {
            alert("something went wrong");
          });
        // .catch((e) => {
        //   this.errors.push(e);
        // });
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
      // this.busLineblur = true;
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
        this.XRefIsValid &&
        this.partNoIsValid
        // this.checkItemCode
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
        this.postBody.itemCode.length <= 15
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
          this.postBody.storeLoc.length <= 15)
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
        (this.postBody.units.length >= 1 && this.postBody.units.length <= 10)
      );
    },
    XRefIsValid() {
      return (
        this.postBody.xRef == "" ||
        (this.postBody.xRef.length >= 1 && this.postBody.xRef.length <= 12)
      );
    },
    partNoIsValid() {
      return (
        this.postBody.partNo == "" ||
        (this.postBody.partNo.length >= 1 && this.postBody.partNo.length <= 30)
      );
    },

    stkClassIsValid() {
      return this.postBody.class != "";
    },

    busLineIsValid() {
      return (
        this.postBody.busLine == "" ||
        (this.postBody.busLine.length >= 1 &&
          this.postBody.busLine.length <= 50)
      );
    },

    reOrderQtyIsValid() {
      var re = /^[+-]?[0-9]+$/;
      return (
        this.postBody.reOrderQty == "" ||
        this.postBody.reOrderQty == null ||
        parseInt(this.postBody.reOrderQty) >= 1
        /*&& this.postBody.reOrderQty.match(re)*/
      );
    },

    reOrderLevelIsValid() {
      var re = /^[+-]?[0-9]+$/;
      return (
        this.postBody.reOrderLevel == "" ||
        this.postBody.reOrderLevel == null ||
        parseInt(this.postBody.reOrderLevel) >= 1
        /*&& this.postBody.reOrderLevel.match(re)*/
      );
    },
    resetForm() {
      this.postBody.itemCode = "";
      this.postBody.itemDesc = "";
      this.postBody.storeLoc = "";
      this.postBody.storerack = "";
      this.postBody.storebin = "";
      this.postBody.reOrderLevel = "";
      this.postBody.reOrderQty = "";
      this.postBody.units = "";
      this.postBody.xRef = "";
      this.postBody.partNo = "";
      this.postBody.class = "";
      this.postBody.busLine = "";
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
        this.postBody.partNo = objecttoedit.partNo;
        this.postBody.class = objecttoedit.class;
        this.postBody.busLine = objecttoedit.busLine;
      }
    },
  },
};
</script>
