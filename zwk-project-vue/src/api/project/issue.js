import axios from '@/utils/http.js'

const issue = {
    url:{
        get: "/project/issue/get",
        getPage: "/project/issue/getPage",
        add: "/project/issue/add",
        update: "/project/issue/update",
    },
    get: function (params) {
        return axios.get(issue.url.get, {
            params: params
        })
    },
    getPage: function (params) {
        return axios.get(issue.url.getPage,  {
            params: params
        })
    },
    add: function (form) {
        return axios.post(issue.url.add,  form)
    },
    update: function (form) {
        return axios.post(issue.url.update,  form)
    }
}

export default issue