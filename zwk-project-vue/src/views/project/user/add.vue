<template>
    <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
</template>

<script>
import DataForm from "@/components/DataForm.vue";
export default {
    name: "project-user-add",
    components: { DataForm },
    data: function() {
        return {
            submitUrl: this.$api.project.user.url.add,
            model: [
                {
                    type: "input",
                    field: "projectId",
                    label: "项目编码",
                    hiddle: true,
                    value: this.$route.query.projectId,
                    rules: [
                        {
                            required: true,
                            message: "项目编码不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                {
                    type: "select",
                    field: "userId",
                    label: "用户",
                    options: [],
                    rules: [
                        {
                            required: true,
                            message: "用户不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                {
                    type: "select",
                    field: "type",
                    label: "类型",
                    options: [
                        { label: "内部用户", value: "0" },
                        { label: "外部用户", value: "1" }
                    ],
                    rules: [
                        {
                            required: true,
                            message: "类型不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                {
                    type: "input",
                    field: "phone",
                    label: "手机号",
                    rules: [
                        {
                            required: true,
                            message: "手机号不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                {
                    type: "input",
                    field: "email",
                    label: "邮箱",
                    rules: [
                        {
                            required: true,
                            message: "邮箱不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                {
                    type: "input",
                    field: "post",
                    label: "职位",
                    rules: [
                        {
                            required: true,
                            message: "职位不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                {
                    type: "input",
                    field: "company",
                    label: "公司",
                    rules: [
                        {
                            required: true,
                            message: "公司不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                { type: "textarea", field: "remark", label: "备注" }
            ]
        };
    },
    mounted: function() {
        this.getUserOptions();
    },
    methods: {
        getUserOptions: function() {
            this.$api.user.getOptions().then(rsp => {
                this.model[1].options = rsp.data;
            });
        }
    }
};
</script>
