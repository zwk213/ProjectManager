<template>
    <DataForm :model="model" :submitUrl="submitUrl"></DataForm>
</template>

<script>
import DataForm from "@/components/DataForm.vue";
export default {
    name: "project-link-edit",
    components: { DataForm },
    data: function() {
        return {
            search: {
                linkId: this.$route.query.linkId,
                projectId: this.$route.query.projectId
            },
            submitUrl: this.$api.project.link.url.update,
            model: [
                {
                    type: "input",
                    field: "primaryKey",
                    label: "链接编码",
                    hide: true,
                    value: ""
                },
                {
                    type: "input",
                    field: "projectId",
                    label: "项目编码",
                    hide: true,
                    value: ""
                },
                {
                    type: "select",
                    field: "groupId",
                    label: "链接组",
                    value: "",
                    options: [],
                    rules: [
                        {
                            required: true,
                            message: "链接组不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                {
                    type: "input",
                    field: "name",
                    label: "名称",
                    value: "",
                    rules: [
                        {
                            required: true,
                            message: "链接组不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                {
                    type: "input",
                    field: "href",
                    label: "链接",
                    value: "",
                    rules: [
                        {
                            required: true,
                            message: "链接组不能为空",
                            trigger: "blur"
                        }
                    ]
                },
                { type: "textarea", field: "remark", label: "备注", value: "" }
            ]
        };
    },
    mounted: function() {
        this.getLink();
        this.getGroupOptions();
    },
    methods: {
        getLink: function() {
            this.$api.project.link.get(this.search).then(rsp => {
                //更新model的数据
                for (let i = 0; i < this.model.length; i++) {
                    let temp = this.model[i];
                    temp.value = !rsp.data[temp.field]
                        ? ""
                        : rsp.data[temp.field].toString();
                }
            });
        },
        getGroupOptions: function() {
            this.$api.project.linkGroup.getOptions(this.search).then(rsp => {
                this.model[2].options = rsp.data;
            });
        }
    }
};
</script>
