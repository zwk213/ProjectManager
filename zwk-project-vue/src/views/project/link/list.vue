<template>
    <div class="relative">
        <ButtonGroup class="absolute" style="top:0;right:0">
            <Button class="bg-white" type="primary" ghost @click="add">添加</Button>
        </ButtonGroup>

        <!-- 内容 -->
        <div>
            <!-- 分组数据 -->
            <div v-for="(group,index) in links" :key="index">
                <div class="bold mb-2">{{group[0].type}}</div>
                <Row type="flex">
                    <div
                        v-for="(item,index) in group"
                        :key="item.primaryKey"
                        class="bg-white w-25 p-3 border rounded mr-3 mb-3"
                    >
                        <Row type="flex" justify="space-between" align="bottom" class="mb-3">
                            <div>
                                <span class="font-lg bold">{{item.name}}</span>
                            </div>
                            <!--编辑-->
                            <Button
                                size="small"
                                shape="circle"
                                icon="ios-settings"
                                @click="edit(item.primaryKey)"
                            ></Button>
                        </Row>
                        <div class="font-sm">
                            <div>
                                <span>地址</span>
                                <span class="ml-2 mr-2 bold">:</span>
                                <a :href="item.href" target="_blank">{{item.href}}</a>
                            </div>
                            <Row type="flex" class="flex-nowrap">
                                <span class="flex-shrink">备注</span>
                                <span class="flex-shrink ml-2 mr-2 bold">:</span>
                                <span>{{item.remark}}</span>
                            </Row>
                        </div>
                    </div>
                </Row>
            </div>
        </div>

        <!--弹窗modal-->
        <RouterModal ref="routerModal"></RouterModal>
    </div>
</template>

<script>
import RouterModal from "@/components/RouterModal.vue";
export default {
    name: "project-link",
    components: { RouterModal },
    data: function() {
        return {
            search: {
                projectId: this.$route.query.projectId
            },
            links: []
        };
    },
    mounted: function() {
        this.getLinkList();
    },
    methods: {
        getLinkList: function() {
            this.$api.project.link.getList(this.search).then(rsp => {
                //整理数据，将返回值按type分组
                var all = rsp.data;
                var index = 0;
                var temp = [[]];
                for (let i = 0; i < all.length; i++) {
                    if (i != 0 && all[i].type != all[i - 1].type) {
                        temp[++index] = [];
                    }
                    temp[index].push(all[i]);
                }
                this.links = temp;
            });
        },
        add: function() {
            this.$refs.routerModal.openModel(
                "添加地址",
                "/project/detail/link/add?projectId=" + this.search.projectId
            );
        },
        edit: function(linkId) {
            this.$refs.routerModal.openModel(
                "编辑地址",
                "/project/detail/link/edit?linkId=" + linkId
            );
        }
    }
};
</script>
