<template>
    <div class="relative">
        <!--操作-->
        <Button class="absolute" type="primary" style="top:1rem;right:1rem;" @click="addSchedule">添加</Button>
        <!--内容-->
        <Timeline pending style="margin-right:100px;" class="bg-white p-3 rounded">
            <TimelineItem color="red" v-for="item in schedules" :key="item.primaryKey">
                <p class="content bold">{{item.name}}</p>
                <p class="content">
                    <span class="mr-5">开始时间：{{item.start}}</span>
                    <span>结束时间：{{item.end}}</span>
                </p>
                <p class="content">{{item.remark}}</p>
            </TimelineItem>
            <!-- <TimelineItem>
                <a>查看更多</a>
            </TimelineItem>-->
        </Timeline>
        <!--弹窗modal-->
        <RouterModal ref="routerModal"></RouterModal>
    </div>
</template>

<script>
import RouterModal from "@/components/RouterModal.vue";

export default {
    name: "project-schedule",
    components: { RouterModal },
    data: function() {
        return {
            search: {
                projectId: this.$route.query.projectId
            },
            schedules: []
        };
    },
    mounted: function() {
        this.getScheduleList();
    },
    methods: {
        getScheduleList: function() {
            this.$api.project.schedule.getList(this.search).then(rsp => {
                this.schedules = rsp.data;
            });
        },
        addSchedule: function() {
            this.$refs.routerModal.openModel(
                "添加时间节点",
                "/project/detail/schedule/add?projectId=" +
                    this.search.projectId
            );
        },
        editSchedule: function() {
            this.$refs.routerModal.openModel(
                "添加时间节点",
                "/project/detail/schedule/edit?projectId=" +
                    this.search.projectId
            );
        }
    }
};
</script>
