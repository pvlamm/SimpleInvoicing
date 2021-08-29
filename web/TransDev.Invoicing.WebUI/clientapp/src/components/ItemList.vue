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

<script>
import onMounted from 'vue'
import { ItemClient, IItemDto, GetActiveItemsQuery } from '../models/serviceModels'

export default {
  name: 'Item List',
  data: () => ({
    items: []
  }),
  setup () {
    const client = new ItemClient()
    const initQuery = new GetActiveItemsQuery()
    initQuery.page = 1
    initQuery.pageSize = 25
    initQuery.searchQuery = ''
    loadItems([])
    // console.log(this.$data)
    // client.searchActiveItems(initQuery).then(results => { console.log('test') })
  },
  methods: {
    loadItems: function (items) {
      // this.data.items = items
      console.log('loadItems')
    }
  }
}
</script>
