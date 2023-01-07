<template>
    <div>
        <div>
            <h3>Create Client</h3>
        </div>
        <div>
            <label>
                Name
            </label>
            <input type="text" v-model="companyName" />
        </div>
        <div>
            <h3>Primary Contact</h3>
            <div>
                <div><label>First Name</label><input type="text" v-model="primaryContact.firstName" /></div>
                <div><label>Last Name</label><input type="text" v-model="primaryContact.lastName" /></div>
                <div><label>Email Address</label><input type="text" v-model="primaryContact.emailAddress" /></div>
                <div><label>Phone Number</label><input type="text" v-model="primaryContact.phoneNumber" /></div>
            </div>
        </div>
        <div>
            <h3>Billing Contact</h3>
            <div>
                <div><label>First Name</label><input type="text" v-model="billingContact.firstName" /></div>
                <div><label>Last Name</label><input type="text" v-model="billingContact.lastName" /></div>
                <div><label>Email Address</label><input type="text" v-model="billingContact.emailAddress" /></div>
                <div><label>Phone Number</label><input type="text" v-model="billingContact.phoneNumber" /></div>
            </div>
        </div>
    </div>
</template>
<style>

</style>
<script lang="ts">
    /*
     *    firstName?: string | null;
    middleName?: string | null;
    lastName?: string | null;
    emailAddress?: string | null;
    phoneNumber?: string | null;
     * */
    import { defineComponent } from 'vue';
    import { ContactDto } from '@/models/serviceModels'

    export default defineComponent({
        name: 'NewClient',
        data: function() {
            return {
                companyName: "",
                primaryContact: new ContactDto(),
                billingContact: new ContactDto()
                }
        },
        mounted: async function() {

            this.companyName = "this is just a test to see if I can reference it";
            this.billingContact.firstName = "billingTEST";
            this.primaryContact.firstName = "primaryTEST";
        }
    });

</script>