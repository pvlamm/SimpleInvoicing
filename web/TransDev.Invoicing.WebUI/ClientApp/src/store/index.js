import { createStore, createLogger } from 'vuex';
// set state
const state = {
    counter: 0, userSession: { token: 'rosco', firstName: '', lastName: '' }
};
// mutations and action enums
export var MutationTypes;
(function (MutationTypes) {
    MutationTypes["INC_COUNTER"] = "SET_COUNTER";
})(MutationTypes || (MutationTypes = {}));
export var ActionTypes;
(function (ActionTypes) {
    ActionTypes["INC_COUNTER"] = "SET_COUNTER";
})(ActionTypes || (ActionTypes = {}));
// define mutations
const mutations = {
    [MutationTypes.INC_COUNTER](state, payload) {
        state.counter += payload;
    }
};
export const actions = {
    [ActionTypes.INC_COUNTER]({ commit }, payload) {
        commit(MutationTypes.INC_COUNTER, payload);
    }
};
// getters
export const getters = {
    doubleCounter: state => {
        console.log('state', state.counter);
        return state.counter * 2;
    }
};
export const store = createStore({
    state,
    mutations,
    actions,
    getters,
    plugins: [createLogger()]
});
export function useStore() {
    return store;
}
//# sourceMappingURL=index.js.map