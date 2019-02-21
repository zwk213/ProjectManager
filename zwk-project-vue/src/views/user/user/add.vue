<template>
  <Row>
    <DataForm :columns="columns" :apiUrl="apiUrl"></DataForm>
  </Row>
</template>

<script>
import DataForm from "@/components/DataForm.vue";

export default {
  name: "user-add",
  components: { DataForm },
  data: function() {
    return {
      apiUrl: this.$api.user.url.add,
      columns: [
        { type: "input", column: "userName", label: "用户名" },
        { type: "input", column: "password", label: "密码" },
        { type: "input", column: "phone", label: "手机号" },
        { type: "input", column: "email", label: "邮箱" },
      ]
    };
  }
};
</script>
