import api from '../api'
import * as types from './types'

//test
export const increment = ({
    commit
}) => {
    commit('INCREMENT')
}
export const decrement = ({
    commit
}) => {
    commit('DECREMENT')
}