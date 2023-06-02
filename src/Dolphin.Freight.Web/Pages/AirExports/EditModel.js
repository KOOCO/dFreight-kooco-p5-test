$(function () {
    dolphin.freight.importExport.airExports.airExportHawb.getHblCardsById('9a513dd6-edad-9650-7192-3a0b0dd14f3b')
        .done(function (hblCards) {
            if (hblCards && hblCards.length) {
                hblCards.forEach(function (hblCard, index) {


                    let abpcard = createHawbCard();

                    abpcard = setHawbCardValues(abpcard, hblCard.id, hblCard.hawbNo, index);

                    $('#hblCards').append(abpcard);

                })
                setTimeout(() => {
                    $('.hblCardTitle')[0].click();
                }, 500);
            }
        })
})