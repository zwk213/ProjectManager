<template>
    <div class="relative">
        <ButtonGroup class="absolute" style="top:0;right:0">
            <Button class="bg-white" type="primary" ghost>添加</Button>
        </ButtonGroup>

        <div class="bold mb-2">组名</div>
        <Row type="flex">
            <div class="bg-white w-25 p-3 border rounded">
                <Row type="flex" justify="space-between" align="bottom" class="mb-3">
                    <div>
                        <span class="font-lg bold">姓名</span>
                        <span class="bold font-sm ml-2">研发</span>
                    </div>
                    <Button size="small" shape="circle" icon="ios-settings"></Button>
                </Row>
                <div>
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
</template>

<script>
export default {};
</script>
