<template>
  <Row style="margin:-1rem">
    <!--顶部显示内容-->
    <Row type="flex" class="bg-white border-bottom p-3 mb-3">
      <div class="bg-light mr-3" style="width:80px;height:80px;"></div>
      <div class="flex-column justify-content-between">
        <div class="text-important">{{user.userName}}</div>
        <div class="flex-row text-light font-sm">
          <div class="flex-column w-20">
            <div>联系方式：{{user.phone}}</div>
            <div>电子邮箱：{{user.email}}</div>
          </div>
          <div class="flex-column w-20">
            <div>创建时间：{{user.createDate}}</div>
            <div>更新邮箱：{{user.updateDate}}</div>
          </div>
        </div>
      </div>
    </Row>
  </Row>
</template>

<script>
export default {
  name: "user-detail",
  data: function() {
    return {
      user: {}
    };
  },
  created: function() {
    this.getUser();
  },
  methods: {
    getUser: function() {
      var search = { userId: this.$route.query.userId };
      this.$api.user.get(search).then(rsp => {
        this.user = rsp.data;
      });
    }
  }
};
</script>

<style>
</style>
