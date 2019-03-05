<template>
    <div>
        <!--操作-->
        <Row class="mb-3" type="flex" justify="space-between">
            <Row type="flex" class="flex-grow">
                <Select v-model="model2" class="w-15 mr-3" placeholder="请选择时间节点">
                    <Option value="1">1</Option>
                </Select>
                <Input class="w-15 mr-3" placeholder="请输入文件名"></Input>
                <Button class="bg-white" type="primary" ghost>搜索</Button>
            </Row>
            <div>
                <ButtonGroup class="bg-white">
                    <Button type="primary" ghost>添加文件</Button>
                    <Button type="primary" ghost>添加文件夹</Button>
                </ButtonGroup>
            </div>
        </Row>
        <!--内容展示区-->
        <div class="bg-white p-3">
            <div></div>
        </div>
    </div>
</template>

<script>
export default {};
</script>

<style>
</style>
