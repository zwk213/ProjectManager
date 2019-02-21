import axios from '@/utils/http.js'

const project = {
    url: {
        get: "/project/get",
        getPage: "/project/getPage",
        add: "/project/add",
        update: "/project/update",
    },
    get: function (params) {
        return axios.get(project.url.get, {
            params: params
        })
    },
    getPage: function (params) {
        return axios.get(project.url.getPage, {
            params: params
        })
    },
    add: function (form) {
        return axios.post(project.url.add, form)
    },
    update: function (form) {
        return axios.post(project.url.update, form)
    }
}

export default project