<template>
    <div class="relative">
        <ButtonGroup class="absolute" style="top:0;right:0">
            <Button class="bg-white" type="primary" ghost @click="add">添加</Button>
        </ButtonGroup>

        <div v-for="(item,index) in users" :key="item.primaryKey">
            <Row type="flex">
                <div class="bg-white w-25 p-3 border rounded">
                    <Row type="flex" justify="space-between" align="bottom" class="mb-3">
                        <div>
                            <span class="font-lg bold">姓名</span>
                            <span class="bold font-sm ml-2">研发</span>
                        </div>
                        <Button size="small" shape="circle" icon="ios-settings"></Button>
                    </Row>
                    <div class="font-sm">
                        <div>
                            <span>手机</span>
                            <span class="ml-2 mr-2 bold">:</span>
                            <span>17602131591</span>
                        </div>
                        <div>
                            <span>邮箱</span>
                            <span class="ml-2 mr-2 bold">:</span>
                            <span>1017782318@qq.com</span>
                        </div>
                        <Row type="flex" class="flex-nowrap">
                            <span class="flex-shrink">备注</span>
                            <span class="flex-shrink ml-2 mr-2 bold">:</span>
                            <span>备注备注备注备注备注备注备注备注备注备注备注备注备注备注备注</span>
                        </Row>
                    </div>
                </div>
            </Row>
        </div>
        <!--弹窗modal-->
        <RouterModal ref="routerModal"></RouterModal>
    </div>
</template>

<script>
import RouterModal from "@/components/RouterModal.vue";
export default {
    name: "project-user",
    components: { RouterModal },
    data: function() {
        return {
            search: {
                projectId: this.$route.query.projectId
            },
            users: []
        };
    },
    mounted: function() {
        this.getUserList();
    },
    methods: {
        getUserList: function() {
            this.$api.project.user.getList(this.search).then(rsp => {
                this.users = rsp.data;
            });
        },
        add: function() {
            this.$refs.routerModal.openModel(
                "添加用户",
                "/project/detail/user/add?projectId=" + this.search.projectId
            );
        },
        edit: function(userId) {
            this.$refs.routerModal.openModel(
                "编辑用户",
                "/project/detail/user/edit?userId=" + userId
            );
        }
    }
};
</script>
