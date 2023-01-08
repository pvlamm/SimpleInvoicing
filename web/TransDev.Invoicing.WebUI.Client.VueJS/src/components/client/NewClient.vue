<template>
    <div :style="{ display: display ? 'block' : 'none' }">
        <div>
            <h3>Create Client</h3>
        </div>
        <div>
            <label>
                Client Name
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
    import { defineComponent } from 'vue';
    import { ContactDto } from '@/models/serviceModels'

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
            console.log('newClient', this.display);
        }
    });

</script>