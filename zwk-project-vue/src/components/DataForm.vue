<template>
    <Form>
        <FormItem v-for="item in columns" v-key="item.name">
            <template v-if="item.type=='input'">
                <Input type="text" v-model="item.value">
                    <Icon type="ios-person-outline" slot="prepend"></Icon>
                </Input>
            </template>
            <template v-if="item.type=='select'">
                <Select v-model="item.value">
                    <Option :value="option.value" v-for="option in item.options">{option.label}</Option>
                </Select>
            </template>
            <template v-if="item.type=='datepicker'">
                <DatePicker type="date" v-model="item.value"></DatePicker>
            </template>
        </FormItem>
    </Form>
</template>

<script>
export default {
    name: "DataForm",
    props: {
        columns: {
            type: Array
        }
    }
};
</script>

<style>
</style>
