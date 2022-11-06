<template>
    This is a Client List from Server
</template>
<script>
    import { ClientClient } from '@/models/serviceModels';


    let cClient = new ClientClient('https://localhost:5001');
    cClient.get({}).then(result => console.log(result));
</script>
<style>

</style>