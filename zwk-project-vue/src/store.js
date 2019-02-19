import Vue from 'vue'
import Vuex from 'vuex'
import tokenApi from '@/api/token/token.js'
import tokenJwt from '@/utils/token.js'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    token: "",
    name: "",
    id: "",
    expried: ""
  },
  getters: {
    token(state) {
      return state.token;
    },
    name(state) {
      return state.name;
    },
    id(state) {
      return state.id;
    },
    expried(state) {
      return state.expried;
    },
  },
  mutations: {
    SET_TOKEN(state, token) {
      state.token = token;
    },
    SET_NAME(state, name) {
      state.name = name;
    },
    SET_ID(state, id) {
      state.id = id;
    },
    SET_EXPRIED(state, expried) {
      state.expried = expried;
    },
  },
  actions: {
    //登录
    login({
      commit
    }, loginForm) {
      return new Promise((resolve, reject) => {
        tokenApi.login(loginForm).then(response => {
          //解析token
          var Base64 = require("js-base64").Base64;
          var tokenArray = response.token.split('.');
          var decode = Base64.decode(tokenArray[1]);
          var json = JSON.parse(decode);
          //获取过期时间
          var exp = json.exp;
          //转化为时间格式
          var expDate = new Date(exp * 1000);
          commit('SET_EXPRIED', expDate);
          //赋值姓名
          var name = json.name;
          commit('SET_NAME', name);
          var id = json.id;
          commit('SET_ID', id);
          //设置token
          tokenJwt.setToken(response.token);
          commit('SET_TOKEN', response.token);
          resolve(response);
        }).catch(error => {
          reject(error);
        })
      })
    },
    //刷新
  }
})