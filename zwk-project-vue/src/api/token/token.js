import axios from '@/utils/http.js'

const token = {
    url:{
        login:"/token/login",
        refresh:"/token/refresh"
    },
    login: function (form) {
        return axios.post(token.url.login, form)
    },
    refresh:function(){
        return axios.post(token.url.refresh)
    }
}

export default token