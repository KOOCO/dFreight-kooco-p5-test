$(function () {
    var l = abp.localization.getResource('Freight');


    var dataTable = $('#CustomerListTable').DataTable(
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
            ajax: abp.libs.datatables.createAjax(dolphin.freight.accounting.payment.customerPayment.getDataList, function () {
                return {};
            }),
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
                                            visible: abp.auth.isGranted('Accounting.Customer.Edit'), //CHECK for the PERMISSION
                                            action: function (data) {
                                                if (data.record.isLocked) {

                                                }
                                                location.href = '/Accounting/Payment/CustomerPayment?Id=' + data.record.id + '&edit=Y';

                                            }
                                        },
                                        {
                                            text: l('Delete'),
                                            confirmMessage: function (data) {
                                                return l(
                                                    'AreYouSureToDelete'
                                                );
                                            },
                                            action: function (data) {
                                                dolphin.freight.accounting.payment.customerPayment
                                                    .delete(data.record.id)
                                                    .then(function () {
                                                        abp.notify.info(l('SuccessfullyDeleted'));
                                                        dataTable.ajax.reload();
                                                    });
                                            }
                                        }
                                    ]
                            }
                        },
                        {
                            data: "id",
                            visible: false,
                            searchable: false,
                            type: "hidden"
                        },
                        {
                            title: l('CustomerList:ReleaseDate'),
                            data: "releaseDate",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:ReceivablesSources'),
                            data: "receivablesSourcesName",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:Category'),
                            data: "category",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:CheckNo'),
                            data: "checkNo",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:Bank'),
                            data: "bank",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:ReceivedAmount') + '(' + "TWD" + ')',
                            data: "bankCurrency",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:ReceivedAmount') + '(' + l('CustomerList:BankCurrency') + ')',
                            data: "bankCurrency",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:DepositDate'),
                            data: "deposit",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:Invalid'),
                            data: "invalid",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:InvalidDate'),
                            data: "invalid",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:Substation'),
                            data: "officeName",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:CreatorId'),
                            data: "creatorId",
                            type: "readonly"
                        },
                        {
                            title: l('CustomerList:Memo'),
                            data: "memo",
                            type: "readonly"
                        }
                        //,
                        //{
                        //    title: l('CustomerList:Status'),
                        //    data: "",
                        //    type: "readonly"
                        //}
                    ]
        })
    );

    function FIndTpName(id)
    {
        var Tpname = '';
        dolphin.freight.tradePartners.tradePartner.findByTpId(id)
            .then(function (result)
            {
                console.log(result);
                if (result == null)
                {
                    return Tpname;
                }
                else
                {
                    Tpname = result;
                    return Tpname;
                }
            });
    }
});
