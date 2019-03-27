<template>
    <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
</template>

<script>
import DataForm from "@/components/DataForm.vue";
export default {
    name: "project-linkGroup-add",
    components: { DataForm },
    data: function() {
        return {
            submitUrl: this.$api.project.linkGroup.url.add,
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
                    type: "input",
                    field: "name",
                    label: "组名",
                    rules: [
                        {
                            required: true,
                            message: "组名不能为空",
                            trigger: "blur"
                        }
                    ]
                }
            ]
        };
    }
};
</script>
