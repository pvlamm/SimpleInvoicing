<template>
  <v-card class="mx-auto"
          max-width="300"
          tile>
    <v-list rounded>
      <v-subheader>REPORTS</v-subheader>
      <v-list-item-group v-model="selectedItem"
                         color="primary">
        <v-list-item v-for="(item, i) in items"
                     :key="i">
          <router-link :to="item.to" @click="drawer = !drawer">
            <v-list-item-icon>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title v-text="item.text"></v-list-item-title>
            </v-list-item-content>
          </router-link>
        </v-list-item>
      </v-list-item-group>
    </v-list>
  </v-card>
</template>

<script lang="ts">

export default {
  prop: { drawer: false },
  data: () => ({
    selectedItem: 1,
    items: [
      { text: 'Items', icon: 'mdi-clipboard', to: '/' },
      { text: 'Invoices', icon: 'mdi-equal-box', to: '/about' },
      { text: 'Conversions', icon: 'mdi-flag', to: '/' }
    ]
  }),
  methods: {
    closeDrawer () {
      return false
    }
  }
}
</script>
