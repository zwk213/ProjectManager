import axios from '@/utils/http.js'

const token = {
    login: function (form) {
        return axios.post("/token/login", form)
    },
    refresh:function(){
        return axios.post("/token/refresh")
    }
}

export default token