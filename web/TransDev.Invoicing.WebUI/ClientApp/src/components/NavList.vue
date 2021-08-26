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
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>
          <v-spacing></v-spacing>
          <v-list-item-content>
            <v-list-item-title v-text="item.text"></v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list-item-group>
    </v-list>
    <v-icon aria-label="My Account" role="img" aria-hidden="false">
      mdiAccount
    </v-icon>
  </v-card>
</template>

<script lang="ts">
import { mdiAccount } from '@mdi/js'

export default {
  data: () => ({
    selectedItem: 1,
    icons: { mdiAccount },
    items: [
      { text: 'Real-Time', icon: 'mdi-clock' },
      { text: 'Audience', icon: 'mdi-account' },
      { text: 'Conversions', icon: 'mdi-flag' }
    ]
  })
}
</script>
