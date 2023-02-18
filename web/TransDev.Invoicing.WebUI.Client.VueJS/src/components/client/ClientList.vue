<template>
    <NewClient v-bind:display="newClient" />

    <NewClientModal />
    This is a Client List from Server {{ msg }}

<DataTable :header="tableHeader"
           :data="tableData"
           :items-per-page="5"
           :items-per-page-dropdown-enabled="false">
    <template v-slot:name="{ row: client }">
        {{ client.name }}
    </template>
    <template v-slot:primaryContactName="{ row: client }">
        <span>
            {{ client.primaryContactName }}
        </span>
    </template>
    <template v-slot:billingContactName="{ row: client }">
        <span>
            {{ client.billingContactName }}
        </span>
    </template>
</DataTable>
    <button
        type="button"
        class="btn btn-primary er fs-6 px-8 py-4"
        data-bs-toggle="modal"
        :data-bs-target="`#new_client_modal`"
    >
        Add Client
    </button>
</template>
<script lang="ts">

    import { defineComponent, ref } from 'vue';
    import Datatable from "@/components/kt-datatable/KTDataTable.vue";
    import NewClientModal from '@/components/modals/forms/NewClientModal.vue';
    // new_client_modal
    //C:\dev\github.com\pvlamm\SimpleInvoicing\web\TransDev.Invoicing.WebUI.Client.VueJS\src\components\modals\forms\NewClientModal.vue
    import { ClientClient, SearchClientDto } from '@/models/serviceModels'

    export default defineComponent({
        name: 'ClientList',
        components: {
            NewClientModal,
            Datatable
        },
        props: {
            msg: String,
        },
        data: function () {
            return {
                results: Array<SearchClientDto>(),
                newClient: false,
            };
        },
        setup() {
            const tableHeader = ref([
                {
                    columnName: "Name",
                    columnLabel: "name",
                    sortEnabled: true,
                },
                {
                    columnName: "Primary Contact",
                    columnLabel: "primaryContactEmail",
                    sortEnabled: false,
                },
                {
                    columnName: "Billing Contact",
                    columnLabel: "billingContactName",
                    sortEnabled: false,
                },
            ]);
            const tableData = ref([
                {
                    name: "Test A",
                    primaryContactName: "Alpha",
                    billingContactName: "BAlpha"
                    }]);
            return { tableHeader, tableData };
        },
        async mounted() {

            let cClient = new ClientClient('https://localhost:5001');
            let clientTest = new SearchClientDto();
            clientTest.name = 'A Name';
            this.newClient = false;
            console.log(clientTest);
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