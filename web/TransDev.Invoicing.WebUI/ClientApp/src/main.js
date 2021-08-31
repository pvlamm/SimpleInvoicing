import { createApp } from 'vue';
import vuetify from './plugins/vuetify';
import App from './App.vue';
import router from './router';
createApp(App)
    .use(router)
    .use(vuetify, { iconfont: 'mdiSvg' })
    .mount('#app');
//# sourceMappingURL=main.js.map