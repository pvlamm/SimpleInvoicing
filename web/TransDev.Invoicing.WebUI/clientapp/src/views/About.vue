<template>
  <div class="about">
    <h1>This is an about page</h1>
    <p>
      Current Count {{ count.counter }}
    </p>
  </div>
</template>
<script lang="ts">
import { defineComponent, ref } from 'vue'
import { useStore } from '../store'

export default defineComponent({
  name: 'About',
  setup () {
    const store = useStore()
    const count = ref(store.state)

    return {
      store,
      count
    }
  }
})
</script>
