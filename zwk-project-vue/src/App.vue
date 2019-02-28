<template>
    <div id="app">
        <router-view/>
    </div>
</template>

<script>
export default {
    name: "App",
    created: function() {
        //页面加载初始化store
        localStorage.getItem("store") &&
            this.$store.replaceState(
                Object.assign(
                    this.$store.state,
                    JSON.parse(localStorage.getItem("store"))
                )
            );

        //页面刷新保存store
        window.addEventListener("beforeunload", () => {
            localStorage.setItem("store", JSON.stringify(this.$store.state));
        });
    }
};
</script>