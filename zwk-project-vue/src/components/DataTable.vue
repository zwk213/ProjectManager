<template>
    <Row>
        <Table
            ref="table"
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
            :current="search.page"
            :page-size="search.size"
            size="small"
            show-elevator
            show-sizer
            show-total
            @on-change="pageChange"
            @on-page-size-change="sizeChange"
        />

        <Modal v-model="model.show" :title="model.title" @on-cancel="closeModel" footer-hide>
            <div>
                <router-view></router-view>
            </div>
        </Modal>
    </Row>
</template>

<script>
import helper from "@/utils/helper.js";

export default {
    name: "NormalTable",
    props: {
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
            params: {
                page: 1,
                size: 20
            },
            pagination: {
                total: 0,
                sizes: [20, 40, 80, 100]
            },
            model: {
                show: false,
                title: ""
            }
        };
    },
    mounted: function() {
        //原生offsetTop指与父元素的间距，非元素与顶部间距
        this.table.height =
            window.innerHeight -
            helper.node.offset(this.$refs.table.$el).top -
            40;
    },
    created: function() {
        this.load();
    },
    methods: {
        //表格
        load: function() {
            //合并搜索条件
            var temp = Object.assign({}, this.search, this.params);
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
        //模态框
        openModel: function(title, path) {
            this.model.show = true;
            this.model.title = title;
            this.$router.push(path);
        },
        closeModel: function() {
            this.$router.back();
        }
    }
};
</script>
