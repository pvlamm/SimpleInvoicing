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

export default {
  name: 'ItemList',
  props: {
    items: {
      type: Array
    }
  }
}
</script>
