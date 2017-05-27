import Vue from './resources'
export default　{
    test() {
        return Vue.resource('test').get()
    }
}