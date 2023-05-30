$(function () {
    dolphin.freight.importExport.airImports.airImportHawb.getHblCardsById('2280df81-64ed-e55e-95f6-3a0b0dce484b')
        .done(function (hblCards) {
            if (hblCards && hblCards.length) {
                hblCards.forEach(function (hblCard, index) {
                    let apbCardClass = 'card board-item hbl-sm-' + index;
                    let cardBodyId = 'hawbCard_' + index;
                    let abpcard = '<div class="' + apbCardClass + '">' +
                        '<div class="card-header">' +
                        '<h5 class="card-title hblCardTitle" id="title_' + hblCard.hawbNo +'" onclick="onHawbCardClick(event)">' + hblCard.hawbNo + '</h5>' +
                        '<button type="button" class="btn d-none btn-collapse collapsed btnHawbCardCollapse" data-val="'+index+'" data-bs-toggle="collapse" id="btnHawbCardCollapse_' + hblCard.hawbNo+'" data-bs-target="#' + cardBodyId +'" aria-expanded="false" aria-controls="mawbDiv"><i class="fa fa-caret-down" style="color:#FFFFFF;"></i></button > ' +
                        '</div>' +
                        '<div class="card-body collapse" id="' + cardBodyId +'" style="min-height:150px !important">' +
                        '</div>';

                    $('#hblCards').append(abpcard);
                })
                setTimeout(() => {
                    $('.btnHawbCardCollapse')[0].click();
                }, 500);
            }
        })

})