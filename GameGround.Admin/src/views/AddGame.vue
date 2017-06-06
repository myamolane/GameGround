<template>
    <el-form>
        <el-input v-model="addForm.name" placeholder="游戏名称" auto-complete="off"></el-input>
        <el-input v-model="addForm.category" placeholder="游戏类别" auto-complete="off"></el-input>
        <el-input v-model="addForm.description" placeholder="游戏描述" auto-complete="off"></el-input>
        <el-input v-model="addForm.rule" placeholder="游戏规则" auto-complete="off"></el-input>
        <el-button @click="handleSubmit">添加游戏</el-button>
    </el-form>
</template>
<script>
    import Vue from 'vue'
    import {mapGetters, mapActions, mapState} from 'vuex'
    export default {
        data(){
         return {
            addForm: {
                name: '',
                category: '',
                description:'',
                rule:''
            }

        }
        },
        mounted(){
        },
        computed: {
            ...mapGetters({
                
            })
        },
        methods:{
            ...mapActions({
                addGame:'addGame',
                get:'get'
            }),
            handleSubmit(){
                this.get()
                this.addGame(this.addForm)
            }
        }
    }
</script>