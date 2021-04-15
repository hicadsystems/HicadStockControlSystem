<template>
    <stock-control-modal>
        <template v-slot:header>
            Systems
        </template>
        <template v-slot:body>
         <ul class="newCustomer" v-for="stkSystems in stkSystem" :key="system.companyCode">
                <li>
                    <label for="companyCode">Company Code</label>
                    <input type="text" id="companyCode" readonly="readonly" 
                     v-model="stkSystem.companyCode"/>
                </li>
                <li>
                    <label for="companyName">Company Name</label>
                    <input type="text" id="companyName" readonly="readonly" 
                     v-model="stkSystem.companyName"/>
                </li>
                <li>
                    <label for="companyAddress">Company Address</label>
                    <input type="text" id="companyAddress" 
                     v-model="stkSystem.companyAddress"/>
                </li>
                <li>
                    <label for="phone">Telephone No.</label>
                    <input type="text" id="phone" 
                    v-model="stkSystem.phone"/>
                </li>
                <li>
                    <label for="email">Email</label>
                    <input type="email" id="email" 
                    v-model="stkSystem.email"/>
                </li>
                <li>
                    <label for="state">State</label>
                    <input type="text" id="state" 
                     v-model="stkSystem.state"/>
                </li>
                <li>
                    <label for="city">Town/City</label>
                    <input type="text" id="city" 
                     v-model="stkSystem.town_city"/>
                </li>
                <li>
                    <label for="serialNumber">Serial Number</label>
                    <input type="text" id="serialNumber" 
                     v-model="stkSystem.serialnumber"/>
                </li>
                <li>
                    <label for="gLCode">Stock GL Code</label>
                    <input type="text" id="gLCode" 
                     v-model="stkSystem.gLCode"/>
                </li>
            </ul>
           
        </template>
        <template v-slot:footer>
            <stock-button
             
            type="button"
            @button:click="save"
            aria-label="save new system">
                Save System
            </stock-button>
            <stock-button 
            type="button"
            @button:click="close"
            aria-label="Close modal">
                Close
            </stock-button>
        </template>
    </stock-control-modal>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';
import StockButton from '@/components/StockButton.vue';
import { ISktSystem } from "@/types/ISktSystem";
import { IGetStkSystem } from "@/types/IGetStkSystem";
import StockControlModal from '@/components/modals/StockControlModal.vue';


const systemService = new SystemService();
@Component({
    name: 'EditSystemModal',
    components: { StockButton, StockControlModal}
})

export default class EditSystemModal extends Vue{

// getStkSystem: IGetStkSystem[]=[]

stkSystem: ISktSystem={
    companyCode: "",
    companyName: "",
    companyAddress: "",
    phone: "",
    email: "",
    state: "",
    town_city: "",
    serialnumber: "",
    gLCode: ""
}
    close(){
        this.$emit('close');
    }

     save(){
        this.$emit('save:stkSystem', this.stkSystem);
    }

    //getBycompCode
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
.editSystem{
    display: flex;
    flex-wrap: wrap;
    list-style: none;
    padding: 0;
    margin: 0;

    input{
        width: 80%;
        height: 1.8rem;
        margin: 0.8rem;
        margin-right: 2rem;
        font-size: 1.1rem;
        line-height: 1.3rem;
        padding: 0.2rem;
        color: #555;
    }

    label{
        font-weight: bold;
        margin: 0.8rem;
        display: block;
    }
}
</style>