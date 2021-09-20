import { createApp } from 'vue';
import { createStore } from 'vuex';
import vuetify from './plugins/vuetify';
import App from './App.vue';
import router from './router';
const store = createStore({
    state() {
        return {
            count: 0
        };
    },
    mutations: {
        increment(state) {
            state.count++;
        }
    }
});
createApp(App)
    .use(store)
    .use(router)
    .use(vuetify, { iconfont: 'mdiSvg' })
    .mount('#app');
//# sourceMappingURL=main.js.map