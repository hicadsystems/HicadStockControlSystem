<template>
  <div class="inventoryContainer">
    <h1 id="inventoryTitle">Inventory Dashboard</h1>
    <hr />

    <div class="inventory-actions">
      <solar-button @button:click="showNewProductModal" id="addnewBtn">
        Add New Item
      </solar-button>
    </div>

    <table id="InventoryTable" class="table">
      <tr>
        <th>Item</th>
        <th>Quantity On-hand</th>
        <th>Unit Price</th>
        <th>Taxable</th>
        <th>Delete</th>
      </tr>
    </table>
    <new-product-modal
      v-if="isNewProductVisible"
      @save:product="saveNewProduct"
      @close="closeModals"
    />
  </div>
</template>

<script lang="ts">
import SolarButton from '@/components/SolarButton.vue';
import NewStockItemModal from '@/components/modals/NewProductModal.vue';
@Component({
  name: "Inventory",
  components: {SolarButton, NewStockItemModal}
})
export default class Inventory extends Vue {

  closeModals() {
    this.isShipmentVisible = false;
    this.isNewProductVisible = false;
  }

  showNewProductModal() {
    this.isNewProductVisible = true;
  }

  showShipmentModal() {
    this.isShipmentVisible = true;
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

.inventory-actions {
  display: flex;
  margin-bottom: 0.8rem;
}

.product-archive {
  cursor: pointer;
  font-weight: bold;
  font-size: 1.2rem;
  color: $solar-red;
}
</style>
