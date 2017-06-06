<template>
    <div>
    <el-col>
        <GameTemplate :game="this.game" :src="this.src"></GameTemplate>
    </el-col>
    </div>
</template>
<script>
    import Vue from 'vue'
    import GameTemplate from 'src/components/Game'
    export default{
        components:{
            GameTemplate
        },
        data(){
            return {
                game:{
                    name:'snake'
                },
                src:'src/assets/img/snake.png'
            }
        }

    }
</script>
<style scoped lang="scss">
    img{
        float:left;
    }
</style>
