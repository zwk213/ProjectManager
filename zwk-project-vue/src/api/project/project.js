import axios from '@/utils/http.js'

const project = {
    get: function (params) {
        axios.get("/project/get", {
            params: params
        })
    },
    getPage: function (params) {
        axios.get("/project/getPage", {
            params: params
        })
    },
    getPageUrl: "/project/getPage",
    add: function (form) {
        axios.post("/project/add", form)
    },
    update: function (form) {
        axios.post("/project/update", form)
    }
}

export default project