<template>
    <Row>
        <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
    </Row>
</template>

<script>
import DataForm from "@/components/DataForm.vue";

export default {
    name: "user-add",
    components: { DataForm },
    data: function() {
        return {
            submitUrl: this.$api.user.url.update,
            model: [
                { type: "input", field: "userName", label: "用户名" },
                { type: "input", field: "password", label: "密码" },
                { type: "input", field: "phone", label: "手机号" },
                { type: "input", field: "email", label: "邮箱" }
            ]
        };
    },
    mounted: function() {
        this.init();
    },
    methods: {
        init: function() {
            var params = { userId: this.$route.query.userId };
            this.$api.user.get(params).then(rsp => {
                //更新model的数据
                for (let i = 0; i < this.model.length; i++) {
                    var temp = this.model[i];
                    temp.value = rsp.data[temp.field];
                }
            });
        }
    }
};
</script>
