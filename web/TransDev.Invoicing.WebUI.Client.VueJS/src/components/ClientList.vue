<template>
    This is a Client List from Server - {{ msg }}
</template>
<script lang="ts">

    import { defineComponent } from 'vue';
    import { ClientClient, GetActiveClientsQuery } from '@/models/serviceModels';

    export default defineComponent({
        name: 'ClientList',
        props: {
            msg: String,
        },
        data: async () => {
            let client = new ClientClient('https://localhost:5001');
            let clientData = {};

            client.get(new GetActiveClientsQuery()).then(response => clientData = response);

            console.log(clientData);

            return clientData;
        }

    });
</script>
<style>
</style>