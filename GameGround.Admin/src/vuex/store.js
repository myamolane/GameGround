import Vue from 'vue'
import Vuex from 'vuex'
import test from './modules/test'
import common from './modules/common'
const debug = process.env.NODE_ENV !== 'production'

Vue.use(Vuex)

// 创建 store 实例
export default new Vuex.Store({
    actions,
    getters,
    modules: {
        test,
        common
    },
    strict: debug
})