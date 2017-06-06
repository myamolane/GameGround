<template>
    <div class="page-content">
    <el-form :model="registerForm" :rules="rules" ref="registerForm" label-width="100px" class="demo-ruleForm">
        <el-form-item label="账号" prop="login" class="form-item">
            <el-input v-model="registerForm.login" placeholder="请输入账号" auto-complete="off" class="input-item"></el-input>
        </el-form-item>
        <el-form-item label="昵称" prop="name" class="form-item">
            <el-input v-model="registerForm.name" placeholder="请输入昵称" auto-complete="off" class="input-item"></el-input>
        </el-form-item>
        <el-form-item label="密码" prop="password" class="form-item">
            <el-input type="password" v-model="registerForm.password" placeholder="请输入密码" auto-complete="off" class="input-item"></el-input>
        </el-form-item>
        <el-form-item label="确认密码" prop="checkPassword" class="form-item">
            <el-input type="password" v-model="registerForm.checkPassword" placeholder="请确认密码" auto-complete="off" class="input-item"></el-input>
        </el-form-item>
        <el-form-item label="性别" prop="sex" class="form-item">
            <el-radio-group v-model="registerForm.sex">
                <el-radio v-model="registerForm.sex" :label="0">男</el-radio>
                <el-radio v-model="registerForm.sex" :label="1">女</el-radio>
            </el-radio-group>
        </el-form-item>
        <el-form-item label="出生日期" prop="birthday" class="form-item">
            <el-date-picker type="date" placeholder="选择日期" v-model="pickerDate" v-on:change="handlePick()"  auto-complete="off" class="input-item"></el-date-picker>
        </el-form-item>
        <el-form-item label="电子邮箱" prop="email" class="form-item">
            <el-input v-model.number="registerForm.email" placeholder="请输入邮箱" auto-complete="off" class="input-item"></el-input>
        </el-form-item>
        <el-form-item class="form-item">
            <el-button type="primary" v-loading.fullscreen.lock="fullscreeenLoading" @click="submitForm('registerForm')" class="button-item">提交</el-button>
            <el-button @click="resetForm('registerForm')" class="button-item">重置</el-button>
        </el-form-item>
    </el-form>
    </div>
</template>

<script>
    import Vue from 'vue'
    import {mapGetters, mapActions, mapState} from 'vuex'
    import util from 'src/common/util'
    import md5 from 'md5'
    export default {
        data() {
            var checkLogin = (rule, value, callback) => {
                var pattern = /^[a-zA-Z0-9_]{1,}$/;
                if (value === '') {
                    return callback(new Error('账号不能为空'));
                }
                setTimeout(() => {
                    if (!value.match(pattern)) {
                        callback(new Error('账号只能由字母数字下划线组成'));
                    } else {
                        callback();
                    }
                }, 100);
            };
            var validateName = (rule,value,callback) => {
                var pattern = /^[\u4e00-\u9fa5a-zA-Z0-9_]+$/;
                if(value === ''){
                    return callback(new Error('名称不能为空'))   
                }
                setTimeout(() => {
                    if (!value.match(pattern)){
                        callback(new Error('名称只能由中文字母数字下划线组成'))
                    }
                    else{
                        callback()
                    }
                })
            };
            var validatePass = (rule, value, callback) => {
                if (value === '') {
                    callback(new Error('请输入密码'));
                } else {
                    if (this.registerForm.checkPassword !== '') {
                        this.$refs.registerForm.validateField('checkPassword');
                    }
                    callback();
                }
            };
            var validatePass2 = (rule, value, callback) => {
                if (value === '') {
                    callback(new Error('请再次输入密码'));
                } else if (value !== this.registerForm.password) {
                    callback(new Error('两次输入密码不一致!'));
                } else {
                    callback();
                }
            };
             var checkEmail = (rule, value, callback) => {
                if (value === '') {
                    return callback(new Error('邮箱不能为空'));
                }
                setTimeout(() => {
                    if (!(/^(\w-*\.*)+@(\w-?)+(\.\w{2,})+$/.test(value))) {
                        callback(new Error('请输入正确格式的邮箱'));
                    } else {
                        callback();
                    }
                }, 100);
            };
            return {
                fullscreeenLoading:false,
                pickerDate: '',
                registerForm: {
                    login: '',
                    name: '',
                    password: '',
                    checkPassword: '',
                    sex: 2,
                    birth: '',
                    email: ''
                },
                rules: {
                    login: [
                        { validator: checkLogin, trigger: 'blur' }
                    ],
                    name: [
                        { validator: validateName, trigger: 'blur'}
                    ],
                    password: [
                        { validator: validatePass, trigger: 'blur' }
                    ],
                    checkPassword: [
                        { validator: validatePass2, trigger: 'blur' }
                    ],
                    // sex: [
                    //     { message: '请选择性别', trigger: 'change' }
                    // ],
                    // birthday: [
                    //     { type: 'date', message: '请选择日期', trigger: 'change' }
                    // ],
                    email: [
                        { validator: checkEmail, trigger: 'blur' }
                    ]
                }
            };
        },
        methods: {
            ...mapActions({
                register: "register",
            }),
            handlePick(){
                //console.log($event)
                this.registerForm.birth = util.dateToString(this.pickerDate)
            },
            submitForm(formName) {
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        var params = {
                            form: this.registerForm,
                            callback: (errorMessage) => {
                            //that.logining = false
                                if(!errorMessage) {
                                    alert("注册成功")
                                    this.$router.push('Login')
                                }
                                else
                                {
                                    this.$message({
                                        showClose: true,
                                        message: errorMessage,
                                        type: 'error'
                                    });
                                }
                            } 
                        }
                        this.fullscreenLoading=true
                        setTimeout(()=>{
                            this.fullscreenLoading=false
                        },3000)
                        params.form.password=md5(params.form.password)
                        params.form.checkPassword=md5(params.form.checkPassword)
                        this.register(params);
                    } else {
                        console.log('error submit!!');
                    }
                    
                });
            },
            resetForm(formName) {
                
                this.$refs[formName].resetFields();
            }
        }
    }

</script>

<style scoped lang="scss">
    .page-content {
        position: relative;
        top:15%;
    }
    .input-item {
        width: 300px;
    }
    .form-item {
        position: relative;
        width: 400px;
        left: 30%;
    }
</style>