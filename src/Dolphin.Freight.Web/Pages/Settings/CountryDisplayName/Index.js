$(function () {
    var l = abp.localization.getResource('Freight');

    function getAjax(requestData, callback, settings) {
        function responseCallback (result) {
            return {
                recordsTotal: result.totalCount,
                recordsFiltered: result.totalCount,
                data: result.items
            };
        }

        const input = {
            officeId: $('#office-id').val(),
        };
        let promise = null;

        switch ($('#has-data').val()) {
            case 'yes':
                input.hasData = true;
                break;
            case 'no':
                input.hasData = false;
        }

        const shipLine = $('#ship-line').val();
        if (shipLine !== '') {
            input.shipLine = shipLine;
        }

        if (settings.oInit.paging) {
            input.maxResultCount = requestData.length;
            input.skipCount = requestData.start;
        }

        //Sorting
        if (requestData.order && requestData.order.length > 0) {
            input.sorting = "";

            for (var i = 0; i < requestData.order.length; i++) {
                var orderingField = requestData.order[i];

                if (requestData.columns[orderingField.column].data) {
                    input.sorting += requestData.columns[orderingField.column].data + " " + orderingField.dir;

                    if (i < requestData.order.length - 1) {
                        input.sorting += ",";
                    }
                }
            }
        }

        if (callback) {
            if (promise && promise.jqXHR) {
                promise.jqXHR.abort();
            }
            promise = dolphin.freight.settings.countries.countryDisplayName.getList(input);
            promise.always(function () {
                promise = null;
            }).then(function (result) {
                callback(responseCallback(result));
            });
        }
    };

    var dataTable = $('#CountryDisplayName').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: false,
            searching: false,
            scrollX: true,
            ajax: getAjax,
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('Settings.CountryDisplayName.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({
                                            id: data.record.id ?? null,
                                            countryId: data.record.countryId,
                                            countryName: data.record.countryName,
                                            officeId: $('#office-id').val(),
                                            officeName: $('#office-id option:selected').text(),
                                        });
                                    }
                                },
                            ]
                    }
                },
                {
                    //國家
                    title: l('CountryDisplayName:Country'),
                    data: "countryName"
                },
                {
                    //顯示名稱
                    title: l('CountryDisplayName:DisplayName'),
                    data: "displayName"
                },
                {
                    //航線
                    title: l('CountryDisplayName:ShipLine'),
                    data: "airportName"
                },
            ]
        })
    );

    $('[type=search]').on('keyup', function () {
        dataTable.search(this.value).draw();
    });
    $("#has-data,#office-id,#ship-line").on('change', dataTable.ajax.reload);

    const editModal = new abp.ModalManager(abp.appPath + 'Settings/CountryDisplayName/EditModal');

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
});