<template>
    <Form>
        <FormItem  v-for="item in columns" >
            <Input type="text" v-model="formInline.user" placeholder="Username">
                <Icon type="ios-person-outline" slot="prepend"></Icon>
            </Input>
        </FormItem>
    </Form>
</template>

<script>
export default {
    name:"DataForm",
    props:{
        columns:{
            type:Array
        }
    },

}
</script>

<style>

</style>
