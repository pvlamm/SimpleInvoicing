<template>
  <div class="home">
    <ItemList page="1" pageSize="25" searchQuery="" />
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import ItemList from '@/components/ItemList.vue'

@Options({
  components: {
    ItemList
  }
})
export default class Items extends Vue {}
</script>
