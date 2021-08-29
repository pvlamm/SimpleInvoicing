<template>
  <invoice-list></invoice-list>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import InvoiceList from '../components/InvoiceList.vue'

export default defineComponent({
  name: 'Invoices',

  components: {
    InvoiceList
  }
})
</script>
