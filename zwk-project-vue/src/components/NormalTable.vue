<template>
    <Table border :columns="columns" :data="data" size="small" height disabled-hover></Table>

    <Page
        :total="pagination.total"
        :current="pagination.current"
        :page-size="pagination.size"
        :page-size-opts="pagination.sizes"
        size="small"
        show-elevator
        show-sizer
        show-total	
        @on-change=""
        @on-page-size-change=""
    />

    
</template>

<script>
export default {
    name: "NormalTable",
    props: {
        data: {
            type: Array,
            default() {
                return [];
            }
        },
        columns: {
            type: Array,
            default() {
                return [];
            }
        }
    },
    data: function() {
        return {
            table: {
                columns: [],
                data: [],
                height: 0
            },
            pagination: {
                total: 0,
                current: 0,
                size: 0,
                sizes: [20, 40, 80, 100]
            }
        };
    }
};
</script>
