import Vue from "vue";
import VueRouter from "vue-router";
import MiawComponent from "@/components/MiawComponent";
import AuthComponent from "@/components/auth/AuthComponent";
import LogIn from "@/components/auth/LogIn";
import RegisterComponent from "@/components/auth/RegisterComponent";
import ForgotPasswordComponent from "@/components/auth/ForgotPasswordComponent";
import ResetPasswordComponent from "@/components/auth/ResetPasswordComponent";

Vue.use(VueRouter);

const routes = [
    {
        path: '/',
        component: AuthComponent,
        redirect: { name: 'Login' },
        children: [
            {
                path: '/login',
                name: 'Login',
                component: LogIn
            },
            {
                path: '/register',
                name: 'Register',
                component: RegisterComponent
            },
            {
                path: '/forgot-password',
                name: 'ForgotPassword',
                component: ForgotPasswordComponent
            },
            {
                path: '/reset-password',
                name: 'ResetPassword',
                component: ResetPasswordComponent
            },
        ]
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
