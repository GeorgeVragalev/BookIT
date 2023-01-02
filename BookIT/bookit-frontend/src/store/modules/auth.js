const state = {
    token: "",
    illegalCombination: false,
    request: {
        started: false,
    }
};

const getters = {};

const actions = {
    login({commit}, {email, password}) {
        commit("SET_REQUEST_START");
        try {
            // sent to backend:
            console.log({email, password})
            commit("SET_REQUEST_END");
        } catch (e) {
            commit("SET_REQUEST_END");

        }
    }
};

const mutators = {};

export default {
    state,
    getters,
    actions,
    mutators,
}