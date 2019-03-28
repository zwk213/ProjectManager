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
            search: {
                projectId: this.$route.query.projectId
            },
            submitUrl: this.$api.project.user.url.add,
            model: [
                {
                    type: "input",
                    field: "projectId",
                    label: "项目编码",
                    hide: true,
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
                    field: "groupId",
                    label: "用户组",
                    options: [],
                    rules: [
                        {
                            required: true,
                            message: "用户组不能为空",
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
        this.getGroupOptions();
    },
    methods: {
        getUserOptions: function() {
            this.$api.user.getOptions().then(rsp => {
                this.model[1].options = rsp.data;
            });
        },
        getGroupOptions: function() {
            this.$api.project.userGroup.getOptions(this.search).then(rsp => {
                this.model[2].options = rsp.data;
            });
        }
    }
};
</script>
