<template>
    <Row>
        <!--搜索区域-->
        <Row class="mb-3" type="flex">
            <Input class="w-20 mr-3" v-model="table.search.name">
                <span slot="prepend">用户名</span>
            </Input>

            <Button class="mr-3" type="primary" @click="search">搜索</Button>
            <Button type="primary" @click="addUser">添加</Button>
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
    name: "user-list",
    components: { DataTable },
    data: function() {
        return {
            table: {
                columns: [
                    {
                        title: "用户名",
                        key: "userName",
                        render: (h, params) => {
                            return h(
                                "router-link",
                                {
                                    props: {
                                        to:
                                            "/user/detail?userId=" +
                                            params.row.primaryKey
                                    }
                                },
                                params.row.userName
                            );
                        }
                    },
                    { title: "手机号", key: "phone" },
                    { title: "邮箱", key: "email" },
                    { title: "状态", key: "status" },
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
                                                this.editUser(
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
                ],
                apiUrl: this.$api.user.url.getPage,
                search: {
                    name: ""
                }
            }
        };
    },
    methods: {
        search: function() {
            this.$refs.dataTable.load();
        },
        addUser: function() {
            this.$refs.dataTable.openModel("添加用户", "/user/list/add");
        },
        editUser: function(userId) {
            this.$refs.dataTable.openModel(
                "编辑用户",
                "/user/list/edit?userId=" + userId
            );
        }
    }
};
</script>
