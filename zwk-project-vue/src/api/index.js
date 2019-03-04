import axios from '@/utils/http.js'
import token from '@/api/token/token.js'
import user from '@/api/user/user.js'
import project from '@/api/project/project.js'
import log from '@/api/log/index.js'

const api = {
    token,
    user,
    project,
    log,
    get: function (url, params) {
        return axios.get(url, {
            params: params
        })
    },
    post: function (url, form) {
        return axios.post(url, form);
    }
}

export default api