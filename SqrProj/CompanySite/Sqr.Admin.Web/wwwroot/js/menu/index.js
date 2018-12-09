var $table = $('#table');
$(function () {
    $table.bootstrapTable({
        url: '/Menu/AllMenu',
        height: $(window).height(),
        striped: true,
        sidePagination: 'server',
        clickToSelect: true,
        singleSelect: true,
        idField: 'id',
        columns: [
            {
                field: 'ck',
                checkbox: true
            },
            {
                field: 'name',
                title: '名称'
            },
            // {field: 'id', title: '编号', sortable: true, align: 'center'},
            // {field: 'pid', title: '所属上级'},
            {
                field: 'controller',
                title: '控制器',
                sortable: true,
                align: 'center'
            },
            {
                field: 'action',
                title: '处理行为'
            },
            {
                field: 'parameters',
                title: '参数'
            }
        ],
        treeShowField: 'name',
        parentIdField: 'parentId',
        onLoadSuccess: function (data) {
            console.log('load');
            // jquery.treegrid.js
            $table.treegrid({
                // initialState: 'collapsed',
                treeColumn: 1,
                // expanderExpandedClass: 'glyphicon glyphicon-minus',
                // expanderCollapsedClass: 'glyphicon glyphicon-plus',
                onChange: function () {
                    $table.bootstrapTable('resetWidth');
                }
            });
        }
        // bootstrap-table-treetreegrid.js 插件配置
    });
});

function openEditWindow() {
    debugger;
    var rows = $table.bootstrapTable("getSelections");
    if (rows.length == 0) {
        return;
    }
    layer.open({
        type: 2,
        title:"编辑菜单",
        shade: false,
        area: ['600px', '400px'],
        maxmin: false,
        content: '/Menu/Edit/' + rows[0].id,
        zIndex: layer.zIndex, //重点1
        success: function (layero) {
            layer.setTop(layero); //重点2
        },
        error: function (a) {
            console.log(a);
        }
    });
}