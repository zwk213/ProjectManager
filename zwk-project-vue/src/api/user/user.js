import axios from '@/utils/http.js'

const user = {
    url:{
        get:"/user/get",
        getPage:"/user/getPage",
        add:"/user/add",
        update:"/user/update"
    },
    get: function (params) {
        return axios.get(user.url.get, {
            params: params
        })
    },
    getPage: function (params) {
        return axios.get(user.url.getPage, {
            params: params
        })
    },
    add: function (form) {
        return axios.post(user.url.add, form)
    },
    update: function (form) {
        return axios.post(user.url.update, form)
    }
}

export default user