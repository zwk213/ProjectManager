<template>
    <div class="relative">
        <ButtonGroup class="absolute" style="top:0;right:0">
            <Button class="bg-white" type="primary" ghost @click="addUser" icon="ios-person">添加参与人员</Button>
            <Button class="bg-white" type="primary" ghost @click="addGroup" icon="ios-people">添加组</Button>
        </ButtonGroup>

        <!-- 内容 -->
        <div class="pt-2">
            <!-- 分组数据 -->
            <div v-for="(group,index) in userGroups" :key="group.primaryKey">
                <div class="bold mb-2">{{group.name}}</div>
                <Row type="flex">
                    <div
                        v-for="(item,index) in group.users"
                        :key="item.primaryKey"
                        class="bg-white w-20 p-3 border rounded mr-3 mb-3"
                    >
                        <Row type="flex" justify="space-between" align="bottom" class="mb-3">
                            <div class="bold">{{item.userName}}</div>
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
                                <span>手机</span>
                                <span class="ml-2 mr-2 bold">:</span>
                                <span>{{item.phone}}</span>
                            </div>
                            <div>
                                <span>邮箱</span>
                                <span class="ml-2 mr-2 bold">:</span>
                                <span>{{item.email}}</span>
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
    name: "project-user",
    components: { RouterModal },
    data: function() {
        return {
            search: {
                projectId: this.$route.query.projectId
            },
            userGroups: []
        };
    },
    mounted: function() {
        this.getUserList();
    },
    methods: {
        getUserList: function() {
            this.$api.project.userGroup.getList(this.search).then(rsp => {
                this.userGroups = rsp.data;
            });
        },
        addUser: function() {
            this.$refs.routerModal.openModel(
                "添加参与人员",
                "/project/detail/user/add?projectId=" + this.search.projectId
            );
        },
        addGroup: function() {
            this.$refs.routerModal.openModel(
                "添加组",
                "/project/detail/user/addGroup?projectId=" +
                    this.search.projectId
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
