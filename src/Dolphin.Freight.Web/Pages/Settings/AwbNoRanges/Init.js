var selectItems;
$(function () {
    var l = abp.localization.getResource('Freight');
    $("#AwbNoRange_CompanyId").hide();
    dolphin.freight.tradePartners.tradePartner.getList({}).done(function (result) {
        initTradePartnerSelect(result.items, "CompanyId", $("#formCompanyId").val());
    });

    $("#saveBtn").click(function () { doSubmit() });
});
function initTradePartnerSelect(selectItems, tagName, tagValue) {
    var l = abp.localization.getResource('Freight');
    var tag = l("Dropdown:Select");
    var drophtml = "<li class='dropdown-item' id='li_" + tagName + "' ><input type='text' class='form-control' id='qid_" + tagName + "'></li>";
    if (selectItems.length > 0) {
        for (var i = 0; i < selectItems.length; i++) {
            drophtml = drophtml + "<li class='form-control' style='width:450px;'><a  style='width:400px;' class='dropdown-item'  href='javascript:void(0)' onclick='changeDropdownValue(\"" + tagName + "\",\"" + selectItems[i].id + "\",\"" + selectItems[i].tpName + "\")'><div class='col-sm-9'>" + selectItems[i].tpName + "</di><div class='col-sm-2 pull-right'>  " + selectItems[i].tpAliasName + "</div><div class='col-sm-12'> " + selectItems[i].tpCode + "</div></a></li>"
        }
    }
    $("#drop_" + tagName).html(tag);
    $("#" + tagName).val(tagValue);
    $("#dropdownMenuButton_" + tagName).html(drophtml);
}
function changeDropdownValue(tagName, tagValue, showCode) {
    console.log(tagName);
    console.log(tagValue);
    console.log(showCode);
    $("#" + tagName).val(tagValue);
    $("#drop_" + tagName).html(showCode);
}
function doSubmit()
{
    console.log($("#CompanyId").val())
    $("#formStartNo").val($("#AwbNoRange_StartNo").val());
    $("#formEndNo").val($("#AwbNoRange_EndNo").val());
    $("#formNote").val($("#AwbNoRange_Note").val());
    $("#formCompannyId").val($("#CompanyId").val());
    $("#createForm").submit();
}