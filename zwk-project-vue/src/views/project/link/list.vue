<template>
    <div class="relative">
        <ButtonGroup class="absolute" style="top:0;right:0">
            <Button class="bg-white" type="primary" ghost @click="addLink">添加链接</Button>
            <Button class="bg-white" type="primary" ghost @click="addGroup">添加组</Button>
        </ButtonGroup>

        <!-- 内容 -->
        <div>
            <!-- 分组数据 -->
            <div v-for="(group,index) in linkGroups" :key="index">
                <div class="bold mb-2">{{group.name}}</div>
                <Row type="flex">
                    <div
                        v-for="(item,index) in group.links"
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
            linkGroups: []
        };
    },
    mounted: function() {
        this.getLinkList();
    },
    methods: {
        getLinkList: function() {
            this.$api.project.linkGroup.getList(this.search).then(rsp => {
                this.linkGroups = rsp.data;
            });
        },
        addLink: function() {
            this.$refs.routerModal.openModel(
                "添加链接",
                "/project/detail/link/add?projectId=" + this.search.projectId
            );
        },
        addGroup: function() {
            this.$refs.routerModal.openModel(
                "添加组",
                "/project/detail/link/addGroup?projectId=" +
                    this.search.projectId
            );
        },
        edit: function(linkId) {
            this.$refs.routerModal.openModel(
                "编辑链接",
                "/project/detail/link/edit?linkId=" +
                    linkId +
                    "&projectId=" +
                    this.search.projectId
            );
        }
    }
};
</script>
