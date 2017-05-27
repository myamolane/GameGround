import Vue from 'vue'
import Router from 'vue-router'
import Hello from 'src/components/Hello'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/GameGround',
      name: '游戏广场',
      component: resolve => require(['../views/Home'],resolve)
    },
    {
      path: '/',
      name: '登录',
      component: resolve => require(['../views/Login'], resolve),
    },
    {
      path: '/NiceToMeetU',
      name: '注册',
      component: resolve => require(['../views/Register'], resolve)
    }
  ]
})
