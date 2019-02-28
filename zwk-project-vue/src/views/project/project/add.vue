<template>
    <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
</template>

<script>
import DataForm from "@/components/DataForm.vue";
export default {
    name: "project-add",
    components: { DataForm },
    data: function() {
        return {
            submitUrl: this.$api.project.url.add,
            model: [
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
                    ]
                },
                { type: "input", field: "logo", label: "logo" },
                {
                    type: "select",
                    field: "type",
                    label: "类型",
                    options: [{ label: "一般项目", value: 0 }]
                }
            ]
        };
    }
};
</script>
