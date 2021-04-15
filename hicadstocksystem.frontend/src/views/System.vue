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
        <th><span class="inventory-actions">Actions</span></th>
      </tr>
      <tr v-for="stkSystem in stkSystems" :key="stkSystem.companyCode">
        <td>
          <router-link to="/system">
            {{ stkSystem.companyName }}
          </router-link>
        </td>
        <td>
          {{ stkSystem.companyAddress }}
        </td>
        <td>
          {{ stkSystem.state }}
        </td>
        <td>
          <div class="inventory-actions">
            <system-link id="menuInventory" @button:click="showEditSystemModal">
              <i class="lni lni-pencil product-archive">Edit</i>
            </system-link>
            <system-link id="menuInventory" @button:click="goToRoute('/')">
              <i class="lni lni-pencil product-archive">Delete</i>
            </system-link>
          </div>
        </td>
      </tr>
    </table>
    <new-system-modal
      v-if="isNewSystemModalVisible"
      @save:stkSystem="saveNewstkSystem"
      @close="closeModal"
    />
    <edit-system-modal
      v-if="isEditSystemModalVisible"
      @save:stkSystem="saveNewstkSystem"
      @close="closeModal"
    />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { ISktSystem } from "@/types/ISktSystem";
import StockButton from "@/components/StockButton.vue";
import SystemLink from "@/components/SystemLink.vue";
import SystemService from "@/services/system-service";
import NewSystemModal from "@/components/modals/NewSystemModal.vue";
import EditSystemModal from "@/components/modals/EditSystemModal.vue";

const systemService = new SystemService();
@Component({
  name: "System",
  components: {
    StockButton,
    NewSystemModal,
    SystemLink,
    EditSystemModal
  },
})
export default class System extends Vue {
  stkSystems: ISktSystem[] = [];
  isNewSystemModalVisible: boolean = false;
  isEditSystemModalVisible: boolean = false;

  async goToRoute(route: string) {
    await this.$router.push(route);
  }

  closeModal() {
    this.isNewSystemModalVisible = false;
  }

  showNewSystemModal() {
    this.isNewSystemModalVisible = true;
  }

  showEditSystemModal() {
    this.isEditSystemModalVisible = true;
  }

  async saveNewstkSystem(newstkSystem: ISktSystem) {
    await systemService.addSktSystem(newstkSystem);
    this.isNewSystemModalVisible = false;
    await this.fetchData();
  }

  async fetchData() {
    let res = await systemService.getStkSystem();
    this.stkSystems = res;
  }

  async created() {
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

.product-archive {
  cursor: pointer;
  font-weight: bold;
  font-size: 1.2rem;
  color: $solar-red;
}

.inventory-actions{
    display: inline-flex;
    flex-wrap: wrap;
    gap: 8px;
    align-items: right;
}
</style>
