<template>
  <div>
    <div v-if="errors" class="has-error">{{ [errors] }}</div>
    <div v-if="responseMessage" class="has-error">{{ responseMessage }}</div>
    <form @submit="checkForm" method="post">
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-3">
              <input
                class="form-control"
                name="companyCode"
                v-model="postBody.itemCode"
                placeholder="Item Code"
              />
            </div>

            <div class="col-6">
              <input
                class="form-control"
                name="companyName "
                v-model="postBody.itemDesc"
                placeholder="Item Description"
              />
            </div>

            <div class="col-3">
              <select
                class="form-control"
                v-model="postBody.class"
                name="class"
                placeholder="class desc"
                required
              >
                <option>
                  --select stock class--
                </option>
                <option
                  v-for="sktClass in ClassList"
                  v-bind:value="sktClass"
                  :key="sktClass"
                >
                  {{ sktClass }}
                </option>
              </select>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6">
              <input
                class="form-control"
                name="storeLoc "
                v-model="postBody.storeLoc"
                placeholder="Store Location"
              />
            </div>

            <div class="col-3">
              <input
                class="form-control"
                name="storerack "
                v-model="postBody.storerack"
                placeholder="Store Rack"
              />
            </div>

            <div class="col-3">
              <input
                class="form-control"
                name="storebin "
                v-model="postBody.storebin"
                placeholder="Store Bin"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-6"></div>
            <div class="col-3">
              <input
                class="form-control"
                name="reOrderLevel"
                v-model="postBody.reOrderLevel"
                placeholder="Reorder Level"
              />
            </div>
            <div class="col-3">
              <input
                class="form-control"
                name="reOrderQty"
                v-model="postBody.reOrderQty"
                placeholder="Reorder Qty"
              />
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-2">
              <input
                class="form-control"
                name="units"
                v-model="postBody.units"
                placeholder="units"
              />
            </div>

            <div class="col-3">
              <input
                class="form-control"
                name="xRef"
                v-model="postBody.xRef"
                placeholder="Cross reference"
              />
            </div>

            <div class="col-3">
              <input
                class="form-control"
                name="xRef"
                v-model="postBody.xRef"
                placeholder="Part No.(404)"
              />
            </div>

            <div class="col-4">
              <select
                class="form-control"
                v-model="postBody.busLine"
                name="class"
                placeholder="class desc"
                required
              >
                <option>
                  --select businessLine--
                </option>
                <option
                  v-for="businessLine in BusinessLineList"
                  v-bind:value="businessLine"
                  :key="businessLine"
                >
                  {{ businessLine }}
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
      DepartmentList: null,
      ItemDescList: null,
      postBody: {
        department: "",
        itemDesc: "",
        currentBal: 0,
        qtyRequired: 0,
        unit: "",
      },
    };
  },
  mounted() {
    this.getBusinessLine();
    this.getStockClass();
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
    //   (this.postBody.itemCode = this.$store.state.objectToUpdate.itemCode),
        (this.postBody.department = this.$store.state.objectToUpdate.department),
        (this.postBody.itemDesc = this.$store.state.objectToUpdate.itemDesc),
        (this.postBody.currentBal = this.$store.state.objectToUpdate.currentBal);
      this.postBody.qtyRequired = this.$store.state.objectToUpdate.qtyRequired;
      this.postBody.unit = this.$store.state.objectToUpdate.unit;
      this.submitorUpdate = "Update";
    },
  },
  methods: {
    checkForm: function(e) {
      if (this.postBody) {
        e.preventDefault();
        this.canProcess = false;
        alert(this.postBody, "i am here");
        this.postPost();
      } else {
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
              this.postBody.department = "";
              this.postBody.itemDesc = "";
              this.postBody.currentBal = "";
              this.postBody.qtyRequired = "";
              this.postBody.unit = "";
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
      axios.get(`/api/itemmaster/getstockclass`).then((response) => {
        this.ClassList = response.data;
      });
    },
    getBusinessLine() {
      axios.get(`/api/itemmaster/getbusinessline`).then((response) => {
        this.BusinessLineList = response.data;
      });
    },
  },
  computed: {
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
