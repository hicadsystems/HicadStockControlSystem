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
        <th>Company Code</th>
        <th>Company Name</th>
        <th>Company Address</th>
        <th>Telephone No.</th>
        <th>Email</th>
      </tr>
    </table>
    <new-system-modal
      v-if="isNewSystemModalVisible"
      @close="closeModals"
    />
<div class="btn-actions">
     <action-button>
        Edit
      </action-button>
      <action-button>
        delete 
      </action-button>
    </div>

    
  </div>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';
import StockButton from '@/components/StockButton.vue';
import ActionButton from '@/components/ActionButton.vue';
import NewSystemModal from '@/components/modals/NewSystemModal.vue';
@Component({
  name: "System",
  components: {StockButton, NewSystemModal, ActionButton}
})

export default class System extends Vue {
  isNewSystemModalVisible: boolean = false;

  closeModals() {
    this.isNewSystemModalVisible = false;
  }

  showNewSystemModal() {
    this.isNewSystemModalVisible = true;
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

.btn-actions{
    display: flex;
    margin-bottom: 0.8rem;
    float: right;
    align-items: right;
}
</style>
