import { createStore } from 'vuex';
export class DataStore {
    store;
    constructor() {
        this.store = createStore({
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
    }
    getStore() { return this.store; }
}
//# sourceMappingURL=DataStore.js.map