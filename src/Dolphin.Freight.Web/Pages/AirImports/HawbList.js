var l = abp.localization.getResource('Freight');
var dataTable;
$(function () {
    dataTable = $('#HawbListTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[2, "asc"]],
            searching: true,
            scrollX: true,
            responsive: {
                details: {
                    type: 'column'
                }
            },
            ajax: abp.libs.datatables.createAjax(dolphin.freight.importExport.airImports.airImportHawb.queryList),
            columnDefs: [
                {
                    className: 'dtr-control',
                    orderable: false,
                    "defaultContent": ""
                },
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('Settings.ItNoRanges.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        if (data.record.isLocked) {

                                        }
                                        location.href = 'EditHawb?Id=' + data.record.mawbId + '&mawbid=' + data.record.id;

                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: function (data) {

                                        return !data.isLocked && abp.auth.isGranted('Settings.ItNoRanges.Delete')
                                    },

                                    action: function (data) {
                                        if (!data.record.isLocked) {
                                            abp.message.confirm(l('DeletionConfirmationMessage'))
                                                .then(function (confirmed) {
                                                    if (confirmed) {
                                                        dolphin.freight.importExport.airImports.airImportmawbNo
                                                            .delete(data.record.id)
                                                            .then(function () {
                                                                abp.message.success(l('SuccessfullyDeleted'));
                                                                dataTable.ajax.reload();
                                                            });
                                                    }
                                                });

                                        } else {
                                            abp.message.warn("鎖定不能刪除")
                                        }

                                        /*
                                        if (!data.record.isLocked) {
                                            dolphin.freight.importExport.oceanExports.oceanExportMbl
                                                .delete(data.record.id)
                                                .then(function () {
                                                    abp.message.success(l('SuccessfullyDeleted'));
                                                    dataTable.ajax.reload();
                                                });
                                        } else {
                                            abp.message.warn("鎖定不能刪除")
                                        }*/

                                    }
                                }
                            ]
                    }
                },
                {
                    //是否鎖定
                    title: l('IsLocked'),
                    orderable: false,
                    render: function (data, type, row, meta) {
                        if (row.isLocked)
                            return "<a href='javascript:lock(\"" + row.id + "\")' class='btn-lock' id='lock_" + row.id + "'><i class='fa-lg fa-solid fa-lock fa-lg'></i><span>解鎖</span></a>";
                        else
                            return "<a href='javascript:lock(\"" + row.id + "\")' class='btn-lock action' id='lock_" + row.id + "'><i class='fa-lg fa-solid fa-lock-open'></i><span>上鎖</span></a>";
                    }
                },
                {
                    //Hawb號碼
                    title: l('HawbNo'),
                    data: "hawbNo"
                },
                {
                    //Mawb號碼
                    title: l('MawbId'),
                    data: "mawbId"
                },
                {
                    //Departure
                    title: l('QuotationId'),
                    data: "quotationId"
                },
                {
                    //Destination
                    title: l('Hsn'),
                    data: "hsn"
                },
                {
                    //ActualShippedr
                    title: l('ShipperId'),
                    data: "shipperId"
                },
                {
                    //Consignee
                    title: l('ConsigneeId'),
                    data: "consigneeId"
                },
                {
                    //OverseaAgent
                    title: l('SalesId'),
                    data: "salesId"
                },
     
                {
                    //A/P Balance
                    title: l('Incoterms'),
                    data: "incoterms"
                },
                {
                    //Booking No.
                    title: l('Mark'),
                    data: "mark"
                },
                {
                    //OP
                    title: l('Description'),
                    data: "description"
                },
                {
                    //Status
                    title: l('Remark'),
                    data: "remark"
                },


            ]
        })
    );

    $('[type=search]').on('keyup', function () {
        dataTable.search(this.value).draw();
    });
});

