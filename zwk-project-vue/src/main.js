import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

//引入iview
import iView from 'iview';
import 'iview/dist/styles/iview.css';
Vue.use(iView);

Vue.config.productionTip = false;

//导入样式
import '@/css/basic.css'
import '@/css/extend.css'
import '@/css/theme.css'

//初始化执行权限判定
import "@/utils/permission.js"

//导入api
import api from '@/api/index.js'
Vue.prototype.$api = api;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
