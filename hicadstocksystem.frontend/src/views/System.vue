<template>
  <div class="systemContainer">
    <h1 id="systemTitle">System Dashboard</h1>
    <hr />

    <div class="system-actions">
      <stock-button @button:click="showNewSystemModal" id="addnewBtn">
        Add New System
      </stock-button>
    </div>

    <table id="SystemTable" class="table">
      <tr>
        <th>Company Name</th>
        <th>Company Address</th>
        <th>State</th>
      </tr>
      <tr v-for="stkSystem in stkSystems" :key="stkSystem.companyCode">
        <td>
          {{ stkSystem.companyName }}
        </td>
        <td>
          {{ stkSystem.state }}
        </td>
        <td>
          {{ stkSystem.companyAddress }}
        </td>
      </tr>
    </table>
    <new-system-modal v-if="isNewSystemModalVisible" @close="closeModals" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { ISktSystem } from "@/types/ISktSystem";
import StockButton from "@/components/StockButton.vue";
import SystemService from "@/services/system-service";
import ActionButton from "@/components/ActionButton.vue";
import DeleteButton from "@/components/DeleteButton.vue";
import NewSystemModal from "@/components/modals/NewSystemModal.vue";

const systemService = new SystemService();
@Component({
  name: "System",
  components: { StockButton, NewSystemModal, ActionButton, DeleteButton },
})
export default class System extends Vue {
  stkSystems: ISktSystem[] = [];
  isNewSystemModalVisible: boolean = false;

  closeModals() {
    this.isNewSystemModalVisible = false;
  }

  showNewSystemModal() {
    this.isNewSystemModalVisible = true;
  }

    async fetchData(){
        let res = await systemService.getStkSystem();
        this.stkSystems = res;
    }

   async created(){
        await this.fetchData();
    }
}
</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";

.green {
  font-weight: bold;
  color: $solar-green;
}

.yellow {
  font-weight: bold;
  color: $solar-yellow;
}
.red {
  font-weight: bold;
  color: $solar-red;
}

.system-actions {
  display: flex;
  margin-bottom: 0.8rem;
}

.product-archive {
  cursor: pointer;
  font-weight: bold;
  font-size: 1.2rem;
  color: $solar-red;
}

.btn-actions {
  display: flex;
  margin-bottom: 0.8rem;
  float: right;
  align-items: right;
}
</style>
