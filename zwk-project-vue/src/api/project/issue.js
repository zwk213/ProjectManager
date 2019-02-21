import axios from '@/utils/http.js'

const issue = {
    get: function (params) {
        axios.get("/project/issue/get", {
            params: params
        })
    },
    getPage: function (params) {
        axios.get("/project/issue/getPage", {
            params: params
        })
    },
    getPageUrl: "/project/issue/getPage",
    add: function (form) {
        axios.post("/project/issue/add", form)
    },
    update: function (form) {
        axios.post("/project/issue/update", form)
    }
}

export default issue