<template>
    <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
</template>

<script>
import DataForm from "@/components/DataForm.vue";
export default {
    name: "project-schedule-edit",
    components: { DataForm },
    data: function() {
        return {
            submitUrl: this.$api.project.schedule.url.update,
            search: {
                scheduleId: this.$route.query.scheduleId
            },
            model: [
                {
                    type: "input",
                    field: "primaryKey",
                    label: "截止时间",
                    hiddle: true,
                    value: this.$route.query.scheduleId
                },
                { type: "input", field: "name", label: "节点名称", value: "" },
                {
                    type: "textarea",
                    field: "remark",
                    label: "节点内容",
                    value: ""
                },
                {
                    type: "datepicker",
                    field: "start",
                    label: "开始时间",
                    value: ""
                },
                {
                    type: "datepicker",
                    field: "end",
                    label: "截止时间",
                    value: ""
                }
            ]
        };
    },
    mounted: function() {
        this.getSchedule();
    },
    methods: {
        getSchedule: function() {
            this.$api.project.schedule.get(this.search).then(rsp => {
                //更新model的数据
                for (let i = 0; i < this.model.length; i++) {
                    let temp = this.model[i];
                    temp.value = rsp.data[temp.field];
                }
            });
        }
    }
};
</script>