<template>

</template>
<style>

</style>
<script>
    import { ClientClient, GetActiveClientsQuery } from "../models/serviceModels"

    let client = new ClientClient("http://localhost");
    let query = new GetActiveClientsQuery();
    let clientList;

    client.get(query).then(response => clientList = response.clients; console.log(clientList); )
</script>