import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import System from "@/views/System.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: '/system',
    name: 'system',
    component: System
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;




