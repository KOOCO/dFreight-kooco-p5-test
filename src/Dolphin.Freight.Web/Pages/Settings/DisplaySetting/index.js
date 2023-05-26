$(function () {
    var l = abp.localization.getResource('Freight');

    var dataTable = $('#DisplaySetting').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(dolphin.freight.settings.displaySetting.displaySetting.getList),
            columns: [
                {
                    //航空公司/代理
                    title: l('companyType'),
                    orderable: false,
                    searchable: false,
                    data: "CompleteDay"
                },           
            ],

        })
    );

    $('[type=search]').on('keyup', function () {
        dataTable.search(this.value).draw();
    });

    var createModal = new abp.ModalManager(abp.appPath + 'Settings/DisplaySetting/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Settings/DisplaySetting/EditModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });


}); 