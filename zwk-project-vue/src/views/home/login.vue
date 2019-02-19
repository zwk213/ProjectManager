<template>
    <Row class="w-25 m-lr-auto" style="margin-top:100px;">
        <h2 class="mb-4 text-center">ZWK项目管理系统</h2>
        <Form class="p-4 bg-white border rounded" :model="form" label-position="top">
            <FormItem label="用户名">
                <Input type="text" v-model="form.username" placeholder="Username"></Input>
            </FormItem>
            <FormItem label="密码">
                <Input type="password" v-model="form.password" placeholder="Password"></Input>
            </FormItem>
            <FormItem class="mb-0">
                <Button type="primary" long @click="login">登录</Button>
            </FormItem>
        </Form>
        <Row class="text-center mt-4 text-light">power by zwk</Row>
    </Row>
</template>

<script>
export default {
    data() {
        return {
            form: {
                username: "admin",
                password: "123456"
            }
        };
    },
    methods: {
        login() {
            this.$store.dispatch("login", this.form).then(rsp => {
                this.$router.push({ path: "/" });
            });
        }
    }
};
</script>
