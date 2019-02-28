<template>
    <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
</template>

<script>
import DataForm from "@/components/DataForm.vue";

export default {
    name: "user-add",
    components: { DataForm },
    data: function() {
        return {
            submitUrl: this.$api.user.url.add,
            model: [
                {
                    type: "input",
                    field: "userName",
                    label: "用户名",
                    rules: [
                        {
                            required: true,
                            message: "用户名不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                { type: "input", field: "password", label: "密码" },
                { type: "input", field: "phone", label: "手机号" },
                { type: "input", field: "email", label: "邮箱" }
            ]
        };
    }
};
</script>
