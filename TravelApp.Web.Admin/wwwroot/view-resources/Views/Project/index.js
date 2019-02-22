layui.use(['laydate', 'table'], function () {
    var laydate = layui.laydate;
    var table = layui.table;
    var form = layui.form;

    var _projectService = abp.services.app.project;

    //执行一个laydate实例
    laydate.render({
        elem: '#start' //指定元素
    });

    //执行一个laydate实例
    laydate.render({
        elem: '#end' //指定元素
    });

    var projectTab = table.render({
        elem: '#projectList'
        , url: '/project/ProjectList' //数据接口
        , page: true //开启分页
        , cols: [[ //表头
            { type: 'checkbox', fixed: 'left' }
            , { field: 'name', title: '名称' }
            , { field: 'categoryId', title: '分类Id' }
            , { field: 'price', title: '价格' }
            , { field: 'startDate', title: '发团日期' }
            , { field: 'isRecommend', title: '是否推荐' }
            , { field: 'state', title: '状态' }
            , { fixed: 'right', title: '操作', toolbar: '#optbar', width: 200 }
        ]]
    });

    //监听工具条
    table.on('tool(projectList)', function (obj) {
        var data = obj.data;
        if (obj.event === 'detail') {
            layer.msg('ID：' + data.id + ' 的查看操作');
        } else if (obj.event === 'del') {
            layer.confirm('真的删除行么', function (index) {
                obj.del();
                layer.close(index);
            });
        } else if (obj.event === 'edit') {
            //layer.alert('编辑行：<br>' + JSON.stringify(data))
            x_admin_show("编辑线路", "/project/addproject?id=" + data.id);
        }
    });

    form.on('submit(searchProject)', function (data) {
        console.log(data.field) //当前容器的全部表单字段，名值对形式：{name: value}
        projectTab.reload({
            where: data.field
            , page: {
                curr: 1 //重新从第 1 页开始
            }
        });
        return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
    })
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