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
                <Button class="bg-white" type="primary" ghost>搜索</Button>
            </Row>
            <div>
                <ButtonGroup class="bg-white">
                    <Button type="primary" ghost>添加文件</Button>
                    <Button type="primary" ghost>添加文件夹</Button>
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
                    principal: ""
                },
                columns: []
            }
        };
    },
    methods: {}
};
</script>
