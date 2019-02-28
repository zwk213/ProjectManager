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
            }, {
              path: "edit",
              name: "编辑用户",
              component: () => import('@/views/user/user/edit.vue')
            }]
          }, {
            path: "detail",
            name: "详细信息",
            component: () => import('@/views/user/user/detail.vue')
          }]
        },
        {
          path: "project",
          name: "项目管理",
          component: () => import('@/views/project/router.vue'),
          children: [{
              path: "",
              name: "我的项目",
              component: () => import('@/views/project/project/mine.vue')
            },
            {
              path: "list",
              name: "项目列表",
              component: () => import('@/views/project/project/list.vue'),
              children: [{
                path: "add",
                name: "添加项目",
                component: () => import('@/views/project/project/add.vue')
              }, {
                path: "edit",
                name: "编辑项目",
                component: () => import('@/views/project/project/edit.vue')
              }]
            }, {
              path: "detail",
              name: "项目详情",
              component: () => import('@/views/project/project/detail.vue'),
              children: [{
                path: "",
                name: "基本信息",
                component: () => import('@/views/project/project/main.vue')
              }, {
                path: "schedule",
                name: "时间线",
                component: () => ('@/views/project/schedule.vue')
              }]
            }
          ]
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