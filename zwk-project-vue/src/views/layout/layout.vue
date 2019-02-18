<template>
    <div>
        <sidebar class="app-sidebar"></sidebar>
        <navbar class="app-navbar"></navBar>
        <app-main class="app-main"></app-main>
    </div>
</template>
<script>
import SideBar from "./components/sidebar.vue";
import NavBar from "./components/navbar.vue";
import AppMain from "./components/appMain.vue";

export default {
    name: "layout",
    components: {
        "sidebar": SideBar,
        "navbar": NavBar,
        "app-main": AppMain
    }
};
</script>
<style>
.app-sidebar {
    position: fixed;
    left: 0;
    top: 0;
    bottom: 0;
    width: 14rem;
    background-color:#2b333e;
    padding-top: 3.5rem;
    z-index: 10;
}

.app-navbar {
    position: fixed;
    left: 14rem;
    top: 0;
    right: 0;
    bottom: 0;
    height: 3.5rem;
    background-color: #fff;
    z-index: 10;
}

.app-main {
    margin-left: 14rem;
    margin-top: 3.5rem;
    padding: 1rem 1rem 0 1rem;
}
</style>
