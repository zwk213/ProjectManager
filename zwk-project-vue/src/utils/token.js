import Cookies from 'js-cookie'

const TokenKey = 'oauth-Token'

const Token = {
    getToken:function() {
        return Cookies.get(TokenKey)
    },
    setToken:function(token) {
        return Cookies.set(TokenKey, token)
    },
    removeToken:function() {
        return Cookies.remove(TokenKey)
    }
}

export default Token