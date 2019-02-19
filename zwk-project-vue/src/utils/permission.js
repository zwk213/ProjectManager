import router from '@/router.js'
import token from '@/utils/token.js'
//import store from '@/store'

const whiteList = ['/login']
//路由跳转前
router.beforeEach((to, from, next) => {
    if (token.getToken()) {
        if (to.path === "/login") {
            next({
                path: '/'
            })
        } else {
            next()
        }
    } else {
        if (whiteList.indexOf(to.path) >= 0) {
            next()
        } else {
            next('/login')
        }
    }
});