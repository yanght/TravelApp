﻿layui.use(['laydate', 'table'], function () {
    var laydate = layui.laydate;
    var table = layui.table;

    var _projectService = abp.services.app.project;

    //执行一个laydate实例
    laydate.render({
        elem: '#start' //指定元素
    });

    //执行一个laydate实例
    laydate.render({
        elem: '#end' //指定元素
    });

    table.render({
        elem: '#projectList'
        , url: '/project/ProjectList' //数据接口
        , page: true //开启分页
        , cols: [[ //表头
            { field: 'name', title: '名称' }
            , { field: 'categoryId', title: '分类Id' }
            , { field: 'price', title: '价格' }
            , { field: 'startDate', title: '发团日期' }
            , { field: 'isRecommend', title: '是否推荐' }
            , { field: 'state', title: '状态' }
            , { field: 'id', title: '操作', width: 200, templet: '#titleTpl' }
        ]]
    });

});

/*用户-停用*/
function member_stop(obj, id) {
    layer.confirm('确认要停用吗？', function (index) {

        if ($(obj).attr('title') == '启用') {

            //发异步把用户状态进行更改
            $(obj).attr('title', '停用')
            $(obj).find('i').html('&#xe62f;');

            $(obj).parents("tr").find(".td-status").find('span').addClass('layui-btn-disabled').html('已停用');
            layer.msg('已停用!', { icon: 5, time: 1000 });

        } else {
            $(obj).attr('title', '启用')
            $(obj).find('i').html('&#xe601;');

            $(obj).parents("tr").find(".td-status").find('span').removeClass('layui-btn-disabled').html('已启用');
            layer.msg('已启用!', { icon: 5, time: 1000 });
        }

    });
}
/*用户-删除*/
function member_del(obj, id) {
    layer.confirm('确认要删除吗？', function (index) {
        //发异步删除数据
        $(obj).parents("tr").remove();
        layer.msg('已删除!', { icon: 1, time: 1000 });
    });
}
function delAll(argument) {

    var data = tableCheck.getData();

    layer.confirm('确认要删除吗？' + data, function (index) {
        //捉到所有被选中的，发异步进行删除
        layer.msg('删除成功', { icon: 1 });
        $(".layui-form-checked").not('.header').parents('tr').remove();
    });
}