<template>
    <div class="bg-white p-3 border rounded relative">
        <!--操作-->
        <Button class="absolute" type="primary" style="top:1rem;right:1rem;">添加</Button>
        <!--内容-->
        <Timeline pending>
            <TimelineItem color="red">
                <p class="time">1976年</p>
                <p class="content">Apple I 问世Apple I 问世Apple I 问世Apple I 问世Apple I 问世Apple I 问世</p>
                <p class="content">Apple I 问世Apple I 问世Apple I 问世Apple I 问世Apple I 问世Apple I 问世</p>
            </TimelineItem>
            <TimelineItem color="green">
                <p class="time">1976年</p>
                <p class="content">Apple I 问世</p>
            </TimelineItem>
            <TimelineItem color="green">
                <p class="time">1976年</p>
                <p class="content">Apple I 问世</p>
            </TimelineItem>
            <TimelineItem>
                <a>查看更多</a>
            </TimelineItem>
        </Timeline>
    </div>
</template>

<script>
export default {};
</script>
