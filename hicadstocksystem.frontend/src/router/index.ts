import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import NewSystem from "@/views/NewSystem.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: '/newsystem',
    name: 'newsystem',
    component: NewSystem
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;




