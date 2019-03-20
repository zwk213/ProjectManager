import axios from '@/utils/http.js'


const schedule = {
    url: {
        get: "/project/schedule/get",
        getList: "/project/schedule/getList",
        getOptions: "/project/schedule/getOptions",
        add: "/project/schedule/add",
        update: "/project/schedule/update",
    },
    get: function (params) {
        return axios.get(schedule.url.get, {
            params: params
        })
    },
    getList: function (params) {
        return axios.get(schedule.url.getList, {
            params: params
        })
    },
    getOptions: function (params) {
        return axios.get(schedule.url.getOptions, {
            params: params
        })
    },
    add: function (form) {
        return axios.post(schedule.url.add, form)
    },
    update: function (form) {
        return axios.post(schedule.url.update, form)
    }
}

export default schedule;