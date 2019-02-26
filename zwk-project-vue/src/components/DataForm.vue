<template>
    <Form ref="data-form" label-position="right" :label-width="100">
        <FormItem
            v-for="item in formItems"
            :key="item.field"
            :label="item.label"
            :rules="item.rules"
            :prop="item.field"
        >
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
//     type: "类型", //input select datepicker
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
    data() {
        return {
            formItems: this.model
        };
    },
    watch: {
        model: {
            handler() {},
            deep: true
        }
    },
    methods: {
        submit: function() {
            var form = {};
            for (let i = 0; i < this.model.length; i++) {
                var temp = this.model[i];
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
