<template>
    <Row>
        <!--搜索区域-->
        <Row class="mb-3" type="flex">
            <Input class="w-20 mr-3" v-model="table.search.name">
                <span slot="prepend">用户名</span>
            </Input>

            <Button class="mr-3" type="info" @click="search">搜索</Button>
            <Button type="info" @click="addUser">添加</Button>
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
                columns: [{ title: "用户名", key: "userName" }],
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
        }
    }
};
</script>
