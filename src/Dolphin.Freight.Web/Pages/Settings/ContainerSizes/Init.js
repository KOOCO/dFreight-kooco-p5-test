var selectItems;
$(document).ready(function () {
    var l = abp.localization.getResource('Freight');
    var a = $("#formAmsNoId").val()
    console.log("a="+a);
    dolphin.freight.common.ajaxDropdown.getSysCodeDtosByType({ queryType: 'ContainerGroupId' }).done(function (result) {
    
        initSysCodeTag(result, "ContainerGroupId",  $("#formContainerGroupId").val());
    });

    $("#saveBtn").click(function () { doSubmit() });
});
function initSysCodeTag(selectItems,tagName, tagValue) {
    var drophtml = "";
    var l = abp.localization.getResource('Freight');
    var tag = l("Dropdown:Select");
    for (var i = 0; i < selectItems.length; i++) {
        
        drophtml = drophtml + "<li class='form-control' style='width:450px;'><a  style='width:400px;' class='dropdown-item'  href='#' onclick='changeDropdownValue(\"" + tagName + "\",\"" + selectItems[i].id + "\",\"" + selectItems[i].codeValue + "\")'>" + selectItems[i].showName + "</div></a></li>"
        if (tagValue == selectItems[i].id)
        {
            tag = selectItems[i].showName;
        } 
    }
    $("#drop_" + tagName).html(tag);
    $("#" + tagName).val(tagValue);
    $("#dropdownMenuButton_" + tagName).html(drophtml);
}
function changeDropdownValue(tagName, tagValue, showCode) {
    $("#" + tagName).val(tagValue);
    $("#drop_" + tagName).html(showCode);
}
function doSubmit()
{
    $("#formContainerCode").val($("#ContainerSize_ContainerCode").val());
    $("#formSizeDescription").val($("#ContainerSize_SizeDescription").val());
    $("#formContainerGroupId").val($("#ContainerGroupId").val());
    $("#formTeu").val($("#ContainerSize_Teu").val());
    $("#formIsUseed").val($("#ContainerSize_IsUseed").val());
    $("#createForm").submit();
}