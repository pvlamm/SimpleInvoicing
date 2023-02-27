<template>
    <NewClient v-bind:display="newClient" />

    <NewClientModal />
    This is a Client List from Server {{ msg }}

    <Datatable :header="tableHeader" :data="clients">
  <template v-slot:name="{ row: data }">
    {{ data.name }}
  </template>
  <template v-slot:primaryContactName="{ row: data }">
    {{  data.primaryContactName }}
  </template>
  <template v-slot:primaryContactEmail="{ row: data }">
    {{ data.primaryContactEmail }}
  </template>
  <template v-slot:primaryContactPhone="{ row: data }">
    {{ data.primaryContactPhone }}
  </template>
  <template v-slot:billingContactName="{ row: data }">
    {{  data.billingContactName }}
  </template>
  <template v-slot:billingContactEmail="{ row: data }">
    {{ data.billingContactEmail }}
  </template>
  <template v-slot:billingContactPhone="{ row: data }">
    {{ data.billingContactPhone }}
  </template>
</Datatable>

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
                clients: Array<SearchClientDto>(),
                newClient: false,
            };
        },
        setup() {
            const tableHeader = ref([
      {
        columnName: "Name",
        columnLabel: "name",
      },
      {
        columnName: "Primary Contact",
        columnLabel: "primaryContactName",
      },
      {
        columnName: "Primary Email",
        columnLabel: "primaryContactEmail",
      },
      {
        columnName: "Phone",
        columnLabel: "primaryContactPhone",
      },
      {
        columnName: "Billing Contact",
        columnLabel: "billingContactName",
      },
      {
        columnName: "Billing Email",
        columnLabel: "billingContactEmail",
      },
      {
        columnName: "Billing Phone",
        columnLabel: "billingContactPhone",
      },
    ]);

    return {
      tableHeader
    }
        },
        async mounted() {

            let cClient = new ClientClient('https://localhost:5001');
            let clientTest = new SearchClientDto();
            clientTest.name = 'A Name';
            this.newClient = false;
            console.log(clientTest);
            this.clients.push(clientTest);

            let apiResults = await cClient
                .get()
                .then(response => response.clients) as SearchClientDto[];

            this.clients = apiResults;
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