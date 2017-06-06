import Vue from 'vue'
import Vuex from 'vuex'
import * as actions from './actions'
import * as getters from './getters'
import common from './modules/common'
import account from './modules/account'
import game from './modules/game'
const debug = process.env.NODE_ENV !== 'production'

Vue.use(Vuex)

// 创建 store 实例
export default new Vuex.Store({
    
    modules: {
        common,
        account,
        game
    },
    strict: debug
})