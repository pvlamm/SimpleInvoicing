<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <ItemList page="1" pageSize="25" searchQuery="" />
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App"/>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import HelloWorld from '@/components/HelloWorld.vue' // @ is an alias to /src
import ItemList from '@/components/ItemList.vue'

@Options({
  components: {
    HelloWorld,
    ItemList
  }
})
export default class Home extends Vue {}
</script>
