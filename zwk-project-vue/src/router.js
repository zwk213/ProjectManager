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
        //用户
        {
          path: "user",
          name: "用户管理",
          component: () => import('@/views/user/router.vue'),
          children: [{
            path: "list",
            name: "用户列表",
            component: () => import('@/views/user/user/list.vue'),
            children: [{
              path: "add",
              name: "添加用户",
              component: () => import('@/views/user/user/add.vue')
            },{
              path: "edit",
              name: "编辑用户",
              component: () => import('@/views/user/user/edit.vue')
            }]
          }, {
            path:"detail",
            name:"详细信息",
            component:()=>import('@/views/user/user/detail.vue')
          },
          {
            path:"me",
            name:"个人信息",
            component:()=>import('@/views/user/user/me.vue')
          }]
        }
      ]
    },
    {
      path: "/login",
      name: "登录",
      component: () => import('@/views/home/login')
    },
  ]
})