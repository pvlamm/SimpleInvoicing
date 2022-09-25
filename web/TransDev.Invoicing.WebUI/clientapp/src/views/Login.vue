<template>
  <v-content>
    <h2>Login Authentication Tester</h2>
    <button @click="login()">Login</button>
  </v-content>
</template>

<script lang="ts">
import * as Msal from '@azure/msal-browser'
import { useStore, MutationTypes, ActionTypes } from '../store'
import { Axios } from 'Axios'

// if using cdn version, 'Msal' will be available in the global scope

export default {
  setup () {
    const store = useStore()
    const login = () => {
      const msalConfig = {
        auth: {
          clientId: '95c79525-a212-4846-a401-f9981880d96d',
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
          store.commit(MutationTypes.SET_TOKEN, response.accessToken)
          //Axios.defaults.headers.common.Authorization = response.accessToken
        })
        .catch(err => {
          // handle error
          console.log(err)
        })
    }
    return {
      store,
      login
    }
  }
}
</script>
