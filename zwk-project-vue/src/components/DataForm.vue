<template>
  <Form label-position="right" :label-width="100">
    <FormItem v-for="item in columns" :key="item.column" :label="item.label">
      <template v-if="item.type=='input'">
        <Input type="text" v-model="item.model"></Input>
      </template>
      <template v-if="item.type=='select'">
        <Select v-model="item.model">
          <Option
            :value="option.value"
            v-for="option in item.options"
            :key="option.value"
          >{{option.label}}</Option>
        </Select>
      </template>
      <template v-if="item.type=='datepicker'">
        <DatePicker type="date" v-model="item.model"></DatePicker>
      </template>
    </FormItem>
    <FormItem>
      <Button type="primary" @click="submit">提交</Button>
    </FormItem>
  </Form>
</template>

<script>
export default {
  name: "DataForm",
  props: {
    columns: {
      type: Array
    },
    apiUrl: {
      type: String
    }
  },
  methods: {
    submit: function() {
      var form={};
      for (let i = 0; i < this.columns.length; i++) {
        form[this.columns[i].column] = this.columns[i].model;
      }
      this.$api.post(this.apiUrl,form).then(rsp=>{
        alert("添加成功")
      });
    }
  }
};
</script>

<style>
</style>
