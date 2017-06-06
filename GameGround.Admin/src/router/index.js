import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      redirect: {
        path: '/GameGround'
      }
    },
    {
      path: '/GameGround',
      name: '游戏广场',
      component: resolve => require(['../views/GameGround'],resolve),
      children: [
        {
          path: '/GameGround/Home',
          name: '首页',
          component: resolve => require(['../views/Home'],resolve)
        },
        {
          path: '/GameGround/Collect',
          name: "收藏夹",
          component: resolve => require(['../views/Collect'],resolve)
        },
        {
          path:'/GameGround/AddGame',
          name:'添加游戏',
          component: resolve => require(['../views/AddGame'],resolve)
        },
      ]
    },
    {
      path: '/Login',
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
