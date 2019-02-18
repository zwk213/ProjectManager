import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [{
      path: '/',
      name: "后台管理",
      component: () => import('@/views/layout/layout'),
      children: [
        //首页
        {
          path: '',
          name: "首页",
          component: () => import('@/views/home/index')
        },
      ]
    },
    {
      path: "/login",
      name: "登录",
      component: () => import('@/views/home/login')
    },
  ]
})