<template>
    <Row style="margin:-1rem">
        <!--顶部显示内容-->
        <div class="bg-white mb-3 relative">
            <!--操作-->
            <div class="absolute" style="top:1rem;right:1rem">
                <ButtonGroup>
                    <Button>编辑</Button>
                </ButtonGroup>
            </div>
            <!--信息-->
            <Row type="flex" class="p-3 pb-0 mb-3">
                <div class="bg-light mr-3" style="width:80px;height:80px;"></div>
                <div class="flex-column justify-content-between">
                    <div>
                        <span class="text-important mr-3">{{project.name}}</span>
                        <span class="text-light font-sm">{{project.type}}</span>
                    </div>
                    <div class="font-sm">
                        <div>
                            <span>当前节点：</span>
                            <span class="mr-3">一期测试</span>
                            <span class="mr-3">文件9</span>
                            <span class="mr-3">问题10</span>
                        </div>
                        <div class="text-light">
                            <span class="mr-3">创建时间：{{project.createDate}}</span>
                            <span>更新时间：{{project.updateDate}}</span>
                        </div>
                    </div>
                </div>
            </Row>
            <!--tab-->
            <div class="zwk-tab pl-3">
                <router-link
                    class="tab-btn"
                    v-for="item in tabs"
                    :key="item.name"
                    :to="item.link"
                    replace
                >{{item.name}}</router-link>
            </div>
        </div>

        <div class="pl-3 pr-3">
            <router-view/>
        </div>
    </Row>
</template>

<script>
export default {
    name: "project-detail",
    data: function() {
        return {
            tabs: [
                {
                    name: "简介",
                    link: {
                        path: "/project/detail/index",
                        query: this.$route.query
                    }
                },
                {
                    name: "时间线",
                    link: {
                        path: "/project/detail/schedule",
                        query: this.$route.query
                    }
                },
                {
                    name: "问题",
                    link: {
                        path: "/project/detail/issue",
                        query: this.$route.query
                    }
                },
                {
                    name: "参与人员",
                    link: {
                        path: "/project/detail/user",
                        query: this.$route.query
                    }
                },
                {
                    name: "链接/地址",
                    link: {
                        path: "/project/detail/link",
                        query: this.$route.query
                    }
                },
                {
                    name: "文档",
                    link: {
                        path: "/project/detail/file",
                        query: this.$route.query
                    }
                }
            ],
            project: {}
        };
    },
    created: function() {
        this.getProject();
    },
    methods: {
        getProject: function() {
            var search = { projectId: this.$route.query.projectId };
            this.$api.project.get(search).then(rsp => {
                this.project = rsp.data;
            });
        }
    }
};
</script>

<style>
</style>
