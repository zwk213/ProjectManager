const uploadConfig = {
    action: '', // 图片上传地址
    methods: 'POST', // 图片上传方式
    token: '', // 如果需要token验证，假设你的token有存放在sessionStorage
    name: 'img', // 文件的参数名
    size: 500, // 图片大小，单位为Kb, 1M = 1024Kb
    accept: 'image/png, image/gif, image/jpeg, image/bmp, image/x-icon' // 可上传的图片格式
}

const toolOptions = [
    ['bold', 'italic', 'underline', 'strike'],
    ['blockquote', 'code-block'],
    [{
        'header': 1
    }, {
        'header': 2
    }],
    [{
        'list': 'ordered'
    }, {
        'list': 'bullet'
    }],
    [{
        'script': 'sub'
    }, {
        'script': 'super'
    }],
    [{
        'indent': '-1'
    }, {
        'indent': '+1'
    }],
    [{
        'direction': 'rtl'
    }],
    [{
        'size': ['small', false, 'large', 'huge']
    }],
    [{
        'header': [1, 2, 3, 4, 5, 6, false]
    }],
    [{
        'color': []
    }, {
        'background': []
    }],
    [{
        'font': []
    }],
    [{
        'align': []
    }],
    ['clean'],
    ['link', 'image', 'video']
];

const handlers = {
    image: function image() {
        // debugger
        // var self = this;
        // var fileInput = this.container.querySelector('input.ql-image[type=file]');
        // if (fileInput === null) {
        //     fileInput = document.createElement("input");
        //     fileInput.setAttribute('type', 'file');
        //     //this.container.appendChild(fileInput);
        // }
        //fileInput.click();
    }
};

export default {
    placeholder: '',
    theme: 'snow', // 主题
    modules: {
        toolbar: {
            container: toolOptions, // 工具栏选项
            //handlers: handlers // 事件重写
        }
    }
};