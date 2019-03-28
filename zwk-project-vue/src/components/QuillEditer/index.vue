<template>
    <div class="ql-container bg-white">
        <quill-editor
            v-model="content"
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
        html: {
            type: String
        }
    },
    data() {
        return {
            content: this.html,
            quillOption: {} //quillConfig
        };
    },
    mounted: function() {},
    methods: {
        onEditorReady(editor) {}, // 准备编辑器
        onEditorBlur() {}, // 失去焦点事件
        onEditorFocus() {}, // 获得焦点事件
        onEditorChange() {} // 内容改变事件
    },
    computed: {
        editor() {
            return this.$refs.myQuillEditor.quill;
        }
    }
};
</script>
