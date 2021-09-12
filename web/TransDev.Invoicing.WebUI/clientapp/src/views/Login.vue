<template>
  <v-content>
    <h2>Login Authentication Tester</h2>
    <login-form v-bind:login="login" v-on:submit="authenticate($event)"></login-form>
  </v-content>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import LoginForm from '../components/LoginForm.vue'
import { AuthenticationClient, AuthenticateUserQuery } from '../models/serviceModels'
import { PublicClientApplication, InteractionType } from '@azure/msal-browser';
import { MsalInterceptor, MsalModule } from '@azure/msal-angular';

const express = require('express');
const morgan = require('morgan');
const path = require('path');
  //"AzureAd": {
  //  "Instance": "https://localhost:5001/",
  //    "Domain": "qualified.domain.name",
  //      "TenantId": "ff31a505-fd8f-4e72-a4d5-cd61b9cc079d",
  //        "ClientId": "b4dafc40-8606-497e-9880-7364993da30d",

  //          "CallbackPath": "/signin-oidc"
  //}
const msalConfig = {
  auth: {
    clientId: "b4dafc40-8606-497e-9880-7364993da30d",
    authority: "Enter_the_Cloud_Instance_Id_HereEnter_the_Tenant_Info_Here",
    redirectUri: "https://localhost:5001/",
  },
  cache: {
    cacheLocation: "sessionStorage", // This configures where your cache will be stored
    storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
  }
};

// Add here scopes for id token to be used at MS Identity Platform endpoints.
const loginRequest = {
  scopes: ["openid", "profile", "User.Read"]
};

// Add here scopes for access token to be used at MS Graph API endpoints.
const tokenRequest = {
  scopes: ["Mail.Read"]
};

export default defineComponent({
  name: 'Login',
  data: function () {
    return {
      login: {} as AuthenticateUserQuery | null
    }
  },
  components: {
    LoginForm
  },
  mounted: function () {
    this.login = new AuthenticateUserQuery()
    this.login.username = 'test'
    this.login.password = 'testtest'
  },
  methods: {
    async authenticate (tempLogin: AuthenticateUserQuery) {
      this.$data.login = tempLogin
      console.log(tempLogin.username, tempLogin.password)
      const client = new AuthenticationClient()
      const query = new AuthenticateUserQuery()
      query.username = tempLogin.username
      query.password = tempLogin.password
      const result = await client.authenticate(query).then(result => console.log(result)).catch(error => console.log(error))
      console.log(this.$data.login)
      return true
    }
  }
})
</script>
