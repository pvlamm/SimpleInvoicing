import { createApp } from 'vue'
import { DataStore } from './models/DataStore'
import vuetify from './plugins/vuetify'
import App from './App.vue'
import router from './router'

createApp(App)
  .use(new DataStore().getStore())
  .use(router)
  .use(vuetify, { iconfont: 'mdiSvg' })
  .mount('#app')
