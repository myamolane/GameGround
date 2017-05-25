<template>
    <div class="page-content">
    <el-form :model="registerForm" :rules="register" ref="registerForm" label-width="100px" class="demo-ruleForm">
        <el-form-item label="昵称" prop="userName" class="form-item">
            <el-input v-model="registerForm.userName" placeholder="请输入昵称" auto-complete="off" class="input-item"></el-input>
        </el-form-item>
        <el-form-item label="密码" prop="pass" class="form-item">
            <el-input type="password" v-model="registerForm.pass" placeholder="请输入密码" auto-complete="off" class="input-item"></el-input>
        </el-form-item>
        <el-form-item label="确认密码" prop="checkPass" class="form-item">
            <el-input type="password" v-model="registerForm.checkPass" placeholder="请确认密码" auto-complete="off" class="input-item"></el-input>
        </el-form-item>
        <el-form-item label="性别" prop="sex" class="form-item">
            <el-radio-group v-model="registerForm.sex">
                <el-radio label="男"></el-radio>
                <el-radio label="女"></el-radio>
            </el-radio-group>
        </el-form-item>
        <el-form-item label="出生日期" prop="birthday" class="form-item">
            <el-date-picker type="date" placeholder="选择日期" v-model="registerForm.birthday" auto-complete="off" class="input-item"></el-date-picker>
        </el-form-item>
        <el-form-item label="手机号码" prop="phoneNum" class="form-item">
            <el-input v-model.number="registerForm.phoneNum" placeholder="请输入手机号" auto-complete="off" class="input-item"></el-input>
        </el-form-item>
        <el-form-item class="form-item">
            <el-button type="primary" @click="submitForm('registerForm')" class="button-item">提交</el-button>
            <el-button @click="resetForm('registerForm')" class="button-item">重置</el-button>
        </el-form-item>
    </el-form>
    </div>
</template>

<script>
    import Vue from 'vue'
    export default {
        data() {
            var checkuserName = (rule, value, callback) => {
                var usern = /^[a-zA-Z0-9_]{1,}$/;
                if (value === '') {
                    return callback(new Error('昵称不能为空'));
                }
                setTimeout(() => {
                    if (!value.match(usern)) {
                        callback(new Error('昵称只能由字母数字下划线组成'));
                    } else {
                        callback();
                    }
                }, 100);
            };
            var validatePass = (rule, value, callback) => {
                if (value === '') {
                    callback(new Error('请输入密码'));
                } else {
                    if (this.registerForm.checkPass !== '') {
                        this.$refs.registerForm.validateField('checkPass');
                    }
                    callback();
                }
            };
            var validatePass2 = (rule, value, callback) => {
                if (value === '') {
                    callback(new Error('请再次输入密码'));
                } else if (value !== this.registerForm.pass) {
                    callback(new Error('两次输入密码不一致!'));
                } else {
                    callback();
                }
            };
             var checkphoneNum = (rule, value, callback) => {
                if (value === '') {
                    return callback(new Error('手机号不能为空'));
                }
                setTimeout(() => {
                    if (!(/^1[34578]\d{9}$/.test(value))) {
                        callback(new Error('请输入正确格式的手机号'));
                    } else {
                        callback();
                    }
                }, 100);
            };
            return {
                registerForm: {
                    userName: '',
                    pass: '',
                    checkPass: '',
                    sex: '',
                    birthday: '',
                    phoneNum: ''
                },
                register: {
                    userName: [
                        { validator: checkuserName, trigger: 'blur' }
                    ],
                    pass: [
                        { validator: validatePass, trigger: 'blur' }
                    ],
                    checkPass: [
                        { validator: validatePass2, trigger: 'blur' }
                    ],
                    sex: [
                        { message: '请选择性别', trigger: 'change' }
                    ],
                    birthday: [
                        { type: 'date', message: '请选择日期', trigger: 'change' }
                    ],
                    phoneNum: [
                        { validator: checkphoneNum, trigger: 'blur' }
                    ]
                }
            };
        },
        methods: {
            submitForm(formName) {
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        alert('submit!');
                    } else {
                        console.log('error submit!!');
                        return false;
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