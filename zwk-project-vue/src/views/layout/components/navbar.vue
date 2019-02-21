<template>
    <Row class="pl-3 pr-3 border-bottom" type="flex" justify="space-between" align="middle">
        <Breadcrumb>
            <BreadcrumbItem v-for="item in breadcrumb" :key="item.path">
                <strong>{{ item.name }}</strong>
            </BreadcrumbItem>
        </Breadcrumb>
        <Row>
            <Dropdown style="margin-left: 20px" placement="bottom-end" trigger="click">
                <a href="javascript:void(0)">用户名
                    <Icon type="ios-arrow-down"></Icon>
                </a>
                <DropdownMenu slot="list">
                    <DropdownItem>信息</DropdownItem>
                    <DropdownItem>退出</DropdownItem>
                </DropdownMenu>
            </Dropdown>
        </Row>
    </Row>
</template>
<script>
export default {
  name: "navbar",
  data: function() {
    return {
      breadcrumb: null
    };
  },
  watch: {
    $route: function() {
      this.getBreadcrumb();
    }
  },
  created: function() {
    this.getBreadcrumb();
  },
  methods: {
    getBreadcrumb: function() {
      let matched = this.$route.matched.filter(item => item.name);
      this.breadcrumb = matched;
    }
  }
};
</script>
