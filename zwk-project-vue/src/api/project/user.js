import axios from '@/utils/http.js'


const user = {
    url: {
        get: "/project/user/get",
        getList: "/project/user/getList",
        getOptions: "/project/user/getOptions",
        add: "/project/user/add",
        update: "/project/user/update",
    },
    get: function (params) {
        return axios.get(user.url.get, {
            params: params
        })
    },
    getList: function (params) {
        return axios.get(user.url.getList, {
            params: params
        })
    },
    getOptions: function (params) {
        return axios.get(user.url.getOptions, {
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

export default user;