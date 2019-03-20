<template>
    <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
</template>

<script>
import DataForm from "@/components/DataForm.vue";
export default {
    name: "project-issue-add",
    components: { DataForm },
    data: function() {
        return {
            submitUrl: this.$api.project.issue.url.add,
            search: {
                projectId: this.$route.query.projectId
            },
            model: [
                {
                    type: "input",
                    field: "projectId",
                    label: "项目编码",
                    value: this.$route.query.projectId,
                    hiddle: true
                },
                {
                    type: "input",
                    field: "summary",
                    label: "摘要",
                    rules: [
                        {
                            required: true,
                            message: "摘要不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                { type: "textarea", field: "detail", label: "详情" },
                {
                    type: "select",
                    field: "scheduleId",
                    label: "时间节点",
                    options: [],
                    rules: [
                        {
                            required: true,
                            message: "时间节点不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                {
                    type: "select",
                    field: "principalId",
                    label: "负责人",
                    options: [],
                    rules: [
                        {
                            required: true,
                            message: "负责人不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                {
                    type: "select",
                    field: "priority",
                    label: "优先级",
                    options: [
                        { label: "正常", value: 1 },
                        { label: "低", value: 0 },
                        { label: "高", value: 2 }
                    ],
                    rules: [
                        {
                            required: true,
                            message: "优先级不能为空",
                            trigger: "blur"
                        }
                    ]
                }
            ]
        };
    },
    mounted: function() {
        this.getScheduleOptions();
        this.getUserOptions();
    },
    methods: {
        getScheduleOptions: function() {
            this.$api.project.schedule.getOptions(this.search).then(rsp => {
                this.model[3].options = rsp.data;
            });
        },
        getUserOptions: function() {
            this.$api.project.user.getOptions(this.search).then(rsp => {
                this.model[4].options = rsp.data;
            });
        }
    }
};
</script>