<template>
<div> Hello Item List Vue</div>
  <div v-for="item in items" :key="item.id">
    <label>{{ item.code }}</label>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import { ItemDto, IItemDto, ItemClient, GetActiveItemsQuery } from '../models/serviceModels'

@Options({
  props: {
    pageSize: Number,
    page: Number,
    searchQuery: String
  }
})

export default class ItemList extends Vue {
  pageSize!: number
  page!: number
  searchQuery!: string
  items!: IItemDto[]
  mounted () {
    const query = new GetActiveItemsQuery()
    query.page = 1
    query.pageSize = 25
    query.searchQuery = ''
    new ItemClient().searchActiveItems(query).then(result => { this.setItems(result.items) })
  }

  setItems (items: ItemDto[] | any) {
    console.log(items)
    this.items = items
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  h3 {
    margin: 40px 0 0;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    display: inline-block;
    margin: 0 10px;
  }

  a {
    color: #42b983;
  }
</style>
