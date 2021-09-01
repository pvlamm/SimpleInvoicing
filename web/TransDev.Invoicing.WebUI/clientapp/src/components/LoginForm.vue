<template>
  <v-container>
    <v-row>
      <v-col cols="12"
             sm="4">
        <label>
          Username: <input type="text" v-model="login.username" />
        </label>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12"
             sm="4">
        <label>
          Password: <input type="password" v-model="login.password" />
        </label>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12"
             sm="4">
        <v-btn color="primary"
               elevation="2"
               large
               @click="$emit('submit', login)">
          Submit
        </v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { AuthenticateUserQuery } from '../models/serviceModels'

export default {
  name: 'LoginForm',
  emits: ['submit'],
  data: function () {
    return { login: AuthenticateUserQuery }
  },
  methods: {
  }
}
</script>
