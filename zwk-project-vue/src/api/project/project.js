import axios from '@/utils/http.js'
import issue from '@/api/project/issue.js'
import schedule from '@/api/project/schedule.js'
import link from '@/api/project/link.js'
import linkGroup from '@/api/project/linkGroup.js'
import user from '@/api/project/user.js'
import userGroup from '@/api/project/userGroup.js'
import file from '@/api/project/file.js'

const project = {
    issue,
    schedule,
    link,
    linkGroup,
    user,
    userGroup,
    file,
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