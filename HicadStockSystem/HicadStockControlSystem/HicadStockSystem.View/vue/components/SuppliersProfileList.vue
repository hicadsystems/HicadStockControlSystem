<template>
    	<!-- WRAPPER -->
    <div>
        
       <table class="table table-striped table-bordered table-hover">
            <thead>
                <tr>
                 <th>Supplier Code</th>
                 <th>Supplier name</th>
                 <th>Supplier Address</th>
                 <th>Phone Number</th>
                 <th></th>
                </tr>
            </thead>
             <tbody>  
                    <tr v-for="(status,index) in statusList" :key="index" >
                       
                         <td>{{status.supplierCode }}</td>
                         <td>{{status.name }}</td>
                         <td>{{status.address }}</td>
                         <td>{{status.phone}}</td>
                        <td>
                        <button type="button" class="btn btn-submit btn-primary" @click="processRetrieve(status)">Edit</button>
                        <button type="button" class="btn btn-submit btn-primary" @click="processDelete(status.supplierCode)">Delete</button>
                        </td>
                        
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
                    responseMessage:''
                };
            },
        created() {
            this.$store.state.objectToUpdate = null;
        },
    watch:{
         '$store.state.objectToUpdate':function (newVal, oldVal) {
            this.getAllSuppliers();
            this.processDelete();
        }
    },
    mounted () {
        this.getAllSuppliers();
     },
     methods: {
        processRetrieve : function (Status) {
           // alert(Status)
            this.$store.state.objectToUpdate = Status;
         },
         processDelete: function (supplierCode) {
             //alert(companyCode);
             axios.delete(`/api/supplier${supplierCode}`)
                 .then(response => {
                     if (response.data.responseCode == '200') {
                         alert("Supplier successfully deleted");
                         this.getAllSuppliers();
                     }
                 }).catch(e => {
                            this.errors.push(e)
                        });

         },
         getAllSuppliers: function () {
             axios
            .get('/api/supplier')
            .then(response => (this.statusList = response.data))
         }
    }
    
};
</script>