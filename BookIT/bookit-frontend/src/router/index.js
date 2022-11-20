import Vue from "vue";
import VueRouter from "vue-router";
import MiawComponent from "@/components/MiawComponent";
import HelloWorld from "@/components/HelloWorld";

Vue.use(VueRouter);

const routes = [
    {
        path: '/',
        component: HelloWorld
    },
    {
        path: '/miaw',
        component: MiawComponent
    },
];

const router = new VueRouter({
    routes,
    mode: 'history'
})

export default router;
