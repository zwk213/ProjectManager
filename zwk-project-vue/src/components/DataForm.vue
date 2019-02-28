<template>
    <Form ref="data-form" :model="dataForm" label-position="right" :label-width="100">
        <FormItem
            v-for="(item, index) in dataForm.items"
            :key="index"
            :label="item.label"
            :prop="'items.' + index + '.value'"
            :rules="item.rules"
        >
            <!--固定值-->
            <template v-if="item.type=='static'">
                <Input v-model="item.value" disabled/>
            </template>
            <!--输入框-->
            <template v-if="item.type=='input'">
                <Input type="text" v-model="item.value"></Input>
            </template>
            <!--下拉框-->
            <template v-if="item.type=='select'">
                <Select v-model="item.value">
                    <Option
                        :value="option.value"
                        v-for="option in item.options"
                        :key="option.value"
                    >{{option.label}}</Option>
                </Select>
            </template>
            <!--时间选择器-->
            <template v-if="item.type=='datepicker'">
                <DatePicker type="date" v-model="item.value"></DatePicker>
            </template>
        </FormItem>
        <FormItem>
            <Button type="primary" @click="submit">提交</Button>
        </FormItem>
    </Form>
</template>

<script>
// var model = {
//     type: "类型", //input select datepicker static【固定值，不编辑】
//     label: "输入内容释义",
//     field: "字段名",
//     value: "数据值",
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
            var form = {};
            for (let i = 0; i < this.dataForm.items.length; i++) {
                var temp = this.dataForm.items[i];
                form[temp.field] = temp.value;
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
