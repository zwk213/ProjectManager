<template>
    <div class="ql-container bg-white">
        <quill-editor
            v-model="value"
            ref="myQuillEditor"
            :options="quillOption"
            @blur="onEditorBlur($event)"
            @focus="onEditorFocus($event)"
            @change="onEditorChange($event)"
        ></quill-editor>
    </div>
</template>
<script>
import { quillEditor } from "vue-quill-editor"; //调用编辑器
import "quill/dist/quill.core.css";
import "quill/dist/quill.snow.css";
import "quill/dist/quill.bubble.css";
//import quillConfig from "./config.js";

export default {
    name: "QuillEditer",
    components: {
        quillEditor
    },
    props: {
        value: {
            type: String
        }
    },
    data() {
        return {
            quillOption: {} //quillConfig
        };
    },
    mounted: function() {},
    methods: {
        // 准备编辑器
        onEditorReady(editor) {},
        // 失去焦点事件
        onEditorBlur() {},
        // 获得焦点事件
        onEditorFocus() {},
        // 内容改变事件
        onEditorChange() {
            this.$emit("input", this.value);
        }
    },
    computed: {
        editor() {
            return this.$refs.myQuillEditor.quill;
        }
    }
};
</script>
