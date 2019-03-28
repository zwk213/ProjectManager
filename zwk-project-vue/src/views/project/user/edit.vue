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
            submitUrl: this.$api.project.user.url.update,
            model: [
                {
                    type: "input",
                    field: "primaryKey",
                    label: "用户编码",
                    hide: true,
                    value: ""
                },
                {
                    type: "input",
                    field: "projectId",
                    label: "项目编码",
                    hide: true,
                    value: this.$route.query.projectId
                },
                {
                    type: "select",
                    field: "userId",
                    label: "用户",
                    value: "",
                    disabled: true,
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
                    type: "textarea",
                    field: "remark",
                    label: "备注",
                    value: ""
                }
            ],
            search: {
                userId: this.$route.query.userId
            }
        };
    },
    mounted: function() {
        this.getUser();
        this.getUserOptions();
    },
    methods: {
        getUser: function() {
            this.$api.project.user.get(this.search).then(rsp => {
                //更新model的数据
                for (let i = 0; i < this.model.length; i++) {
                    let temp = this.model[i];
                    temp.value = !rsp.data[temp.field]
                        ? ""
                        : rsp.data[temp.field].toString();
                }
            });
        },
        getUserOptions: function() {
            this.$api.user.getOptions().then(rsp => {
                this.model[2].options = rsp.data;
            });
        }
    }
};
</script>
