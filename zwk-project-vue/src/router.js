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
          redirect: "/user/list",
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
          redirect: "/project/list",
          children: [{
              path: "mine",
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
            },
            {
              path: "detail",
              name: "项目详情",
              component: () => import('@/views/project/project/detail.vue'),
              children: [{
                path: "index",
                name: "基本信息",
                component: () => import('@/views/project/project/main.vue')
              }, {
                path: "schedule",
                name: "时间线",
                component: () => import('@/views/project/schedule/list.vue')
              }, {
                path: "issue",
                name: "问题",
                component: () => import('@/views/project/issue/list.vue')
              }, {
                path: "user",
                name: "参与人员",
                component: () => import('@/views/project/user/list.vue')
              }, {
                path: "link",
                name: "地址",
                component: () => import('@/views/project/link/list.vue')
              }, {
                path: "file",
                name: "文件",
                component: () => import('@/views/project/file/index.vue')
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