// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import babelpolyfill from 'babel-polyfill'
import ElementUI from 'element-ui'
import './assets/theme/theme-darkyellow/index.css'
import Vuex from 'vuex'
import VueRouter from 'vue-router'
import './assets/css/common.scss'
import store from './vuex/store'

Vue.config.productionTip = false

Vue.use(ElementUI)
Vue.use(router)
Vue.use(Vuex)
/* eslint-disable no-new */

router.beforeEach((to, from, next) => {
  //NProgress.start();
  if (to.path == '/Login') {
    localStorage.removeItem('token');
  }
  let token = localStorage.getItem('token')
  if (to.path == '/Login'){
    next()
  }else if (!token) {
    next({ path: '/Login' })
  } else {
    next()
  }
})


new Vue({
  el: '#app',
  router,
  store,
  template: '<App/>',
  components: { App }
})

