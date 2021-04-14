<template>
    <stock-control-modal>
        <template v-slot:header>
            Systems
        </template>
        <template v-slot:body>
            <ul class="newCustomer">
                <li>
                    <label for="firstName">Company Code</label>
                    <input type="text" id="firstName" v-model="stkSystem.companyCode"/>
                </li>
                <li>
                    <label for="lastName">Company Name</label>
                    <input type="text" id="lastName" v-model="stkSystem.companyName"/>
                </li>
                <li>
                    <label for="addressLine1">Company Address</label>
                    <input type="text" id="addressLine1" v-model="stkSystem.companyAddress"/>
                </li>
                <li>
                    <label for="addressLine2">Telephone No.</label>
                    <input type="text" id="addressLine1" v-model="stkSystem.phone"/>
                </li>
                <li>
                    <label for="city">Email</label>
                    <input type="text" id="city" v-model="stkSystem.email"/>
                </li>
                <li>
                    <label for="state">State</label>
                    <input type="text" id="state" v-model="stkSystem.state"/>
                </li>
                <li>
                    <label for="postalCode">Town/City</label>
                    <input type="text" id="postalCode" v-model="stkSystem.town_city"/>
                </li>
                <li>
                    <label for="country">Serial Number</label>
                    <input type="text" id="country" v-model="stkSystem.serialnumber"/>
                </li>
                <li>
                    <label for="country">Stock GL Code</label>
                    <input type="text" id="country" v-model="stkSystem.gLCode"/>
                </li>
            </ul>
        </template>
        <template v-slot:footer>
             <stock-button 
            type="button"
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
import StockControlModal from '@/components/modals/StockControlModal.vue';

@Component({
    name: 'NewSystemNameModal',
    components: { StockButton, StockControlModal}
})

export default class NewSystemModal extends Vue{
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

   
}
</script>

<style lang="scss" scoped>
.newCustomer{
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