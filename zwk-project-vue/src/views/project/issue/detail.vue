<template>
    <Row class="font-md" type="flex">
        <Row type="flex" class="flex-nowrap w-half mb-2">
            <span class="flex-shrink w-5">时间节点</span>
            <span class="flex-shrink ml-2 mr-2 bold">:</span>
            <span>{{issue.scheduleName}}</span>
        </Row>
        <Row type="flex" class="flex-nowrap w-half mb-2">
            <span class="flex-shrink w-5">创建时间</span>
            <span class="flex-shrink ml-2 mr-2 bold">:</span>
            <span>{{issue.createDate}}</span>
        </Row>
        <Row type="flex" class="flex-nowrap w-half mb-2">
            <span class="flex-shrink w-5">优先级</span>
            <span class="flex-shrink ml-2 mr-2 bold">:</span>
            <span>{{issue.priority}}</span>
        </Row>
        <Row type="flex" class="flex-nowrap w-half mb-2">
            <span class="flex-shrink w-5">状态</span>
            <span class="flex-shrink ml-2 mr-2 bold">:</span>
            <span>{{issue.status}}</span>
        </Row>
        <Row type="flex" class="flex-nowrap w-half mb-5">
            <span class="flex-shrink w-5">创建人</span>
            <span class="flex-shrink ml-2 mr-2 bold">:</span>
            <span>{{issue.createName}}</span>
        </Row>
        <Row type="flex" class="flex-nowrap w-half mb-5">
            <span class="flex-shrink w-5">负责人</span>
            <span class="flex-shrink ml-2 mr-2 bold">:</span>
            <span>{{issue.principalName}}</span>
        </Row>

        <Row type="flex" class="flex-nowrap w-full mb-2">
            <span class="flex-shrink w-5">摘要</span>
            <span class="flex-shrink ml-2 mr-2 bold">:</span>
            <span class="bold">{{issue.summary}}</span>
        </Row>
        <Row type="flex" class="flex-nowrap w-full">
            <span class="flex-shrink w-5">详情</span>
            <span class="flex-shrink ml-2 mr-2 bold">:</span>
            <div v-html="issue.detail" class="bg-light p-2"></div>
        </Row>
    </Row>
</template>

<script>
export default {
    name: "",
    data: function() {
        return {
            search: {
                issueId: this.$route.query.issueId
            },
            issue: {}
        };
    },
    mounted: function() {
        this.getIssue();
    },
    methods: {
        getIssue: function() {
            this.$api.project.issue.get(this.search).then(rsp => {
                this.issue = rsp.data;
            });
        }
    }
};
</script>

<style>
</style>

