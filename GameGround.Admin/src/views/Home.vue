<template>
    <div class="container">
        <div>
        <el-col :span="24" class="menu">
            <el-menu theme="dark" :default-active="activeIndex" 
            class="el-menu-demo" mode="horizontal" @select="handleSelect"
            unique-opened="true">
                <el-menu-item index="1">处理中心</el-menu-item>
                <el-submenu index="2">
                    <template slot="title">我的工作台</template>
                    <el-menu-item index="2-1">选项1</el-menu-item>
                    <el-menu-item index="2-2">选项2</el-menu-item>
                    <el-menu-item index="2-3">选项3</el-menu-item>
                </el-submenu>
                <el-menu-item index="3"><a href="https://www.ele.me" target="_blank">订单管理</a></el-menu-item>
            </el-menu>           
        </el-col>            
        </div>
    </div>
</template>
<style scoped lang="scss">
    .container{
        background-color:#EFF2F7;
        width:100%;
        height:100%;
        position:absolute;
    }
    
</style>
<script>
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
      }
    }
  }
</script>