<template>
  <div id="nav" class="aside aside-fixed">
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>
  </div>
  <div id="main">
    <router-view />
  </div>
</template>

<style>
  #app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }
  #main {
    padding-top: 119px;
    padding-left: 265px;
    min-width: 0;
    -webkit-box-flex: 1;
    flex: 1 auto;
    -webkit-box-orient: vertical !important;
    flex-direction: column !important;
    box-sizing: border-box;
    background-repeat: no-repeat;
  }
  #nav {
    padding: 30px;
  }

    #nav a {
      font-weight: bold;
      color: #2c3e50;
    }

      #nav a.router-link-exact-active {
        color: #42b983;
      }

  .aside {
    width: 265px;
    background-color: #1e1e2d;
    padding: 0;
    margin: 0;
  }

  .aside-fixed {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    z-index: 98;
  }
</style>
