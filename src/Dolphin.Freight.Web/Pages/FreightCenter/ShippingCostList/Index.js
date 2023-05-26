var l = abp.localization.getResource('Freight');

// #region 載入執行

$(function () {

    // #region 主資料表

    // #region 自定義內建語言

    abp.libs.datatables.defaultConfigurations.language = function () {
        return {
            info: l("PagerInfo"),
            infoFiltered: l("PagerInfoFiltered"),
            infoEmpty: l("PagerInfoEmpty"),
            search: l("PagerSearch"),
            processing: l("ProcessingWithThreeDot"),
            loadingRecords: l("LoadingWithThreeDot"),
            lengthMenu: l("PagerShowMenuEntries"),
            emptyTable: l("NoDataAvailableInDatatable"),
            paginate: {
                first: l("PagerFirst"),
                last: l("PagerLast"),
                previous: l("PagerPrevious"),
                next: l("PagerNext")
            },
            buttons: {
                copyTitle: l('CopyToClipboard'),
                copySuccess: {
                    _: l('CopiedNRowsToClipboard'),
                    0: l("NoDataAvailableInDatatable")
                }
            }
        };
    };

    // #endregion

    var dataTable = $('#mainTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            pageLength: 100,
            lengthMenu: [10, 20, 50, 100],
            order: [[1, "asc"]],
            dom: 'Bfrtip',
            buttons: [
                {
                    extend: 'copy',
                    text: l('Btn:Copy'),
                    filename: l('OceanShippingCost'),
                    title: null,
                    exportOptions: {
                        columns: ':visible:not(.no-export)'
                    }
                },
                {
                    extend: 'csv',
                    filename: l('OceanShippingCost') + getCurrentDateTime(),
                    title: null,
                    exportOptions: {
                        columns: ':visible:not(.no-export)'
                    }
                },
                {
                    extend: 'excel',
                    filename: l('OceanShippingCost') + getCurrentDateTime(),
                    title: null,
                    exportOptions: {
                        columns: ':visible:not(.no-export)'
                    }
                },
                {
                    extend: 'pdf',
                    filename: l('OceanShippingCost') + getCurrentDateTime(),
                    title: l('OceanShippingCost'),
                    exportOptions: {
                        columns: ':visible:not(.no-export)'
                    }
                },
                {
                    extend: 'print',
                    filename: l('OceanShippingCost'),
                    title: l('OceanShippingCost'),
                    exportOptions: {
                        columns: ':visible:not(.no-export)'
                    }
                }
            ],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(dolphin.freight.iFreightDB.freightCenters.freightCenter.getShippingCostList),
            columnDefs: [
                {
                    title: l('jobNo'),
                    data: "jobNo",
                    visible: false
                },
                {
                    title: l('運價取得(Agent)'),
                    data: "agent"
                },
                {
                    title: l('sC_NO'),
                    data: "sC_NO"
                },
                {
                    title: l('effectiveDate'),
                    data: "effectiveDate",
                    render: function (data, type, row, meta) {
                        if (data == null) return '';
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATE_SHORT);
                    }
                },
                {
                    title: l('expiryDate') + '/' + l('Rate Validity'),
                    data: "expiryDate",
                    render: function (data, type, row, meta) {
                        if (data == null) return '';
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATE_SHORT);
                    }
                },
                {
                    title: l('carrier'),
                    data: "carrier"
                },
                {
                    title: l('serviceMode'),
                    data: "serviceMode"
                },
                {
                    title: l('origin') + '/' + l('POL'),
                    data: "origin"
                },
                {
                    title: l('pod'),
                    data: "pod"
                },
                {
                    title: l('destination'),
                    data: "destination"
                },
                {
                    title: l('ctn_20GP'),
                    data: "ctn_20GP"
                },
                {
                    title: l('ctn_40GP'),
                    data: "ctn_40GP"
                },
                {
                    title: l('ctn_40HQ'),
                    data: "ctn_40HQ"
                },
                {
                    title: l('ctn_45HQ'),
                    data: "ctn_45HQ"
                },
                {
                    title: l('oF_Currency'),
                    data: "oF_Currency"
                },
                {
                    title: l('cfS_CBM'),
                    data: "cfS_CBM"
                },
                {
                    title: l('cfS_Currency'),
                    data: "cfS_Currency"
                },
                {
                    title: l('T/T'),
                    data: "tt"
                },
                {
                    title: l('ETC'),
                    data: "etc"
                },
                {
                    title: l('ETD'),
                    data: "etd"
                },
                {
                    title: l('ETA'),
                    data: "eta"
                },
                {
                    title: l('Free Time'),
                    data: "freeTime"
                },
                {
                    title: l('Remark'),
                    data: "remark"
                },
                {
                    title: l('extension1'),
                    data: "extension1"
                }
            ]
        })
    );

    $('.dt-button.buttons-copy.buttons-html5').removeClass().addClass('btn btn-primary');
    $('.dt-button.buttons-csv.buttons-html5').removeClass().addClass('btn btn-primary');
    $('.dt-button.buttons-excel.buttons-html5').removeClass().addClass('btn btn-primary');
    $('.dt-button.buttons-pdf.buttons-html5').removeClass().addClass('btn btn-primary');
    $('.dt-button.buttons-print').removeClass().addClass('btn btn-primary');

    $.extend(true, $.fn.dataTable.defaults, {
        processing: true
    });


    // #endregion

    // #region 下載 Excel 的按鈕

    $('#ExportToExcel').click(function (e) {
        e.preventDefault();
        var url = '/api/app/freight-center/shipping-cost-excel';
        var xhr = new XMLHttpRequest();
        xhr.open('GET', url, true);
        xhr.responseType = 'blob'; // 指定回應類型為二進位資料
        xhr.onload = function () {
            if (xhr.status === 200) {
                var blob = xhr.response;
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(blob);
                link.download = l('OceanShippingCost') + getCurrentDateTime() + '.xlsx'; // 指定下載檔案的檔名
                link.click(); // 觸發點擊事件，開始下載
            }
            else {
                abp.message.error(l('DownloadFailed'));
            }
        };
        xhr.send();
    });

    // #endregion

});

// #endregion

// #region 取得時間格式 「_yyyyMMddHHmmss」

function getCurrentDateTime() {
    var now = new Date();

    var year = now.getFullYear();
    var month = String(now.getMonth() + 1).padStart(2, '0');
    var day = String(now.getDate()).padStart(2, '0');
    var hours = String(now.getHours()).padStart(2, '0');
    var minutes = String(now.getMinutes()).padStart(2, '0');
    var seconds = String(now.getSeconds()).padStart(2, '0');

    var formattedDateTime = year + month + day + hours + minutes + seconds;
    return '_' + formattedDateTime;
}

// #endregion