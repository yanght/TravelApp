layui.use(['form', 'jquery', 'layer', 'upload', 'treeSelect', 'laydate'], function () {
    var laydate = layui.laydate;
    var form = layui.form
        , $ = layui.jquery
        , layer = layui.layer
        , upload = layui.upload
        , treeSelect = layui.treeSelect;

    treeSelect.render({
        // 选择器
        elem: '#CategoryId',
        // 数据
        data: '/category/GetCategoryTree',
        // 异步加载方式：get/post，默认get
        type: 'get',
        // 占位符
        placeholder: '请选择分类',
        // 是否开启搜索功能：true/false，默认false
        search: true,
        // 点击回调
        click: function (d) {
            console.log(d);
        },
        // 加载完成后的回调函数
        success: function (d) {
            console.log(d);
            //                选中节点，根据id筛选
            //                treeSelect.checkNode('tree', 3);
            var id = $("#CategoryId").val();
            treeSelect.checkNode('CategoryId', id);
            //                获取zTree对象，可以调用zTree方法
            //                var treeObj = treeSelect.zTree('tree');
            //                console.log(treeObj);

            //                刷新树结构
            //                treeSelect.refresh();
        }
    });
    //普通图片上传
    var uploadInst = upload.render({
        elem: '#pictureUpload'
        , url: '/pictures/post/'
        , before: function (obj) {
            //预读本地文件示例，不支持ie8
            obj.preview(function (index, file, result) {
                $('#demo1').attr('src', result); //图片链接（base64）
                $('#demo1').attr('width', 100);
                $('#demo1').attr('height', 100);
            });
        }
        , done: function (res) {
            //如果上传失败
            if (!res.result || !res.result.isSuccess) {
                return layer.msg(res.result.msg);
            }
            //上传成功
            $("#Picture").val(res.result.data[0]);
            $("#demoText").remove();
        }
        , error: function () {
            //演示失败状态，并实现重传
            var demoText = $('#demoText');
            $("#Picture").val("");
            demoText.html('<span style="color: #FF5722;">上传失败</span> <a class="layui-btn layui-btn-xs demo-reload">重试</a>');
            demoText.find('.demo-reload').on('click', function () {
                uploadInst.upload();
            });
        }
    });

    //自定义验证规则
    form.verify({
        Describe: function (value) {
            if (value.length > 200) {
                return '线路简介不能大于200';
            }
        }
    });

    //监听提交
    form.on('submit(add)', function (data) {
        console.log(data.field);
        $.ajax({
            type: 'POST',
            url: "/project/editproject",
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(data.field),
            success: function (resp) { // 返回的RequestResult的json对象
                if (resp.State == 1) {
                    //发异步，把数据提交给php
                    layer.alert("增加成功", { icon: 6 }, function () {
                        // 获得frame索引
                        var index = parent.layer.getFrameIndex(window.name);
                        //关闭当前frame
                        parent.layer.close(index);
                    });
                } else {
                    layer.alert(resp.ErrorMessage);
                }
            }
        });
        return false;
    });

});