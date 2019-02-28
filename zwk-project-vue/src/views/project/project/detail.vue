<template>
    <Row style="margin:-1rem">
        <!--顶部显示内容-->
        <div class="bg-white mb-3">
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
                <router-link class="active" to="/project/detail">基本信息</router-link>
                <router-link to="/project/detail/schedule">时间线</router-link>
                <router-link to="/project/detail/issue">问题</router-link>
                <router-link to="/project/detail/user">参与人员</router-link>
                <router-link to="/project/detail/link">链接/地址</router-link>
                <router-link to="/project/detail/file">文档</router-link>
                <router-link to="/project/detail/log">日志</router-link>
            </div>
        </div>

        <router-view/>
    </Row>
</template>

<script>
export default {
    name: "project-detail",
    data: function() {
        return {
            project: {}
        };
    },
    mounted: function() {
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
