<template>
  <v-container>
    <v-row no-gutters>
      <v-col cols="3" sm="4">Item Code</v-col>
      <v-col cols="3" sm="4">Description</v-col>
      <v-col cols="3" sm="4">Price</v-col>
    </v-row>
    <v-row v-for="item in items" :key="item"  no-gutters>
      <v-col cols="3" sm="4">
        {{ item.code }}
      </v-col>
      <v-col cols="3" sm="4">
        {{ item.description }}
      </v-col>
      <v-col cols="3" sm="4" right>
        {{ formatMoney(item.price) }}
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">

export default {
  name: 'ItemList',
  props: {
    items: {
      type: Array
    }
  },
  methods: {
    formatMoney (pennies: number) {
      const formatter = new Intl.NumberFormat('en-US',
        {
          style: 'currency',
          currency: 'USD',
          minimumFractionDigits: 2
        })
      return formatter.format(pennies * 0.01)
    }
  }
}
</script>
