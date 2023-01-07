<template>
    <img alt="Vue logo" src="./assets/logo.png">
    <ClientList msg=' - Rock On - ' />
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App" />
    <NewClient />
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import ClientList from './components/ClientList.vue';
    import NewClient from './components/client/NewClient.vue';

    export default defineComponent({
        name: 'App',
        components: {
            ClientList,
            NewClient,
        }
    });
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>
