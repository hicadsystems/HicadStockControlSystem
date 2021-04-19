import Vue from 'vue'
import Vuex from 'vuex'

window.axios=require('axios')
window.Vue=require('vue')

export default new Vuex.Store({
    state:{
        objectToUpdate:null
    },
    getters:{},
    mutations: {
        increment (state) {
          state.count++
        }
      }
})

//Vue.use(Vuex)

// const store = new Vuex.Store({
//   state: {
//     count: 0
//   },
 
//})