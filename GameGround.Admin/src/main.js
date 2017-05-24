// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import babelpolyfill from 'babel-polyfill'
import ElementUI from 'element-ui'
import './assets/theme/theme-darkyellow/index.css'
import Vuex from 'vuex'
import './assets/css/common.scss'
Vue.config.productionTip = false

Vue.use(ElementUI)
Vue.use(router)
Vue.use(Vuex)
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App }
})
