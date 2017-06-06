import api from 'src/api'
import routes from 'src/router'
import * as types from '../types'
const state = {
    games:[],
    total:0
}
const getters = {
    games : state=>state.games,
    totalGames: state=>state.total
}
const mutations = {
    [types.GAME_SEARCHED](state,data){
        state.games=data
    }
}
const actions = {
    addGame({state,commit},form){
        commit(types.COMMON_LOADING,true)
        api.addGame(form).then(response=>{
            commit(types.COMMON_LOADING,false)
        })
    },
    searchGames({state,commit},filter){
        commit(types.COMMON_LOADING,true)
        api.searchGames(filter).then(response=>{
            commit(types.COMMON_LOADING,false)
            commit(types.GAME_SEARCHED,response.data.data)
        })
    },
    get({state,commit}){
        commit(types.COMMON_LOADING,true)
        api.getId().then(reponse => {
            commit(types.COMMON_LOADING,false)
            
        })
    },
    makeRecord({state,commit}){
        commit(types.COMMON_LOADING,true)
        api.addRecord(record).then(response =>{
            commit(types.COMMON_LOADING,false)
        })
    }
}

export default{
    state,
    mutations,
    getters,
    actions
}