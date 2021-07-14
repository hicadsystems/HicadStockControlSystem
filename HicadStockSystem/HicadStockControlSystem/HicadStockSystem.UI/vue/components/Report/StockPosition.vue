<template>
  <!-- WRAPPER -->
  <div>
    <table class="table table-striped table-responsive-md">
      <thead>
        <tr>
          <th>Item Code</th>
          <th>Item Description</th>
          <th>Part No.</th>
          <th>Open Balance</th>
          <th>Total Receipt</th>
          <th>Total Issues/Returns</th>
          <th>Current Balance</th>
          <th>Price</th>
          <th>Value</th>
          <!--<th>Options</th>-->
        </tr>
      </thead>
      <tbody>
       <tr v-for="status  in statusList" :key="status.itemCode">
          <td>{{ status.itemCode }}</td>
          <td>{{ status.itemDesc }}</td>
          <td>{{ status.partNo }}</td>
          <td>{{ status.openBalance }}</td>
          <td>{{ status.receipts }}</td>
          <td>{{ status.issues }}</td>
          <td>{{ status.currentBalance }}</td>
          <td>{{ status.price }}</td>
          <td>{{ status.value }}</td>
         
        </tr>
      </tbody>
    </table>
  </div>

  <!-- END WRAPPER -->
</template>
<script>
export default {
  data() {
    return {
      statusList: null,
      responseMessage: '',
    };
  },
  
  mounted() {
    this.getStockPosition();
  },
  methods: {
    getStockPosition: function() {
      axios
        .get('/api/stockmaster/stockposition/')
        .then((response) => (this.statusList = response.data));
    },
  },
};
</script>
