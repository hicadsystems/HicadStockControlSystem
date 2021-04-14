<template>
<div class="btn-link">

    <button 
    @click="onClick"
    :disabled="disabled"
     :class="['action-button', {'full-width': IsFullWidth}]"
     type="button">
        <slot></slot>
    </button>
</div>
</template>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';
import {Prop} from 'vue-property-decorator';

@Component({
    name: 'ActionButton',
    components: {}
})
export default class ActionButton extends Vue{
    @Prop({required: false, type: String})
    link?: string;

    @Prop({required: false, type: Boolean, default: false})
    IsFullWidth?: boolean;

    @Prop({required: false, type: Boolean, default: false})
    disabled?: boolean;

    onClick(){
        this.$emit('button:click');
    }
}
</script>

<style scoped lang="scss">

@import "@/scss/global.scss";

.action-button{
    background: lighten($solar-red, 10%);
    color: white;
    padding: 0.1rem 0.1rem;
    transition: background-color 0.5s;
    margin: 0.1rem 0.2rem;
    display: inline-block;
    cursor: pointer;
    font-size: 1rem;
    min-width: 100px;
    border: none;
    border-bottom: 2px solid darken($solar-blue, 20%);
    border-radius: 3px;

    &:hover{
    background: lighten($solar-blue, 20%);
    transition: background-color 0.5s;
}

&:disabled{
    background: lighten($solar-blue, 15%);
    border-bottom: 2px solid lighten($solar-blue, 20%);
}

&:active{
    background:$solar-yellow;
    border-bottom: 2px solid lighten($solar-yellow, 20%);
}

}


.full-width{
    display: block;
    width: 20%;
}
</style>