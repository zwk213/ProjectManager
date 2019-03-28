<template>
    <Drawer :width="width" :title="title" placement="right" v-model="show" @on-close="close">
        <div>
            <router-view></router-view>
        </div>
    </Drawer>
</template>

<script>
export default {
    name: "RouterDrawer",
    props: {
        width: {
            type: Number,
            default: 720
        }
    },
    data: function() {
        return {
            title: "",
            show: false
        };
    },
    methods: {
        open: function(title, path) {
            this.show = true;
            this.title = title;
            this.$router.push(path);
        },
        close: function() {
            this.show = false;
            this.$router.back();
        }
    }
};
</script>

