<template>
    <Row class="w-30 bg-white m-lr-auto p-3" style="margin-top:100px;">
        <h2 class="mb-4">项目管理系统</h2>
        <Form ref="formInline" :model="form" :rules="rules">
            <FormItem prop="username">
                <Input type="text" v-model="form.username" placeholder="Username">
                    <Icon type="ios-person-outline" slot="prepend"></Icon>
                </Input>
            </FormItem>
            <FormItem prop="password">
                <Input type="password" v-model="form.password" placeholder="Password">
                    <Icon type="ios-lock-outline" slot="prepend"></Icon>
                </Input>
            </FormItem>
            <FormItem class="flex-row justify-content-end">
                <Button type="primary" @click="handleSubmit('form')">登录</Button>
            </FormItem>
        </Form>
    </Row>
</template>

<script>
export default {
        data () {
            return {
                form: {
                    username: '',
                    password: ''
                },
                rules: {
                    username: [
                        { required: true, message: '请填写用户名', trigger: 'blur' }
                    ],
                    password: [
                        { required: true, message: '请填写密码', trigger: 'blur' },
                        { type: 'string', min: 6, message: '密码长度最小6位', trigger: 'blur' }
                    ]
                }
            }
        },
        methods: {
            handleSubmit(name) {
                this.$refs[name].validate((valid) => {
                    if (valid) {
                       
                    }
                })
            }
        }
    }
</script>
