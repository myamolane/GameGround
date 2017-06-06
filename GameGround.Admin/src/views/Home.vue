<template>
    <div>
        <el-row>
        <el-col :span="17">
        <el-tabs v-model="filter.category" type="card" @tab-click="handleClick">
            <el-tab-pane label="所有分类" >

            </el-tab-pane>
            <el-tab-pane label="休闲" name="1">
                
            </el-tab-pane>
            <el-tab-pane label="赛车" name="2">
                
            </el-tab-pane>
            
        </el-tabs>
        </el-col>
        <el-col :span="6">
        <el-input placeholder="游戏名称" icon="search"></el-input>
        </el-col>
        </el-row>
        <el-row>
        
            <GameTemplate v-for="(game,index) in games" :keys="game.Id" v-bind:game="game"/>
            

            
        </el-row>
        <el-row>
        <el-pagination class="pagination" @current-change="handleCurrentChanged"
            :current-page.sync="this.filter.page" :page-size="pageSize" layout="total,prev,pager,next"
            :total="total"/>
        </el-row>
    </div>
</template>
<script>
    import Vue from 'vue'
    import {mapGetters, mapActions, mapState} from 'vuex'
    import GameTemplate from 'src/components/Game'
    export default {
        components:{
            GameTemplate
        },
        data(){
         return {
            filter: {
                category: '',
                name:'',
                page:1
            },
            total:0,
            pageSize:20
        }
        },
        mounted(){
            this.searchGames(this.filter)
        },
        computed: {
            ...mapGetters({
                games:'games',
                totalGames:'totalGames'
            })
        },
        methods:{
            ...mapActions({
                searchGames:'searchGames'
            }),
            search(){
                this.searchGames(this.filter)
                this.total=this.totalGames
            },
            handleClick(){
                this.filter.page=1
                this.search(this.filter)
            },
            handleCurrentChanged(){
                this.search(this.filter)
            },
            getSrc(name){
                return "/static/img/"+name+".png"
            }
        }
    }
</script>
<style scoped lang="scss">
    .el-input{
        margin: 5px;
    }
    .el-pagination{
        margin:10px;
        float:right;
    }
</style>