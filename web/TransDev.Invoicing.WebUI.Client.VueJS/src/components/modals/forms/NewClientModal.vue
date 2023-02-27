<template>
    <!--begin::Modal - Share & Earn-->
    <div class="modal fade"
         id="new_client_modal"
         tabindex="-1"
         aria-hidden="true">
        <!--begin::Modal dialog-->
        <div class="modal-dialog modal-dialog-centered mw-800px">
            <!--begin::Modal content-->
            <div class="modal-content">
                <!--begin::Modal header-->
                <div class="modal-header pb-0 border-0 justify-content-end">
                    <!--begin::Close-->
                    <div class="btn btn-sm btn-icon btn-active-color-primary"
                         data-bs-dismiss="modal">
                        <span class="svg-icon svg-icon-1">
                            <inline-svg :src="getAssetPath('media/icons/duotune/arrows/arr061.svg')" />
                        </span>
                    </div>
                    <!--end::Close-->
                </div>
                <!--begin::Modal header-->
                <!--begin::Modal body-->
                <div class="modal-body scroll-y pt-0 pb-15">
                    <!--begin::Wrapper-->
                    <div class="mw-lg-600px mx-auto">
                        <!--begin::Heading-->
                        <div class="mb-13 text-center">
                            <!--begin::Title-->
                            <h1 class="mb-3">Create new Client Entry</h1>
                            <!--end::Title-->
                            <!--begin::Description-->
                            <div class="text-gray-400 fw-semobold fs-5">
                                New Client creation modal, ##TESTING##
                            </div>
                            <!--end::Description-->
                        </div>
                        <!--end::Heading-->
                        <!--begin::Input group-->
                        <div class="mb-10">
                            <!--begin::Title-->
                            <h4 class="fs-5 fw-semobold text-gray-800">
                                New Client Entry Form
                            </h4>
                            <!--end::Title-->
                            <!--begin::Title-->
                            <div class="d-flex">
                                <div class="modal-contacts">
                                    <div class="modal-contacts-leftcolumn">
                                        <div class="mb-10 fv-row fv-plugins-icon-container">
                                            <!--begin::Label-->
                                            <label class="required form-label mb-3">Client Name</label>
                                            <!--end::Label-->
                                            <!--begin::Input-->
                                            <input type="text" class="form-control form-control-lg form-control-solid" v-model="companyName" placeholder="company name">
                                            <!--end::Input-->
                                            <table>
                                                <tr>
                                                    <td>
                                                        <h4 class="fs-5 fw-semobold text-gray-800">Primary Contact</h4>
                                                        <div>
                                                            <div>
                                                                <label class="required form-label mb-3">First Name</label>
                                                                <input type="text" class="form-control form-control-lg form-control-solid" v-model="primaryContact.firstName" />
                                                            </div>
                                                            <div>
                                                                <label class="required form-label mb-3">Last Name</label>
                                                                <input type="text" class="form-control form-control-lg form-control-solid" v-model="primaryContact.lastName" />
                                                            </div>
                                                            <div>
                                                                <label class="required form-label mb-3">Email Address</label>
                                                                <input type="text" class="form-control form-control-lg form-control-solid" v-model="primaryContact.emailAddress" />
                                                            </div>
                                                            <div>
                                                                <label class="required form-label mb-3">Phone Number</label>
                                                                <input type="text" class="form-control form-control-lg form-control-solid" v-model="primaryContact.phoneNumber" />
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <h4 class="fs-5 fw-semobold text-gray-800">Billing Contact</h4>
                                                        <div>
                                                            <div>
                                                                <label class="required form-label mb-3">First Name</label>
                                                                <input type="text" class="form-control form-control-lg form-control-solid" v-model="billingContact.firstName" />
                                                            </div>
                                                            <div>
                                                                <label class="required form-label mb-3">Last Name</label>
                                                                <input type="text" class="form-control form-control-lg form-control-solid" v-model="billingContact.lastName" />
                                                            </div>
                                                            <div>
                                                                <label class="required form-label mb-3">Email Address</label>
                                                                <input type="text" class="form-control form-control-lg form-control-solid" v-model="billingContact.emailAddress" />
                                                            </div>
                                                            <div>
                                                                <label class="required form-label mb-3">Phone Number</label>
                                                                <input type="text" class="form-control form-control-lg form-control-solid" v-model="billingContact.phoneNumber" />
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>

                                    </div>
                                    <div class="fv-plugins-message-container invalid-feedback"></div>
                                </div>
                            </div>
                            <!--end::Title-->
                        </div>
                        <!--end::Input group-->
                        <!--begin::Input group-->
                        <div class="d-flex align-items-center mt-10">

                            <!--begin::Save-->
                            <button type="button" class="btn btn-primary er fs-6 px-8 py-4" v-on:click="save()">Save</button>
                            <!--end::Save-->
                        </div>
                        <!--end::Input group-->
                    </div>
                    <!--end::Wrapper-->
                </div>
                <!--end::Modal body-->
            </div>
            <!--end::Modal content-->
        </div>
        <!--end::Modal dialog-->
    </div>
    <!--end::Modal - Share & Earn-->
</template>

<script lang="ts">
    import { defineComponent } from "vue";
    import { ContactDto, ClientClient, CreateClientCommand } from '@/models/serviceModels'
    import { getAssetPath } from "@/core/helpers/assets";

    export default {
        name: 'NewClientModalForm',
        components: {},
        data: function () {
            return {
                companyName: "",
                primaryContact: new ContactDto(),
                billingContact: new ContactDto()
            }
        },
        setup() {

            return {
                getAssetPath
            };
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
            }
        }
    }
</script>

<style>
</style>