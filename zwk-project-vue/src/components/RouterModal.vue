<template>
    <Modal v-model="model.show" :title="model.title" @on-cancel="closeModel" footer-hide>
        <div>
            <router-view></router-view>
        </div>
    </Modal>
</template>

<script>
export default {
    name: "RouterModal",
    data: function() {
        return {
            model: {
                show: false,
                title: ""
            }
        };
    },
    methods: {
        openModel: function(title, path) {
            this.model.show = true;
            this.model.title = title;
            this.$router.push(path);
        },
        closeModel: function() {
            this.$router.back();
        }
    }
};
</script>
