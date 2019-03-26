<template>
    <div class="relative">
        <!--操作-->
        <Button
            class="absolute bg-white"
            type="primary"
            ghost
            style="right:0;"
            @click="addSchedule"
        >添加</Button>
        <!--内容-->
        <Timeline pending style="margin-right:75px;" class="bg-white p-3 rounded">
            <TimelineItem
                v-for="(item, index) in schedules"
                :key="item.primaryKey"
                v-bind:color="index?'green':'red'"
            >
                <p class="content">
                    <span class="bold">{{item.name}}</span>
                    <!--编辑-->
                    <Button
                        size="small"
                        shape="circle"
                        icon="ios-settings"
                        class="float-right"
                        @click="editSchedule(item.primaryKey)"
                    ></Button>
                </p>
                <p class="content">
                    <span>{{item.start}}</span>
                    <span :class="{'hiddle':!item.end}" class="ml-4 mr-4">--</span>
                    <span :class="{'hiddle':!item.end}">{{item.end}}</span>
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
        editSchedule: function(scheduleId) {
            this.$refs.routerModal.openModel(
                "编辑时间节点",
                "/project/detail/schedule/edit?scheduleId=" + scheduleId
            );
        }
    }
};
</script>
