﻿$(function () {
    var l = abp.localization.getResource('Freight');


    var dataTable = $('#AwbNoRangesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            responsive: {
                details: {
                    type: 'column'
                }
            },
            ajax: abp.libs.datatables.createAjax(dolphin.freight.settings.awbNoRanges.awbNoRange.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('Settings.ItNoRanges.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('Settings.ItNoRanges.Delete'), //CHECK for the PERMISSION
                                    confirmMessage: function (data) {
                                        return l('ItNoRangeDeletionConfirmationMessage', data.record.startNo, data.record.endNo);
                                    },
                                    action: function (data) {
                                        dolphin.freight.settings.awbNoRanges.awbNoRange
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.message.success(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    //日期
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    //起始號碼
                    title: l('StartNo'),
                    data: "startNo"
                },
                {
                    //結束號碼
                    title: l('EndNo'),
                    data: "endNo"
                },
                {
                    //當前分配的號碼
                    title: l('CurrentNo'),
                    data: "currentNo"
                },
                {
                    //備註
                    title: l('Note'),
                    data: "note"
                }
            ]
        })
    );
  
    $('[type=search]').on('keyup', function () {
        dataTable.search(this.value).draw();
    });
 
    var createModal = new abp.ModalManager(abp.appPath + 'Settings/AwbNoRanges/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Settings/AwbNoRanges/EditModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewAwbNoRangeButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});