import axios from '@/utils/http.js'


const linkGroup = {
    url: {
        get: "/project/linkGroup/get",
        getList: "/project/linkGroup/getList",
        getOptions: "/project/linkGroup/getOptions",
        add: "/project/linkGroup/add",
        update: "/project/linkGroup/update",
    },
    get: function (params) {
        return axios.get(linkGroup.url.get, {
            params: params
        })
    },
    getList: function (params) {
        return axios.get(linkGroup.url.getList, {
            params: params
        })
    },
    getOptions: function (params) {
        return axios.get(linkGroup.url.getOptions, {
            params: params
        })
    },
    add: function (form) {
        return axios.post(linkGroup.url.add, form)
    },
    update: function (form) {
        return axios.post(linkGroup.url.update, form)
    }
}

export default linkGroup;