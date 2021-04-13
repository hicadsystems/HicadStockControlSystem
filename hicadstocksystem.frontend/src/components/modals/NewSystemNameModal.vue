<template>
    <solar-modal>
        <template v-slot:header>
            Systems
        </template>
        <template v-slot:body>
            <ul class="newCustomer">
                <li>
                    <label for="firstName">Company Code</label>
                    <input type="text" id="firstName"/>
                </li>
                <li>
                    <label for="lastName">Company Name</label>
                    <input type="text" id="lastName"/>
                </li>
                <li>
                    <label for="addressLine1">Company Address</label>
                    <input type="text" id="addressLine1"/>
                </li>
                <li>
                    <label for="addressLine2">Telephone No.</label>
                    <input type="text" id="addressLine1"/>
                </li>
                <li>
                    <label for="city">Email</label>
                    <input type="text" id="city"/>
                </li>
                <li>
                    <label for="state">State</label>
                    <input type="text" id="state"/>
                </li>
                <li>
                    <label for="postalCode">Town/City</label>
                    <input type="text" id="postalCode"/>
                </li>
                <li>
                    <label for="country">Installation Date</label>
                    <input type="text" id="country"/>
                </li>
                <li>
                    <label for="country">Serial Number</label>
                    <input type="text" id="country"/>
                </li>
                <li>
                    <label for="country">Stock GL Code</label>
                    <input type="text" id="country"/>
                </li>
            </ul>
        </template>
        <template v-slot:footer>
             <solar-button 
            type="button"
            @button:click="save"
            aria-label="save new customer">
                Save Customer
            </solar-button>

            <solar-button 
            type="button"
            @button:click="close"
            aria-label="Close modal">
                Close
            </solar-button>
        </template>
    </solar-modal>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';
import SolarButton from '@/components/SolarButton.vue';
import SolarModal from '@/components/modals/SolarModal.vue';

@Component({
    name: 'NewSystemNameModal',
    components: { SolarButton, SolarModal}
})

export default class NewSystemNameModal extends Vue{

    close(){
        this.$emit('close');
    }

    save(){
        this.$emit('save:customer', this.customer);
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