import Vue from './resources'

export default{
    test() {
        return Vue.resource('test/get').get()
    },
    firstTest() {
        return Vue.resource('test/get').get()
    }
}