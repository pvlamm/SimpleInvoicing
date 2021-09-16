<template>
  <v-content>
    <h2>Login Authentication Tester</h2>
  </v-content>
</template>

<script lang="ts">
import * as Msal from 'msal'
// if using cdn version, 'Msal' will be available in the global scope

const msalConfig = {
  auth: {
    clientId: 'b4dafc40-8606-497e-9880-7364993da30d',
    authority: 'https://login.microsoftonline.com/common'
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

export default {

}
</script>
