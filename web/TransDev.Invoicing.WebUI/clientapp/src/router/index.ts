import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import Home from '../views/Home.vue'

const routes: Array<RouteRecordRaw> = [
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
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
