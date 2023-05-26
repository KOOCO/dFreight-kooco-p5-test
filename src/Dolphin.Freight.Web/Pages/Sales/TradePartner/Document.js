$(function () {
    var l = abp.localization.getResource('Freight');
    var tradePartnerId = $('#tid').val();
    console.log("tradePartnerId:" + tradePartnerId);
    var dataTable;

    function showContactPersonDataTable(inputTpId) {
        console.log("showContactPersonDataTable with inputTpId:" + inputTpId);

        var inputAction = function () {
            return {
                tradePartnerId: inputTpId
            };
        };

        // 四捨五入
        var roundTo = function (num, decimal) {
            return Math.round((num + Number.EPSILON) * Math.pow(10, decimal)) / Math.pow(10, decimal);
        };

        dataTable = $('#TPAttachmentListTable').DataTable(
            abp.libs.datatables.normalizeConfiguration({
                serverSide: true,
                paging: true,
               /* order: [[1, "asc"]],*/
                searching: false,
                scrollX: true,
                responsive: {
                    details: {
                        type: 'column'
                    }
                },
                scrollCollapse: true,
                destroy: true,
                ajax: abp.libs.datatables.createAjax(dolphin.freight.tradePartners.tradePartnerAttachment.getList, inputAction), //pass the filter to the GetList method

                columnDefs: [
                    {
                        title: l('Actions'),
                        rowAction: {
                            items:
                                [
                                    {
                                        text: l('Delete'),
                                        // visible: abp.auth.isGranted('BookStore.Authors.Delete'),
                                        confirmMessage: function (data) {
                                            return l(
                                                'AreYouSureToDelete',
                                                data.record.attachmentName
                                            );
                                        },
                                        action: function (data) {
                                            dolphin.freight.tradePartners.tradePartnerAttachment
                                                .delete(data.record.id)
                                                .then(function () {
                                                    abp.notify.info(
                                                        l('SuccessfullyDeleted')
                                                    );
                                                    dataTable.ajax.reload();
                                                });
                                        }
                                    },
                                    {
                                        text: l('Btn:Download'),
                                        //visible: abp.auth.isGranted('BookStore.Books.Edit'),
                                        action: function (data) {
                                            event.preventDefault();
                                            // 之後應該改為用blob格式隱藏路徑
                                            var downloadWindow = window.open("/mediaUpload/tradepartner/doc/" + data.record.attachmentName, "_blank");
                                            downloadWindow.focus();
                                        }
                                    }
                                ]
                        }
                    },
                    {
                        title: l('Display:TradePartner:Document:THead:AttachmentName'),
                        data: "attachmentName",
                        targets: 0,
                    },
                    {
                        title: l('Display:TradePartner:Document:THead:AttachmentSize'),
                        data: "attachmentSize",
                        render: function (data) {
                            return roundTo((data / 1024), 2) + " KB";
                1        }
                    },
                    {
                        title: l('Display:TradePartner:Document:THead:AttachmentUploadDate'),
                        data: "attachmentUploadTime",
                        render: function (data) {
                            return luxon
                                .DateTime
                                .fromISO(data, {
                                    locale: abp.localization.currentCulture.name
                                }).toFormat('yyyy-MM-dd HH:mm');
                        }
                    },
                    {
                        title: l('Display:TradePartner:Document:THead:UserName'),
                        data: "userName",
                        orderable: false // 限定creator不可以排序
                    }
                ],
                fixedColumns: true
            })
        );

    }

    showContactPersonDataTable(tradePartnerId);

    $('#DocumentForm').on('abp-ajax-success', function () {
        event.preventDefault();
        dataTable.ajax.reload();
        abp.message.success(l('SuccessfullyUploaded'));
    });

});