<template>
  <item-list></item-list>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import ItemList from '../components/ItemList.vue'

export default defineComponent({
  name: 'Items',

  components: {
    ItemList
  }
})
</script>
