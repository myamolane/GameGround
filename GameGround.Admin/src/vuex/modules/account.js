import api from 'src/api'
import routes from 'src/router'
import * as types from '../types'
const state={
    message:''
}
const getters = {
    message: state => state.message
}
const mutations = {
    [types.LOGIN_FINISHED](state, response) {
    if (!response.success) {      
      response.callback(response.message)
    } else {      
      localStorage.setItem('token', response.data)
      response.callback()
    }
  },
    [types.TESTED](state, message) {
        state.message=message
    },
    [types.REGISTER_FINISHED](state,response){
        if(!response.success) {
            response.callback(response.message)
        } else {
            response.callback()
        }
    }
}
const actions = {
    login({state,commit}, params){
        commit(types.COMMON_LOADING,true)
        api.login(params.form).then(response=>{
            response.body.callback = params.callback
            commit(types.COMMON_LOADING,false)
            commit(types.LOGIN_FINISHED,response.body)
        })
    },
    register({state,commit}, params){
        console.log("date:"+params.form.birth)
        commit(types.COMMON_LOADING,true)
        api.register(params.form).then(response=>{
            response.body.callback = params.callback
            commit(types.COMMON_LOADING,false)
            commit(types.REGISTER_FINISHED,response.body)
        })
    },
    test({state,commit}){
        commit(types.COMMON_LOADING,true)
        api.test().then(response=>{
            if (response.body && response.body.success)
                commit(types.TESTED,"success")
        })
    }
}
export default{
    state,
    mutations,
    getters,
    actions
}