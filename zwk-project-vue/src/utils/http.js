import axios from 'axios'
import store from '@/store.js'
import token from '@/utils/token.js'

var instance = axios.create({
    baseURL: "http://148.70.62.73:9000/api",
    timeout: 30000,
});

//白名单页面，不拦截
const whitelistPaths = '/token/login;/token/refresh'
//请求拦截
instance.interceptors.request.use(
    config=>{
        //需要拦截的页面
        if (whitelistPaths.indexOf(config.url) < 0) {
            //添加token
            config.headers.common['Authorization'] = "Bearer " + token.getToken();
        }
        return config;
    },
    error => {
        console.log(error);
    }
)
//响应拦截
instance.interceptors.response.use(
    response => {
        //默认响应格式
        //{ success:true , code:0000 , message:'' , data:{} }
        var data = response.data;
        if (data.success) {
            return data;
        } else {
            alert(data.message);
            return;
        }
    },
    error => {
        console.log(error);
    }
)

export default instance