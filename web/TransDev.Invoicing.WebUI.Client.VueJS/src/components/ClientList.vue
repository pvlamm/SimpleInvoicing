<template>
    This is a Client List from Server {{ msg }}

    <ul>
        <li v-for="item in results" :key="item.name">{{ item.name }}</li>
    </ul>
</template>
<script lang="ts">

import { defineComponent } from 'vue';
import { ClientClient, SearchClientDto } from '@/models/serviceModels'

export default defineComponent({
    name: 'ClientList',
    props: {
        msg: String,
    },
    data() { 
        return {
            results: Array<SearchClientDto>()
        };
    },
    async mounted() {

        let cClient = new ClientClient('https://localhost:5001');
        let clientTest = new SearchClientDto();
        clientTest.name = 'A Name';

        this.results.push(clientTest);

        let apiResults = await cClient
            .get()
            .then(response => response.clients) as SearchClientDto[];

        this.results = apiResults;
        
    }
});

</script>
<style>

</style>