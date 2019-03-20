<template>
    <div>
        <!--操作-->
        <Row class="mb-3" type="flex" justify="space-between">
            <Row type="flex" class="flex-grow">
                <Select v-model="table.search.schedule" class="w-15 mr-3" placeholder="请选择时间节点">
                    <Option value="1">1</Option>
                </Select>
                <Select v-model="table.search.status" class="w-15 mr-3" placeholder="请选择问题状态">
                    <Option value="1">1</Option>
                </Select>
                <Select v-model="table.search.principal" class="w-15 mr-3" placeholder="请选择负责人">
                    <Option value="1">1</Option>
                </Select>
                <Button class="bg-white" type="primary" ghost @click="search">搜索</Button>
            </Row>
            <div>
                <ButtonGroup class="bg-white">
                    <Button type="primary" ghost @click="add">添加</Button>
                </ButtonGroup>
            </div>
        </Row>
        <!--内容展示区-->
        <DataTable
            ref="dataTable"
            :columns="table.columns"
            :apiUrl="table.apiUrl"
            :search="table.search"
        ></DataTable>
    </div>
</template>

<script>
import DataTable from "@/components/DataTable.vue";
export default {
    name: "project-issue",
    components: { DataTable },
    data: function() {
        return {
            table: {
                apiUrl: this.$api.project.issue.url.getPage,
                search: {
                    schedule: "",
                    status: "",
                    principal: "",
                    projectId: this.$route.query.projectId
                },
                columns: [
                    {
                        title: "摘要",
                        key: "summary",
                        render: (h, params) => {
                            return h(
                                "a",
                                {
                                    on: {
                                        click: () => {}
                                    }
                                },
                                params.row.name
                            );
                        }
                    },
                    { title: "状态", key: "status", width: 80 },
                    { title: "优先级", key: "priority", width: 80 },
                    { title: "创建人", key: "createName", width: 100 },
                    { title: "负责人", key: "principalName", width: 100 },
                    { title: "创建时间", key: "createDate", width: 150 },
                    {
                        title: "操作",
                        width: 80,
                        render: (h, params) => {
                            return h("div", [
                                h(
                                    "Button",
                                    {
                                        props: {
                                            type: "primary",
                                            size: "small"
                                        },
                                        style: {
                                            marginRight: "5px"
                                        },
                                        on: {
                                            click: () => {
                                                this.edit(
                                                    params.row.primaryKey
                                                );
                                            }
                                        }
                                    },
                                    "编辑"
                                )
                            ]);
                        }
                    }
                ]
            }
        };
    },
    methods: {
        search: function() {
            this.$refs.dataTable.load();
        },
        add: function() {
            this.$refs.dataTable.openModel(
                "添加问题",
                "/project/detail/issue/add?projectId=" +
                    this.table.search.projectId
            );
        },
        edit: function(issueId) {
            this.$refs.dataTable.openModel(
                "编辑问题",
                "/project/detail/issue/edit?projectId=" +
                    this.table.search.projectId +
                    "&issueId=" +
                    issueId
            );
        },
        detail: function(issueId) {
            this.$refs.dataTable.openModel(
                "问题详情",
                "/project/detail/issue/detail?issueId=" + issueId
            );
        }
    }
};
</script>
