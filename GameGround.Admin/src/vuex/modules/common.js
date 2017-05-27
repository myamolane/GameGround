import * as types from '../types'
import api from 'src/api'
import routes from 'src/router'

const state={
    loading:false
}

const mutations = {
    [types.COMMON_LOADING](state, loading) {
        state.loading = loading
    }
}
const getters = {
    loading : state => state.loading
}
export default{
    state,
    mutations,
    getters
}