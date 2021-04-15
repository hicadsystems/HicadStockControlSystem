<template>
<div class="btn-link">
    <a 
    @click="onClick"
    :disabled="disabled"
     :class="['solar-button', {'full-width': IsFullWidth}]"
     type="button"
     >
        <slot></slot>
    </a>
</div>
</template>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';
import {Prop} from 'vue-property-decorator';
@Component({
    name: 'SystemLink',
    components: {}
})
export default class SystemLink extends Vue{
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

.solar-button{
    color: lighten($solar-blue, 10%);
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
    width: 100%;
}
</style>