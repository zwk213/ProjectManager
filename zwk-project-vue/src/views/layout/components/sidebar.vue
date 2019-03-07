<template>
    <div>
        <Menu theme="dark" :active-name="active" :open-names="openNames" width="100%" accordion>
            <MenuItem name="/" to="/">工作台</MenuItem>
            <Submenu name="/user">
                <template slot="title">
                    <Icon type="ios-paper"/>用户管理
                </template>
                <MenuItem name="/user/list" to="/user/list">用户列表</MenuItem>
            </Submenu>
            <Submenu name="/project">
                <template slot="title">
                    <Icon type="ios-paper"/>项目管理
                </template>
                <!-- <MenuItem name="/project/mine" to="/project/mine">我的项目</MenuItem> -->
                <MenuItem name="/project/list" to="/project/list">项目列表</MenuItem>
            </Submenu>
        </Menu>
    </div>
</template>
<script>
export default {
    name: "layoutSidebar",
    data: function() {
        return {
            active: "/",
            openNames: []
        };
    },
    created: function() {
        this.init();
    },
    methods: {
        init: function() {
            var currentPath = this.$route.path;
            var openName = currentPath.substr(
                0,
                currentPath.split("/")[1].length + 1
            );
            this.openNames = [openName];
            this.active = currentPath;
        }
    }
};
</script>
