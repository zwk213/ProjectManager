<template>
    <Form ref="data-form" :model="dataForm" label-position="right" :label-width="100">
        <FormItem
            v-for="(item, index) in dataForm.items"
            :key="index"
            :label="item.label"
            :prop="'items.' + index + '.value'"
            :rules="item.rules"
            v-bind:class="{'hiddle':item.hiddle}"
        >
            <!--输入框-->
            <template v-if="item.type=='input'">
                <Input type="text" v-model="item.value" :disabled="item.disabled"></Input>
            </template>
            <!--文本域-->
            <template v-if="item.type=='textarea'">
                <Input
                    type="textarea"
                    v-model="item.value"
                    :autosize="{minRows: 2,maxRows: 10}"
                    :disabled="item.disabled"
                ></Input>
            </template>
            <!--下拉框-->
            <template v-if="item.type=='select'">
                <Select v-model="item.value" :disabled="item.disabled">
                    <Option
                        :value="option.value"
                        v-for="option in item.options"
                        :key="option.value"
                    >{{option.label}}</Option>
                </Select>
            </template>
            <!--时间选择器-->
            <template v-if="item.type=='datepicker'" :disabled="item.disabled">
                <DatePicker type="date" v-model="item.value" value="yyyy-MM-dd"></DatePicker>
            </template>
        </FormItem>
        <FormItem>
            <Button type="primary" @click="submit">提交</Button>
        </FormItem>
    </Form>
</template>

<script>
// var model = {
//     type: "类型", //input select datepicker
//     label: "输入内容释义",
//     field: "字段名",
//     value: "数据值",
//     hiddle: false,、
//     disabled: false,
//     options: "select类型的枚举值",
//     rules: [] //验证相关
// };
export default {
    name: "DataForm",
    props: {
        model: {
            type: Array
        },
        submitUrl: {
            type: String
        }
    },
    data: function() {
        return {
            dataForm: {
                items: this.model
            }
        };
    },
    methods: {
        submit: function() {
            debugger;
            var form = {};
            for (let i = 0; i < this.dataForm.items.length; i++) {
                var temp = this.dataForm.items[i];
                //时间格式化，否则后台接收有问题
                form[temp.field] =
                    temp.value instanceof Date
                        ? temp.value.format()
                        : temp.value;
            }
            this.$refs["data-form"].validate(valid => {
                if (valid) {
                    this.$api.post(this.submitUrl, form).then(rsp => {
                        alert("提交成功");
                    });
                }
            });
        }
    }
};
</script>

<style>
</style>
