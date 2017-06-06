import Vue from './resources'
export default　{
    test() {
        return Vue.resource('test').get()
    },
    login(form) {
        return Vue.resource('account/login').save(form)
    },
    register(form) {
        return Vue.resource('account/register').save(form)
    },
    addGame(form){
        return Vue.resource('game/add').save(form)
    },
    searchGames(filter){
        return Vue.resource('game/search').save(filter)
    },
    getId(){
        return Vue.resource('game').get()
    }
    
}