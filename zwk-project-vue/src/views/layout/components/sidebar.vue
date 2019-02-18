<template>
    <div>
        <Menu theme="dark" :active-name="active" width="100%">
            <MenuItem name="/">工作台</MenuItem>
            <Submenu name="2">
                <template slot="title">
                    <Icon type="ios-paper"/>用户管理
                </template>
                <MenuItem name="2-1">个人信息</MenuItem>
                <MenuItem name="2-2">用户列表</MenuItem>
            </Submenu>
            <Submenu name="3">
                <template slot="title">
                    <Icon type="ios-paper"/>项目管理
                </template>
                <MenuItem name="3-1">最近项目</MenuItem>
                <MenuItem name="3-2">项目列表</MenuItem>
            </Submenu>
        </Menu>
    </div>
</template>
<script>
export default {
  name: "layoutSidebar",
  data: function() {
    return {
      active: "/"
    };
  },
  created: function() {
    this.init();
  },
  methods: {
    init: function() {
      var currentPath = this.$router.history.current.path;
      this.active = currentPath;
    }
  }
};
</script>
