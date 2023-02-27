<template>
    <h2> Client List Page</h2>

    <ClientList msg="Passed down successfully" />

</template>
<script lang="ts">
    import { defineComponent } from "vue";
    import ClientList from "@/components/client/ClientList.vue";

    export default defineComponent({
        name: "clients-main",
        components: { ClientList }
    });
</script>