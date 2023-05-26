$(function () {
    var l = abp.localization.getResource('Freight');


    var dataTable = $('#MblListTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            processing: true,
            ajax: abp.libs.datatables.createAjax(dolphin.freight.importExport.airImports.airImportMawb.getList),
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
                                        if (data.record.isLocked) {

                                        }
                                        location.href = 'EditMawb?Id=' + data.record.id;

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
                                                        dolphin.freight.importExport.airImports.airImportMawb
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
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('filingNo'),
                    data: 'filingNo'
                },
                {
                    title: l('mawbNo'),
                    data: "mawbNo"
                },
                {
                    title: l('depatureDate'),
                    data: function (row, type, set) {
                        var depatureDate = new Date(row.depatureDate);
                        if (depatureDate.getFullYear() == 1) {
                            return '';
                        }
                        return depatureDate.toLocaleDateString() + ' ' + depatureDate.toLocaleTimeString();
                    }
                },
                {
                    title: l('arrivalDate'),
                    data: function (row, type, set) {
                        var arrivalDate = new Date(row.arrivalDate);
                        if (arrivalDate.getFullYear() == 1) {
                            return '';
                        }
                        return arrivalDate.toLocaleDateString() + ' ' + arrivalDate.toLocaleTimeString();
                    }
                },
                {
                    title: l('depatureId'),
                    data: "depatureAirportName"
                },
                {
                    title: l('destinationId'),
                    data: "destinationAirportName"
                },
                {
                    title: l('shipperId'),
                    data: "overseaAgentTPName"
                }
            ]
        })
    );

    $('[type=search]').on('keyup', function () {
        dataTable.search(this.value).draw();
    });

    $('#NewMblButton').click(function (e) {
        location.href = 'CreateMawb';
    });

});