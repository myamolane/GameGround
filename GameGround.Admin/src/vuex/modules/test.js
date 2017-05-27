import api from 'src/api'
import routes from 'src/router'
import * as types from '../types'
const state={
    message:'message'
}
const getters = {
    message: state => state.message
}
const mutations = {
    [types.TESTED](state,message){
        state.message=message
    }
}
const actions = {
    test({state,commit}){
        commit(types.COMMON_LOADING,true)
        api.test().then(response=>{
            commit(types.COMMON_LOADING,false)
            if (response && response.body && response.body.success){
                commit(types.TESTED,"success")
            }
        })
    }
}

export default{
    state,
    mutations,
    getters,
    actions
}