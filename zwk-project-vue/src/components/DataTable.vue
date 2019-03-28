<template>
    <Row ref="dataTable">
        <Table
            border
            :columns="columns"
            :data="table.data"
            size="small"
            :height="table.height"
            disabled-hover
        ></Table>

        <Page
            class="mt-2"
            :total="pagination.total"
            :page-size-opts="pagination.sizes"
            :current="pagination.search.page"
            :page-size="pagination.search.size"
            size="small"
            show-elevator
            show-sizer
            show-total
            @on-change="pageChange"
            @on-page-size-change="sizeChange"
        />

        <RouterDrawer ref="routerDrawer" :width="width"></RouterDrawer>
    </Row>
</template>

<script>
import helper from "@/utils/helper.js";
import RouterModel from "@/components/RouterModal.vue";
import RouterDrawer from "@/components/RouterDrawer.vue";

export default {
    name: "NormalTable",
    components: { RouterModel, RouterDrawer },
    props: {
        width: {
            type: Number,
            default: 800
        },
        columns: {
            type: Array,
            default() {
                return [];
            }
        },
        apiUrl: {
            type: [Number, String]
        },
        search: {
            type: Object
        }
    },
    data: function() {
        return {
            table: {
                data: [],
                height: 0
            },
            pagination: {
                total: 0,
                sizes: [20, 40, 80, 100],
                search: {
                    page: 1,
                    size: 20
                }
            }
        };
    },
    mounted: function() {
        //原生offsetTop指与父元素的间距，非元素与顶部间距
        this.table.height =
            window.innerHeight -
            helper.offset(this.$refs.dataTable.$el).top -
            40;
    },
    created: function() {
        this.load();
    },
    methods: {
        //表格
        load: function() {
            //合并搜索条件
            var temp = Object.assign({}, this.search, this.pagination.search);
            this.$api.get(this.apiUrl, temp).then(rsp => {
                this.table.data = rsp.data.data;
                this.pagination.total = rsp.data.count;
            });
        },
        //分页
        pageChange: function(page) {
            this.params.page = page;
            this.load();
        },
        sizeChange: function(size) {
            this.params.size = size;
            this.load();
        },
        open: function(title, path) {
            this.$refs.routerDrawer.open(title, path);
        }
    }
};
</script>
