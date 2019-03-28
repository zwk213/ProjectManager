<template>
    <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
</template>

<script>
import DataForm from "@/components/DataForm.vue";
export default {
    name: "project-link-add",
    components: { DataForm },
    data: function() {
        return {
            search: {
                projectId: this.$route.query.projectId
            },
            submitUrl: this.$api.project.link.url.add,
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
                    field: "groupId",
                    label: "链接组",
                    options: [],
                    rules: [
                        {
                            required: true,
                            message: "链接组不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                { type: "input", field: "name", label: "名称" },
                { type: "input", field: "href", label: "链接" },
                { type: "textarea", field: "remark", label: "备注" }
            ]
        };
    },
    mounted: function() {
        this.getGroupOptions();
    },
    methods: {
        getGroupOptions: function() {
            this.$api.project.linkGroup.getOptions(this.search).then(rsp => {
                this.model[1].options = rsp.data;
            });
        }
    }
};
</script>
