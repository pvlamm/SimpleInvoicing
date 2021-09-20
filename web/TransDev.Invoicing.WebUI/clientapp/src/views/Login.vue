<template>
  <v-content>
    <h2>Login Authentication Tester</h2>
    <button @click="login()">Login</button>
  </v-content>
</template>

<script lang="ts">
import * as Msal from '@azure/msal-browser'
// if using cdn version, 'Msal' will be available in the global scope

export default {
  methods: {
    login () {
      const msalConfig = {
        auth: {
          clientId: '',
          authority: 'https://login.microsoftonline.com/ff31a505-fd8f-4e72-a4d5-cd61b9cc079d',
          redirectUri: 'https://localhost:5001'
        },
        cache: {
          cacheLocation: 'sessionStorage',
          storeAuthStateInCookie: false
        },
        system: {
          loggerOptions: {
            piiLoggingEnabled: false
          },
          windowHashTimeout: 60000,
          iframeHashTimeout: 6000,
          loadFrameTimeout: 0
        }
      }

      const msalInstance = new Msal.PublicClientApplication(msalConfig)

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
    }
  }
}
</script>
