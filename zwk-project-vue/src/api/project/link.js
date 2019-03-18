import axios from '@/utils/http.js'

const link = {
    url: {
        get: "/project/link/get",
        getList: "/project/link/getList",
        add: "/project/link/add",
        update: "/project/link/update",
    },
    get: function (params) {
        return axios.get(link.url.get, {
            params: params
        })
    },
    getList: function (params) {
        return axios.get(link.url.getList, {
            params: params
        })
    },
    add: function (form) {
        return axios.post(link.url.add, form)
    },
    update: function (form) {
        return axios.post(link.url.update, form)
    }
}

export default link;