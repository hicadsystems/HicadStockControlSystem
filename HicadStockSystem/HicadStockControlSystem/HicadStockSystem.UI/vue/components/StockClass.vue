<template>
  <div>
    <form @submit.prevent="checkForm" method="post">
      <div class="p-5" id="vertical-form">
        <div class="preview">
          <div class="row">
            <div class="col-3">
              <label for="supplierCode" class="mb-1">Stock Class</label>
              <input
                class="form-control"
                name="supplierCode"
                v-model="postBody.sktClass"
                v-bind:class="{
                  'form-control': true,
                  'is-invalid': !stockClassIsValid && codeblur,
                }"
                v-on:blur="codeblur = true"
              />
              <div class="invalid-feedback">
                <span class="text-danger h5"
                  >Please enter supplier code not more than 15 characters</span
                >
              </div>
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
      errors: null,
      responseMessage: "",
      submitorUpdate: "Submit",
      canProcess: true,
      stateList: null,
      postBody: {
        sktClass: "",
      },
      valid: false,
      codeblur: false,
    };
  },
  watch: {
    "$store.state.objectToUpdate": function(newVal, oldVal) {
      (this.postBody.sktClass = this.$store.state.objectToUpdate.sktClass),
      this.submitorUpdate = "Update";
    },
  },
  methods: {
    checkForm: function(e) {
      this.validate();
      if (this.valid) {
        e.preventDefault();
        this.canProcess = false;
        this.postPost();
        this.$alert("Submit Form", "Ok", "info");
      } else {
        this.$alert("Please Fill Highlighted Fields", "missing", "error");
        this.errors = [];
        this.errors.push("Supply all the required field");
      }
    },
    postPost() {
      if (this.submitorUpdate == "Submit") {
        axios
          .post(`/api/stockclass/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.postBody.sktClass = "";
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
          .put(`/api/stockclass/`, this.postBody)
          .then((response) => {
            this.responseMessage = response.data.responseDescription;
            this.canProcess = true;
            if (response.data.responseCode == "200") {
              this.submitorUpdate = "Submit";
              this.postBody.sktClass = "";
              this.$store.state.objectToUpdate = "update";
            }
          })
          .catch((e) => {
            this.errors.push(e);
          });
      }
    },
    validate() {
      this.codeblur = true;
      if (
        this.stockClassIsValid 
      ) {
        this.valid = true;
      } else {
        this.valid = false;
        return;
      }
    },
  },

  computed: {
    stockClassIsValid() {
      return (
        this.postBody.sktClass != "" &&
        this.postBody.sktClass.length >= 1 &&
        this.postBody.sktClass.length <= 15
      );
    },

    setter() {
      let objecttoedit = this.$store.state.objectToUpdate;
      if (objecttoedit.supplierCode) {
        this.postBody.sktClass = objecttoedit.sktClass;
      }
    },
  },
};
</script>
