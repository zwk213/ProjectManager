import axios from '@/utils/http.js'

const user = {
    get: function (params) {
        axios.get("/user/get", {
            params: params
        })
    },
    getPage: function (params) {
        axios.get("/user/getPage", {
            params: params
        })
    },
    add: function (form) {
        axios.post("/user/add", form)
    },
    update: function (form) {
        axios.post("/user/update", form)
    }
}

export default user