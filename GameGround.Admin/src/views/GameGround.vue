<template>
    <div class="container">
        <img class="logo" src="../assets/logo.png"/>
        <h1>GameGround</h1>
        <el-button @click="handleExit" class="sign-out">退出</el-button>
        <el-col :span="24" class="menu">
            <div>
                
            <el-menu theme="dark" :default-active="activeIndex" 
            class="el-menu-demo" mode="horizontal" @select="handleSelect"
            :unique-opened="true" >  
                <el-menu-item index="1" @click="$router.push('/GameGround/Home')">首页</el-menu-item>
                <el-menu-item index="2" @click="$router.push('/GameGround/Collect')">我的收藏夹</el-menu-item>
                <el-menu-item index="3"> 我的游戏</el-menu-item>
            </el-menu>         
            
            </div>
            <div class="content">
                <router-view> </router-view>
            </div>

        </el-col>
        
    </div>
</template>
<style scoped lang="scss">
    .container{
        background-color:white;
        width:100%;
        height:100%;
        position:absolute;
        
    }
    .logo{
        float:left;
        margin: 0px;
        padding: 0px;
    }
    h1{
        color:black;
        float:left;
        margin-bottom: 0px;
        padding: 0px;
    }
    
</style>
<script>
import Vue from 'vue'
import {mapGetters, mapActions, mapState} from 'vuex'

  export default {
    
    data() {
      return {
        activeIndex: '1',
        activeIndex2: '1'
      };
    },
    methods: {
      handleSelect(key, keyPath) {
        console.log(key, keyPath);
      },
      handleExit(){
          console.log(window.localStorage)
          localStorage.removeItem('token');
          localStorage.clear()
          
          this.$router.push('/Login')
      }
    }
  }
</script>
<style scoped lang="scss">
    .sign-out{
        float: right;
        margin:20px;
    }
</style>