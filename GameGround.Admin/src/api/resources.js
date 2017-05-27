import Vue from 'vue'
import VueResource from 'vue-resource'

Vue.use(VueResource)
//enable crooOrigin
Vue.http.options.crossOrigin = true

Vue.http.options.root = '/api'
//发送cookie和http认证
Vue.http.options.xhr = {
  withCredentials: true
}
//服务器处理不了json请求，将request body以application/x-www-form-urlencoded content type发送
//MIME(Multipurpose Internet Mail Extensions)
Vue.http.options.emulateJSON = true
//拦截器
// Vue.http.interceptors.push((request, next) => {
//   request.headers = request.headers || {}
//   let token = localStorage.getItem('token')
//   request.headers.set('Authorization', 'Bearer ' + token)
//   request.headers.set('Accept', 'application/json')
//   //请求发送后的处理逻辑
//   next((response) => {
//     if (response.status === 401) {
//       localStorage.removeItem('token')
//       location.reload()
//     }    
    
//     return response
//   })
    
// })

export default Vue
