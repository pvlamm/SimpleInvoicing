import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/about',
        name: 'About',
        component: () => import('../views/About.vue')
    },
    {
        path: '/items',
        name: 'Items',
        component: () => import('../views/Item.vue')
    },
    {
        path: '/invoices',
        name: 'Invoices',
        component: () => import('../views/Invoice.vue')
    },
    {
        path: '/login',
        name: 'Login',
        component: () => import('../views/Login.vue')
    }
];
const router = createRouter({
    history: createWebHistory(),
    routes
});
export default router;
//# sourceMappingURL=index.js.map