import axios from '@/utils/http.js'


const userGroup = {
    url: {
        get: "/project/userGroup/get",
        getList: "/project/userGroup/getList",
        getOptions: "/project/userGroup/getOptions",
        add: "/project/userGroup/add",
        update: "/project/userGroup/update",
    },
    get: function (params) {
        return axios.get(userGroup.url.get, {
            params: params
        })
    },
    getList: function (params) {
        return axios.get(userGroup.url.getList, {
            params: params
        })
    },
    getOptions: function (params) {
        return axios.get(userGroup.url.getOptions, {
            params: params
        })
    },
    add: function (form) {
        return axios.post(userGroup.url.add, form)
    },
    update: function (form) {
        return axios.post(userGroup.url.update, form)
    }
}

export default userGroup;