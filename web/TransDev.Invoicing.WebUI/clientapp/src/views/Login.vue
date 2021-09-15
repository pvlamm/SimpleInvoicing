<template>
  <v-content>
    <h2>Login Authentication Tester</h2>
    <login-form v-bind:login="login" v-on:submit="authenticate($event)"></login-form>
  </v-content>
</template>

<script lang="ts">
import * as Msal from 'msal'
// if using cdn version, 'Msal' will be available in the global scope

const msalConfig = {
  auth: {
    clientId: 'b4dafc40-8606-497e-9880-7364993da30d'
  }
}

const msalInstance = new Msal.UserAgentApplication(msalConfig)

var loginRequest = {
  scopes: ['user.read', 'mail.send'] // optional Array<string>
}

msalInstance.loginPopup(loginRequest)
  .then(response => {
    // handle response
    console.log(response)
  })
  .catch(err => {
    // handle error
    console.log(err)
  })

</script>
