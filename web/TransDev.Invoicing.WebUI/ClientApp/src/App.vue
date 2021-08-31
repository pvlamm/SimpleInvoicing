<template>
  <v-app>
    <v-navigation-drawer v-model="drawer"
                         app>
      <nav-list v-bind:drawer="drawer"></nav-list>
    </v-navigation-drawer>
    <v-app-bar app>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <v-toolbar-title>Simple Invoicing</v-toolbar-title>
    </v-app-bar>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import NavList from './components/NavList.vue'

export default defineComponent({
  name: 'App',
  components: {
    NavList
  },
  data () {
    return {
      drawer: null
    }
  }
})
</script>
