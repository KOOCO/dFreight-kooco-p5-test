$(function () {
    dolphin.freight.importExport.airImports.airImportHawb.getHblCardsById('2280df81-64ed-e55e-95f6-3a0b0dce484b')
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