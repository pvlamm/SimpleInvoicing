<template>
    <NewClient v-bind:display="newClient" />
    
    This is a Client List from Server {{ msg }}

    <EasyDataTable
        :headers="headers"
        :items="results"
                   />
    <button type="button" @click="addClient">Add Client</button>

</template>
<script lang="ts">

    import { defineComponent } from 'vue';
    import type { Header } from "vue3-easy-data-table";
    import NewClient from './NewClient.vue';
    import { ClientClient, SearchClientDto } from '@/models/serviceModels'

export default defineComponent({
    name: 'ClientList',
    components: {
        NewClient
    },
    props: {
        msg: String,
    },
    data: function() { 
        return {
            results: Array<SearchClientDto>(),
            newClient: false,
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
        this.newClient = false;
        console.log(this.newClient);
        this.results.push(clientTest);

        let apiResults = await cClient
            .get()
            .then(response => response.clients) as SearchClientDto[];

        this.results = apiResults;
    },
    methods: {
        addClient: function () {
            this.newClient = true;
            console.log(this.newClient);
        }
        }
});

</script>
<style>
</style>