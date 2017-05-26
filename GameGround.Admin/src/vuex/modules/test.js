import api from 'src/api'
import routes from 'src/routes'
import * as types from '../types'
const state={
    message:''
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
        alert("actions")
        api.test().then(response=>{
            if (response && response.body && response.body.success){
                message='success';
            }
        })
    },
    test1({state,commit}){
        //alert("actions")
        commit(types.COMMON_LOADING,true)
        api.firstTest().then(response=>{
            commit(types.COMMON_LOADING,false)
            if (response && response.body && response.body.success){
                commit(types.TESTED,"success")
            }
        })
    }
}