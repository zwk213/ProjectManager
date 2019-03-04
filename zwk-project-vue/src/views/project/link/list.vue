<template>
      <div class="relative">
    <ButtonGroup class="absolute" style="top:0;right:0">
      <Button type="primary">添加</Button>
    </ButtonGroup>

    <div class="bold mb-2">组名</div>
    <Row type="flex">
      <div class="bg-white w-20 p-3 border rounded">
        <Row type="flex" justify="space-between" class="bold mb-4">
          <span>姓名</span>
          <Button size="small" shape="circle" icon="ios-settings"></Button>
        </Row>
        <div>
          <span>职责：</span>
          <span>研发</span>
        </div>
        <div>
          <span>手机：</span>
          <span>17602131591</span>
        </div>
        <div>
          <span>邮箱：</span>
          <span>1017782318@qq.com</span>
        </div>
      </div>
    </Row>
  </div>
</template>

<script>
export default {};
</script>
