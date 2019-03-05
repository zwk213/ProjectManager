<template>
    <div class="relative">
        <ButtonGroup class="absolute" style="top:0;right:0">
            <Button class="bg-white" type="primary" ghost>添加</Button>
        </ButtonGroup>

        <div class="bold mb-2">组名</div>
        <Row type="flex">
            <div class="bg-white w-25 p-3 border rounded">
                <Row type="flex" justify="space-between" class="mb-3">
                    <span class="font-lg bold">地址名称</span>
                    <Button size="small" shape="circle" icon="ios-settings"></Button>
                </Row>
                <div>
                    <div>
                        <span>地址</span>
                        <span class="ml-2 mr-2 bold">:</span>
                        <a href="https://www.baidu.com/" target="_blank">https://www.baidu.com/</a>
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
