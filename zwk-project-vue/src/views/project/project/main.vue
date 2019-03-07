<template>
    <Row type="flex">
        <div class="w-30 mr-3">
            <div class="p-3 bg-white border rounded">
                <div class="bold mb-3">项目信息</div>
                <div>
                    <Row type="flex">
                        <span class="w-5">名称</span>
                        <span class="ml-2 mr-2 bold">:</span>
                        <span>{{project.name}}</span>
                    </Row>
                    <Row type="flex">
                        <span class="w-5">Logo</span>
                        <span class="ml-2 mr-2 bold">:</span>
                        <span>{{project.logo}}</span>
                    </Row>
                    <Row type="flex">
                        <span class="w-5">状态</span>
                        <span class="ml-2 mr-2 bold">:</span>
                        <span>{{project.status}}</span>
                    </Row>
                    <Row type="flex">
                        <span class="w-5">类型</span>
                        <span class="ml-2 mr-2 bold">:</span>
                        <span>{{project.type}}</span>
                    </Row>
                    <Row type="flex">
                        <span class="w-5">编码</span>
                        <span class="ml-2 mr-2 bold">:</span>
                        <span>{{project.primaryKey}}</span>
                    </Row>
                    <Row type="flex">
                        <span class="w-5">创建人</span>
                        <span class="ml-2 mr-2 bold">:</span>
                        <span>{{project.createBy}}</span>
                    </Row>
                    <Row type="flex">
                        <span class="w-5">创建时间</span>
                        <span class="ml-2 mr-2 bold">:</span>
                        <span>{{project.createDate}}</span>
                    </Row>
                    <Row type="flex">
                        <span class="w-5">更新人</span>
                        <span class="ml-2 mr-2 bold">:</span>
                        <span>{{project.updateBy}}</span>
                    </Row>
                    <Row type="flex">
                        <span class="w-5">更新时间</span>
                        <span class="ml-2 mr-2 bold">:</span>
                        <span>{{project.updateDate}}</span>
                    </Row>
                </div>
            </div>
        </div>
        <div class="flex-grow">
            <div class="p-3 bg-white border rounded">
                <div class="bold mb-3">当前统计信息</div>
                <div class="mb-2">
                    <span>时间节点</span>
                    <span class="ml-2 mr-2 bold">:</span>
                    <span>XXXX项目管理</span>
                </div>
                <div class="mb-2">
                    <span>参与人员</span>
                    <span class="ml-2 mr-2 bold">:</span>
                    <span>XXXX项目管理</span>
                </div>
                <div class="mb-2">
                    <span>链接地址</span>
                    <span class="ml-2 mr-2 bold">:</span>
                    <span>XXXX项目管理</span>
                </div>
                <div class="mb-2">
                    <span>时间节点</span>
                    <span class="ml-2 mr-2 bold">:</span>
                    <span>XXXX项目管理</span>
                </div>
            </div>
        </div>
    </Row>
</template>

<script>
export default {
    name: "project-detail-main",
    data: function() {
        return {
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
