const helper = {
    //元素与浏览器间距
    offset: function (node, offset) {
        if (!offset) {
            offset = {};
            offset.top = 0;
            offset.left = 0;
        }
        if (node == document.body) {
            return offset;
        }
        offset.top += node.offsetTop;
        offset.left += node.offsetLeft;
        return helper.node.offset(node.offsetParent, offset);
    }
}

export default helper