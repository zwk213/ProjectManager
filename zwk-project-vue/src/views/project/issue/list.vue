<template>
    <div>
        <!--操作-->
        <Row class="mb-3" type="flex" justify="space-between">
            <Row type="flex" class="flex-grow">
                <Select
                    v-model="table.search.scheduleId"
                    class="w-15 mr-3"
                    placeholder="请选择时间节点"
                    clearable
                >
                    <Option
                        v-for="option in options.schedule"
                        :value="option.value"
                        :key="option.value"
                    >{{option.label}}</Option>
                </Select>
                <Select
                    v-model="table.search.status"
                    class="w-15 mr-3"
                    placeholder="请选择问题状态"
                    clearable
                >
                    <Option
                        v-for="option in options.status"
                        :value="option.value"
                        :key="option.value"
                    >{{option.label}}</Option>
                </Select>
                <Select
                    v-model="table.search.principalId"
                    class="w-15 mr-3"
                    placeholder="请选择负责人"
                    clearable
                >
                    <Option
                        v-for="option in options.principal"
                        :value="option.value"
                        :key="option.value"
                    >{{option.label}}</Option>
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
                    scheduleId: "",
                    status: "",
                    principalId: "",
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
                                        click: () => {
                                            this.detail(params.row.primaryKey);
                                        }
                                    }
                                },
                                params.row.summary
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
            },
            options: {
                schedule: [],
                principal: [],
                status: [
                    {
                        label: "待处理",
                        value: "0"
                    },
                    {
                        label: "待复测",
                        value: "1"
                    },
                    {
                        label: "已处理",
                        value: "2"
                    },
                    {
                        label: "暂停",
                        value: "3"
                    },
                    {
                        label: "取消",
                        value: "4"
                    }
                ]
            }
        };
    },
    mounted: function() {
        this.getUserOptions();
        this.getScheduleOptions();
    },
    methods: {
        search: function() {
            this.$refs.dataTable.load();
        },
        add: function() {
            this.$refs.dataTable.open(
                "添加问题",
                "/project/detail/issue/add?projectId=" +
                    this.table.search.projectId
            );
        },
        edit: function(issueId) {
            this.$refs.dataTable.open(
                "编辑问题",
                "/project/detail/issue/edit?projectId=" +
                    this.table.search.projectId +
                    "&issueId=" +
                    issueId
            );
        },
        detail: function(issueId) {
            this.$refs.dataTable.open(
                "问题详情",
                "/project/detail/issue/detail?issueId=" + issueId
            );
        },
        getScheduleOptions: function() {
            this.$api.project.schedule
                .getOptions(this.table.search)
                .then(rsp => {
                    this.options.schedule = rsp.data;
                });
        },
        getUserOptions: function() {
            this.$api.project.user.getOptions(this.table.search).then(rsp => {
                this.options.principal = rsp.data;
            });
        }
    }
};
</script>
