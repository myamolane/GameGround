<template>
    <div class="page-content">
        <el-row>
        <el-col :xs="5" :sm="6" :md="7" :lg="8">
            <span>&nbsp</span>
        </el-col>
        <el-col :xs="14" :sm="12" :md="10" :lg="8">
            <h1>
                <router-link to="NiceToMeetU">Join in</router-link>
                <br/>
                &
                <br/>
                We will make your life lighter
            </h1>
        <el-form>
            <el-col :lg="4" :md="3" :sm="2">
                <span>&nbsp</span>
            </el-col>
            <el-col :lg="16" :md="18" :sm="20">
                <div class="login-div">
                    <el-form-item>
                        <el-input class="login-input" type="text" placeholder="Your user name"/>
                    </el-form-item>
                    <el-form-item>
                        <el-input class="login-input" type="text" placeholder="Your password"/>
                    </el-form-item>            
                </div>
            </el-col> 
            <el-col :lg="4" :md="3" :sm="2">
                &nbsp
            </el-col>
        </el-form>

        </el-col>
        </el-row>
        <el-row>
        <i>Press enter to enter in</i>  
        </el-row>
        
 </div>
</template> 
<script>
    import Vue from 'vue'
    export default {
        mounted(){
            document.onkeyup=this.handleKeyUp;
        },
        methods:{
            handleKeyUp(){
                if (event.key==="Enter")
                {   
                     
                    this.$router.push('GameGround')            
                }
            },
            handleClick(){
                alert("click");
            }

        }
    }
</script>

<style scoped lang="scss">
    .page-content {
        position: relative;
        top:10%;
    }
    a{
        color:#b9d011;
    }
    i{
        color:white;
    }
    span{
        color:white;
    }
    .login-div{
        background-color: #b9d011;
        border-radius: 5px;

        padding:10px;
        padding-left:10px;
        margin-bottom:10px;
        min-width:100px;
    }
    .el-form-item{
        margin:8px;
    }
    .el-form{
        
    }
    .el-input{
        float:left;
        font-size:20px;
    }
    .login-input{
        border:0px;
    }

</style>