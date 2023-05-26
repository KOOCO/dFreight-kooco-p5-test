
function openMemoModel(tagName) {
    $("#modal_memo_" + tagName).modal('show');
}
function closeMemoModal(tagId){
    $("#" + tagId).modal('hide');

}
function saveMemoModal(tagName) {
    var Subject = $("#eMemoSubject_" + tagName).val();
    var Content = $("#eMemoContent_" + tagName).val();
    var Fid = $("#eFid_" + tagName).val();
    var Ftype = $("#eFtype_" + tagName).val();
    var MemoId = $("#eMemoId_" + tagName).val();
    var url = '/AbpAjax/AddOrEditMemo'
    jQuery.ajax({
        type: 'POST',
        url: url,
        data: { Subject: Subject, Content: Content, Fid: Fid, Ftype: Ftype, MemoId: MemoId },

        success: function (rs) {
            $("#modal_memo_" + tagName).modal('hide');
            initMemoList(rs.datas,tagName)
        },
        error: function (rs) {
            console.log(rs)
            alert("Error occurs");
        }
    });
    
}
function initMemoList(datas, tagName)
{
    if (datas.length > 0) {
        trHtml = "";
        for (var i = 0; i < datas.length; i++)
        {
            trHtml = trHtml + '<tr><td><input type="checkbox" name="momoId_' + datas[i].id + '" value="' + datas[i].id + '"></td>';
            trHtml = trHtml + '<td><a href="javascript:void(0)" onclick="showMemo(\'' + datas[i].id + '\',\'' + tagName + '\',\'' + datas[i].content +'\')" >' + datas[i].subject + '</a></td>'
            trHtml = trHtml + '<td>' + formatDate(datas[i].lastModificationTime) + '</td>'
            trHtml = trHtml + '<td>' + formatDate(datas[i].creationTime) + '</td>'
            trHtml = trHtml + '<td></td></tr>'
        }
        $("#memo_tbody_" + tagName).html(trHtml);;
    }
    
    
}
function InitMemoTable(tagName) {
    var Fid = $("#eFid_" + tagName).val();
    var Ftype = $("#eFtype_" + tagName).val();
    var url = '/AbpAjax/GetMemos'
    jQuery.ajax({
        type: 'POST',
        url: url,
        data: {  Fid: Fid, Ftype: Ftype },

        success: function (rs) {
            initMemoList(rs.datas, tagName)
        },
        error: function (rs) {
            console.log(rs)
            alert("Error occurs");
        }
    });
}
function formatDate(time, format = 'YY-MM-DD hh:mm:ss') {
    if (time == null || time == '') return '';
    var date = new Date(time);

    var year = date.getFullYear(),
        month = date.getMonth() + 1,//月份是从0开始的
        day = date.getDate(),
        hour = date.getHours(),
        min = date.getMinutes(),
        sec = date.getSeconds();
    var preArr = Array.apply(null, Array(10)).map(function (elem, index) {
        return '0' + index;
    });

    var newTime = format.replace(/YY/g, year)
        .replace(/MM/g, preArr[month] || month)
        .replace(/DD/g, preArr[day] || day)
        .replace(/hh/g, preArr[hour] || hour)
        .replace(/mm/g, preArr[min] || min)
        .replace(/ss/g, preArr[sec] || sec);

    return newTime;
}
function showMemo(id, tagName, tagValue) {
    $("#memoContent_" + tagName).val(tagValue);
}