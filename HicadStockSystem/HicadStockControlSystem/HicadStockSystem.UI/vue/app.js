window.axios=require('axios');
window.Vue=require('vue');
import store from './store'
import Vuelidate from 'vuelidate';
import VueSimpleAlert from "vue-simple-alert";

Vue.use(VueSimpleAlert);

Vue.use(Vuelidate);

const files = require.context('./', true, /\.vue$/i)
files.keys().map(key => Vue.component(key.split('/').pop().split('.')[0], files(key).default))

const app = new Vue({
    el: "#app",
    store
});