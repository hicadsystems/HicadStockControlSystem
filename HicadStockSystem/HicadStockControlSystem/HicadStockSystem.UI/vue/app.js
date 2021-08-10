window.axios=require('axios');
window.Vue=require('vue');
import store from './store'
import Vuelidate from 'vuelidate';
import VueSimpleAlert from "vue-simple-alert";
import jsPDF  from "jspdf";
import html2canvas from 'html2canvas';

Vue.use(jsPDF);
Vue.use(html2canvas);

Vue.use(VueSimpleAlert);

Vue.use(Vuelidate);

const files = require.context('./', true, /\.vue$/i)
files.keys().map(key => Vue.component(key.split('/').pop().split('.')[0], files(key).default))

const app = new Vue({
    el: "#app",
    store
});