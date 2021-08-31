<template>
  <ItemList :items="items"></ItemList>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import ItemList from '../components/ItemList.vue'
import { ItemClient, ItemDto, IItemDto, GetActiveItemsQuery, GetActiveItemsResponse } from '../models/serviceModels'

export default defineComponent({
  name: 'Items',
  data: function () {
    return {
      currentPage: 1 as number,
      pageSize: 25 as number,
      searchQuery: '' as string,
      items: [] as IItemDto[] | null
    }
  },
  components: {
    ItemList
  },
  async mounted () {
    await this.loadItems()
  },
  methods: {
    async loadItems () {
      const client = new ItemClient()
      const initQuery = new GetActiveItemsQuery()
      initQuery.page = this.currentPage
      initQuery.pageSize = this.pageSize
      initQuery.searchQuery = this.searchQuery
      const response = await client.searchActiveItems(initQuery)
      this.items = response.items
    }
  }
})
</script>
