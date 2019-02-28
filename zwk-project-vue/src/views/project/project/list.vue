<template>
    <Row>
        <!--搜索区域-->
        <Row class="mb-3" type="flex">
            <Input class="w-20 mr-3" v-model="table.search.name">
                <span slot="prepend">项目名</span>
            </Input>

            <Button class="mr-3" type="primary" @click="search">搜索</Button>
            <Button type="primary" @click="add">添加</Button>
        </Row>

        <DataTable
            ref="dataTable"
            :columns="table.columns"
            :apiUrl="table.apiUrl"
            :search="table.search"
        ></DataTable>
    </Row>
</template>

<script>
import DataTable from "@/components/DataTable.vue";
export default {
    name: "project-list",
    components: { DataTable },
    data: function() {
        return {
            table: {
                apiUrl: this.$api.project.url.getPage,
                search: {
                    name: ""
                },
                columns: [
                    {
                        title: "项目名",
                        key: "name",
                        render: (h, params) => {
                            return h(
                                "router-link",
                                {
                                    props: {
                                        to:
                                            "/project/detail?projectId=" +
                                            params.row.primaryKey
                                    }
                                },
                                params.row.name
                            );
                        }
                    },
                    { title: "状态", key: "status" },
                    { title: "类型", key: "type" },
                    { title: "创建时间", key: "createDate" },
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
            this.$refs.dataTable.openModel("添加项目", "/project/list/add");
        },
        edit: function(userId) {
            this.$refs.dataTable.openModel(
                "编辑项目",
                "/project/list/edit?projectId=" + userId
            );
        }
    }
};
</script>

<style>
</style>
