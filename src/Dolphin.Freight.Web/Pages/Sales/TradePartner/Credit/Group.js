$(function () {
    var l = abp.localization.getResource('Freight');

    var dataTable = $('#CreditLimtGroupsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            responsive: {
                details: {
                    type: 'column'
                }
            },
            ajax: abp.libs.datatables.createAjax(dolphin.freight.tradePartners.credits.creditLimitGroup.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    //visible: abp.auth.isGranted('BookStore.Books.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                   // visible: abp.auth.isGranted('BookStore.Authors.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'AreYouSureToDelete',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        dolphin.freight.tradePartners.credits.creditLimitGroup
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Display:Group:THead:CreditLimitGroupName'),
                    data: "creditLimitGroupName"
                },
                {
                    title: l('Display:Group:THead:PaymentType'),
                    data: "paymentType",
                    render: function (data) {
                        return l('Enum:PaymentType.' + data);
                        //return l([
                        //    "Enum:PaymentType.Cod",
                        //    "Enum:PaymentType.Credit",
                        //    "Enum:PaymentType.CreditHold",
                        //    "Enum:PaymentType.Koinfo"
                        //][data]);
                    }
                },
                {
                    title: l('Display:Group:THead:CreditTermType'),
                    data: "creditTermType",
                    render: function (data) {
                        return l('Enum:CreditTermType.' + data);
                        //return l([
                        //    "Enum:CreditTermType.DaysAfterETA",
                        //    "Enum:CreditTermType.DaysAfterETD",
                        //    "Enum:CreditTermType.Days",
                        //    "Enum:CreditTermType.DueOnReceipt",
                        //    "Enum:CreditTermType.EndOfNextMonth",
                        //    "Enum:CreditTermType.EndOfThisMonth",
                        //    "Enum:CreditTermType.OfNextMonth"
                        //][data]);
                    }
                },
                {
                    title: l('Display:Group:THead:CreditTermDays'),
                    data: "creditTermDays"
                },
                {
                    title: l('Display:Group:THead:CreditLimit'),
                    data: "creditLimit"
                }
            ]
        })
    );

    var createModal = new abp.ModalManager({
        viewUrl: '/Sales/TradePartner/Credit/ModalWithCreateCreditLimitGroup'
    });
    var editModal = new abp.ModalManager({
        viewUrl: '/Sales/TradePartner/Credit/ModalWithEditCreditLimitGroup'
    });


    createModal.onResult(function () {
        console.log('open the CreditLimitGroup createModal');
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        console.log('open the CreditLimitGroup editModal');
        dataTable.ajax.reload();
    });

    $('#AddTradePartnerGroupButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});