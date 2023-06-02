$(function () {
    dolphin.freight.importExport.oceanExports.oceanExportHbl.getHblCardsById('928e8b49-d993-0e9c-2045-3a0afedd18f9')
        .done(function (hblCards) {
            if (hblCards && hblCards.length) {
                hblCards.forEach(function (hblCard, index) {


                    let abpcard = createHawbCard();

                    abpcard = setHawbCardValues(abpcard, hblCard.id, hblCard.hblNo, index);

                    $('#hblCards').append(abpcard);

                })
                setTimeout(() => {
                    $('.hblCardTitle')[0].click();
                }, 500);
            }
        })

})