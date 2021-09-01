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
