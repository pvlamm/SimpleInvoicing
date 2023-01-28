<template>
    <div class="modal-window" :style="{ display: display ? 'block' : 'none' }">
        <div>
            <h3>Create Client</h3>
        </div>
        <div class="modal-name-full">
            <label>
                Client Name
            </label>
            <input type="text" v-model="companyName" />
        </div>
        <div class="modal-contacts">
            <div class="modal-contacts-leftcolumn">
                <h3>Primary Contact</h3>
                <div>
                    <div><label>First Name</label><input type="text" v-model="primaryContact.firstName" /></div>
                    <div><label>Last Name</label><input type="text" v-model="primaryContact.lastName" /></div>
                    <div><label>Email Address</label><input type="text" v-model="primaryContact.emailAddress" /></div>
                    <div><label>Phone Number</label><input type="text" v-model="primaryContact.phoneNumber" /></div>
                </div>
            </div>
            <div class="modal-contacts-rightcolumn">
                <h3>Billing Contact</h3>
                <div>
                    <div><label>First Name</label><input type="text" v-model="billingContact.firstName" /></div>
                    <div><label>Last Name</label><input type="text" v-model="billingContact.lastName" /></div>
                    <div><label>Email Address</label><input type="text" v-model="billingContact.emailAddress" /></div>
                    <div><label>Phone Number</label><input type="text" v-model="billingContact.phoneNumber" /></div>
                </div>
            </div>
        </div>
        <div>
            <button @click="save()">Create</button>
            <button @click="cancel()">Cancel</button>
        </div>
    </div>
</template>
<style>

    .modal-window {
        z-index: 1000;
        position: relative;
        float: left;
        left: auto;
        width: 600px;
        color: #000;
        border: 1px solid black;
        text-align: left;
    }

    .modal-window label {
        display: inline-block;
        min-width: 120px;
        padding-top: 5px;
    }

    .modal-contacts{
        width: 100%;
    }

    .modal-contacts-leftcolumn{
        width: 50%;
        display: inline-block;
    }

    .modal-contacts-rightcolumn{
        width: 50%;
        display: inline-block;
    }

</style>
<script lang="ts">
    import { defineComponent } from 'vue';
    import { ContactDto, ClientClient, CreateClientCommand } from '@/models/serviceModels'

    export default defineComponent({
        name: 'NewClient',
        props: {
            display: Boolean,
        },
        data: function () {
            return {
                companyName: "",
                primaryContact: new ContactDto(),
                billingContact: new ContactDto()
            }
        },
        mounted: function () {
        },
        methods: {
            save: async function () {
                let cClient = new ClientClient('https://localhost:5001');
                let command = new CreateClientCommand();

                command.companyName = this.companyName;
                command.primaryContact = this.primaryContact;
                command.billingContact = this.billingContact;

                cClient
                    .post(command)
                    .then((resp: any) => {
                        console.log(resp);
                        // Bubble Up Successful Save
                    })
                    .catch((err: any) => {
                        console.log(err);
                        // Bullble Up Error event
                    });
            },
            cancel: function () {
                this.companyName = '';
                this.primaryContact = new ContactDto();
                this.billingContact = new ContactDto();
                // Bubble Event to Parent to modify props/display to false and kill
            }
        }
    });

</script>