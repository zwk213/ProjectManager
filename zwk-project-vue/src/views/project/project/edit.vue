<template>
    <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
</template>

<script>
import DataForm from "@/components/DataForm.vue";
export default {
    name: "project-edit",
    components: { DataForm },
    data: function() {
        return {
            submitUrl: this.$api.project.url.update,
            model: [
                {
                    type: "static",
                    field: "primaryKey",
                    label: "编码",
                    value: ""
                },
                {
                    type: "input",
                    field: "name",
                    label: "项目名",
                    rules: [
                        {
                            required: true,
                            message: "项目名不能为空",
                            trigger: "blur"
                        }
                    ],
                    value: ""
                },
                { type: "input", field: "logo", label: "logo", value: "" },
                {
                    type: "select",
                    field: "type",
                    label: "类型",
                    options: [{ label: "一般项目", value: 0 }],
                    value: ""
                }
            ]
        };
    },
    mounted: function() {
        this.init();
    },
    methods: {
        init: function() {
            var params = { projectId: this.$route.query.projectId };
            this.$api.project.get(params).then(rsp => {
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