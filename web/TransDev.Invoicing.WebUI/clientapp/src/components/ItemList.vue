<template>
  <v-container>
    <v-banner elevation="5">Item List</v-banner>

    <v-row no-gutters>
      <v-col v-for="item in items" :key="item" cols="12" sm="4">
        <v-card outlined tile>
          {{ item.description }}
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { ItemClient, IItemDto, GetActiveItemsQuery } from '../models/serviceModels'

export default defineComponent({
  name: 'ItemList',
  data: () => {
    return {
      items: []
    }
  },
  mounted () {
    initializeData()
  },
  methods: {
    initalizeData: function () {
      const client = new ItemClient()
      const initQuery = new GetActiveItemsQuery()
      initQuery.page = 1
      initQuery.pageSize = 25
      initQuery.searchQuery = ''
      client.searchActiveItems(initQuery).then(results => console.log(results.items))
    },
    loadItems: function (items) {
      // this.data.items = items
      console.log('loadItems')
    }
  }
})

</script>
