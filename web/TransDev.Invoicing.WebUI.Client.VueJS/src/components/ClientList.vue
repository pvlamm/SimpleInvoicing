<template>
    This is a Client List from Server {{ msg }}

    <EasyDataTable
        :headers="headers"
        :items="results"
                   />
</template>
<script lang="ts">

    import { defineComponent } from 'vue';
    import type { Header } from "vue3-easy-data-table";
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
    setup() {
        const headers: Header[] = [
            { text: 'CLIENT', value: 'name' },
            { text: 'EMAIL', value: 'primaryContactEmail' },
            { text: 'PHONE', value: 'primaryContactPhone' }
        ];

        return { headers };
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