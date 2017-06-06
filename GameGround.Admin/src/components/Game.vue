<template>
    <div>
        <el-col :span="2">
        <img :src="getSrc()" />
        <el-button type="primary" @click="handleClick()">开始游戏</el-button>
        <el-button type="info">收藏游戏</el-button>
        </el-col>
    </div>
</template>
<script>
    import Vue from 'vue'
    export default {
        props:{
            game:{}
        },
        computed:{
            
        },
        methods:{
            getSrc(){
                return "/static/img/"+this.game.name+".png"
            },
            handleClick(){
            this.$router.push('Game/'+this.game.name)
        },
        },
        
        data(){
            return {

            }
        }
    }
</script>
<style scoped lang="scss">
    .el-button{
        margin: 2px;
    }
</style>