<template>
    <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
</template>

<script>
import DataForm from "@/components/DataForm.vue";
export default {
    name: "project-schedule-add",
    components: { DataForm },
    data: function() {
        return {
            submitUrl: this.$api.project.schedule.url.add,
            model: [
                {
                    type: "input",
                    field: "projectId",
                    label: "项目编码",
                    hiddle: true,
                    value: this.$route.query.projectId
                },
                { type: "input", field: "name", label: "节点名称" },
                { type: "textarea", field: "remark", label: "节点内容" },
                { type: "datepicker", field: "start", label: "开始时间" },
                { type: "datepicker", field: "end", label: "截止时间" }
            ]
        };
    }
};
</script>
