import axios from '@/utils/http.js'
const file = {
    url: {
        get: "/project/file/get",
        getList: "/project/file/getList",
        add: "/project/file/add",
        update: "/project/file/update",
    },
    get: function (params) {
        return axios.get(file.url.get, {
            params: params
        })
    },
    getList: function (params) {
        return axios.get(file.url.getList, {
            params: params
        })
    },
    add: function (form) {
        return axios.post(file.url.add, form)
    },
    update: function (form) {
        return axios.post(file.url.update, form)
    }
}

export default file;