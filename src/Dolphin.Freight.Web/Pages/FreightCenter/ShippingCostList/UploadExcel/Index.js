var l = abp.localization.getResource('Freight');


// #region 載入執行
$(function () {
    
    // #region 主資料表

    var dataTable = $('#mainTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            pageLength: 100,
            lengthMenu: [10, 20, 50, 100],
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(dolphin.freight.iFreightDB.freightCenters.freightCenter.getOceanExcelTempList),
            columnDefs: [
                {
                    title: "ExcelTempId",
                    data: "excelTempId",
                    visible: false
                },
                {
                    title: "GROPU_ID",
                    data: "groupId"
                },
                {
                    title: "CMP",
                    data: "cmp"
                },
                {
                    title: "STN",
                    data: "stn"
                },
                {
                    title: "Agent",
                    data: "agent"
                },
                {
                    title: "EffectiveDate",
                    data: "effectiveDate",
                    render: function (data, type, row, meta) {
                        if (data) {
                            return luxon
                                .DateTime
                                .fromISO(data, {
                                    locale: abp.localization.currentCulture.name
                                }).toLocaleString(luxon.DateTime.DATE_SHORT);
                        } else {
                            return '';
                        }
                    }
                },
                {
                    title: "ValidTill",
                    data: "validTill",
                    render: function (data, type, row, meta) {
                        if (data) {
                            return luxon
                                .DateTime
                                .fromISO(data, {
                                    locale: abp.localization.currentCulture.name
                                }).toLocaleString(luxon.DateTime.DATE_SHORT);
                        } else {
                            return '';
                        }
                    }
                },
                {
                    title: "Carrier",
                    data: "carrier"
                },
                {
                    title: "Origin",
                    data: "origin"
                },
                {
                    title: "Pod",
                    data: "pod"
                },
                {
                    title: "Destination",
                    data: "destination"
                },
                {
                    title: "Model",
                    data: "model"
                },
                {
                    title: "Ic20gp",
                    data: "ic20gp"
                },
                {
                    title: "Ic40gp",
                    data: "ic40gp"
                },
                {
                    title: "Ic40hq",
                    data: "ic40hq"
                },
                {
                    title: "TrasitTime",
                    data: "trasitTime"
                },
                {
                    title: "Etc",
                    data: "etc"
                },
                {
                    title: "Etd",
                    data: "etd"
                },
                {
                    title: "Eta",
                    data: "eta"
                },
                {
                    title: "FreeTime",
                    data: "freeTime"
                },
                {
                    title: "Remark",
                    data: "remark"
                },
                {
                    title: "UploaderId",
                    data: "uploaderId",
                    visible: false
                },
                {
                    title: "UploaderTime",
                    data: "uploaderTime",
                    visible: false
                },
                {
                    title: "IsDeleted",
                    data: "isDeleted",
                    visible: false
                }
            ]
        })
    );

    // #endregion

    // #region 開啟上傳對應表的按鈕 + 回應處理

    var sendMappingModal = new abp.ModalManager(abp.appPath + 'FreightCenter/ShippingCostList/UploadExcel/SendMappingModal');

    sendMappingModal.onResult(function () {
        var responesMessage = arguments[1].responseText.message;

        // 判斷是否有值用的
        var jsonString = JSON.stringify(responesMessage);
        var jsonObject = JSON.parse(jsonString);

        if (jsonObject !== null && Object.keys(jsonObject).length > 0) {
            // SimpleSweetAlert(jsonObject.message, jsonObject.title, jsonObject.msgType);
            Swal.fire({
                title: jsonObject.title,
                // text: jsonObject.message,
                html: jsonObject.message,
                confirmButtonText: l('Btn:Yes'),
                cancelButtonText: l('Btn:Cancel'),
                reverseButtons: true,
                showCancelButton: false,
                icon: convertMsgType(jsonObject.msgType),
            }).then((result) => {
                if (jsonObject.msgType == '1') {
                    // dataTable.ajax.reload();
                    location.href = "/FreightCenter/ShippingCostList"; // 導回運價成本列表
                }
            })
        } else {
            abp.message.error('Unknown error');
        }

    });

    $('#uploadMappingExcelModal').click(function (e) {
        e.preventDefault();
        sendMappingModal.open();
    });

    // #endregion

});

// #endregion

// #region 彈跳視窗(可支援Html)的簡單副程式

function SimpleSweetAlert(message, title, type) {
    Swal.fire({
        title: title,
        html: message,
        icon: convertMsgType(type) // info、success、warn、error
    });
}

function convertMsgType(type) {
    switch (type) {
        case 0:
            return 'info';
            break;
        case 1:
            return 'success';
            break;
        case 2:
            return 'warn';
            break;
        case 3:
            return 'error';
            break;
        default:
            return 'error';
            break;
    }
}

// #endregion

// #region 清除暫存 Excel 的按鈕

function clearTemporaryExcel() {
    // 使用 SweetAlert2
    Swal.fire({
        title: l('AreYouSure'),
        text: l('ClearTempData'),
        confirmButtonText: l('Btn:Yes'),
        cancelButtonText: l('Btn:Cancel'),
        reverseButtons: true,
        showCancelButton: true,
        icon: 'warning',
        confirmButtonColor: '#dc3545', // 確認按鈕顏色
        cancelButtonColor: '#6c757d' // 取消按鈕顏色
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/api/app/freight-center/clear-temporary-excel',
                type: 'DELETE',
                success: function () {
                    abp.libs.sweetAlert.config.confirm.icon = 'success';
                    abp.libs.sweetAlert.config.confirm.showCancelButton = false;
                    abp.message.confirm('', l('SuccessfullyClear'))
                        .then(function (confirmed) {
                            if (confirmed) { location.reload(); }
                            else { location.reload(); }
                        });
                },
                error: function () {
                    abp.message.error('資料清除失敗，請洽資訊人員');
                }
            });
        }
    })

}

// #endregion
