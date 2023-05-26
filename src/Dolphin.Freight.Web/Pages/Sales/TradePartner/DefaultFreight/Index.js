$(function () {
    const ajax = {
        ar: {
            get: dolphin.freight.tradePartners.defaultFreight.tradePartnerDefaultFreight.getARListByQuery,
            delete: dolphin.freight.tradePartners.defaultFreight.tradePartnerDefaultFreight.deleteAR,
        },
        ap: {
            get: dolphin.freight.tradePartners.defaultFreight.tradePartnerDefaultFreight.getAPListByQuery,
            delete: dolphin.freight.tradePartners.defaultFreight.tradePartnerDefaultFreight.deleteAP,
        },
        dc: {
            get: dolphin.freight.tradePartners.defaultFreight.tradePartnerDefaultFreight.getDCListByQuery,
            delete: dolphin.freight.tradePartners.defaultFreight.tradePartnerDefaultFreight.deleteDC,
        },
    };
    const datatable = {
        ar: [],
        ap: [],
        dc: [],
    };
    const modal = {
        ar: [],
        ap: [],
        dc: [],
    };

    $('a[data-toggle="tab"]').on('shown.bs.tab', (e) => {
        e.target; // newly activated tab
        e.relatedTarget; // previous active tab
        //console.log(e.target);
        //console.log(e.relatedTarget);
    });

    $('.add-default-freight').on('click', function () {
        const dom = $(this);
        const type = dom.data('type');
        const category = dom.data('category');
        modal[type][category].open({
            tradePartnerId,
            category,
        });
    });

    $('.default-freight-table').each((index, value) => {
        const dom = $(value);
        const type = dom.data('type');
        const category = dom.data('category');
        const columnDefs = [];

        let i = 0;
        columnDefs.push({
            title: l('Actions'),
            rowAction: {
                items: [
                    {
                        text: l('Edit'),
                        action: (data) => {
                            modal[type][category].open({
                                id: data.record.id,
                                tradePartnerId,
                                category,
                            });
                        }
                    },
                    {
                        text: l('Delete'),
                        confirmMessage: (data) => {
                            return l(
                                'AreYouSureToDelete',
                                data.record.title
                            );
                        },
                        action: (data) => {
                            ajax[type].delete(data.record.id)
                                .then(() => {
                                    abp.notify.info(l('SuccessfullyDeleted'));
                                    datatable[type][category].ajax.reload();
                                });
                        }
                    },
                ]
            },
            data: 'id',
            render: (_data, _type, row) => {
                return '';
            },
            targets: i++,
            orderable: false,
        });

        if (category === 'OI' || category === 'OE') {
            columnDefs.push({
                title: l('Display:TradePartner:DefaultFreight:ShipMode'),
                data: 'id',
                render: (_data, _type, row) => {
                    const item = [];
                    if (row.shipModeBULK === true) {
                        item.push('BULK');
                    }
                    if (row.shipModeFAK === true) {
                        item.push('FAK');
                    }
                    if (row.shipModeFCL === true) {
                        item.push('FCL');
                    }
                    if (row.shipModeLCL === true) {
                        item.push('LCL');
                    }

                    return item.join('  ');
                },
                targets: i++,
            });
        }

        columnDefs.push({
            title: l('Display:TradePartner:DefaultFreight:FreightCode'),
            data: 'freightCode',
            targets: i++,
        });
        columnDefs.push({
            title: l('Display:TradePartner:DefaultFreight:FreightDescription'),
            data: 'freightDescription',
            targets: i++,
        });
        columnDefs.push({
            title: l('Display:TradePartner:DefaultFreight:PC'),
            data: 'pcType',
            render: (_data, _type, row) => {
                return pcMapper[row.pcType];
            },
            targets: i++,
        });
        columnDefs.push({
            title: l('Display:TradePartner:DefaultFreight:Type'),
            data: 'type',
            render: (_data, _type, row) => {
                return typeMapper[type][row.type];
            },
            targets: i++,
        });
        columnDefs.push({
            title: l('Display:TradePartner:DefaultFreight:Unit'),
            data: 'unit',
            render: (_data, _type, row) => {
                return unitMapper[row.unit];
            },
            targets: i++,
        });
        columnDefs.push({
            title: l('Display:TradePartner:DefaultFreight:Vol'),
            data: 'vol',
            targets: i++,
        });
        columnDefs.push({
            title: l('Display:TradePartner:DefaultFreight:Rate'),
            data: 'rate',
            targets: i++,
        });
        columnDefs.push({
            title: l('Display:TradePartner:DefaultFreight:Amount'),
            data: 'id',
            render: (_data, _type, row) => {
                return row.vol * row.rate;
            },
            targets: i++,
        });
        columnDefs.push({
            title: l('Display:TradePartner:DefaultFreight:AgentAmount'),
            data: 'agentAmount',
            targets: i++,
        });

        datatable[type][category] = dom.DataTable({
            paging: false,
            info: false,
            searching: false,
            ajax: (d, cb) => {
                ajax[type].get({
                    tradePartnerId,
                    category: categoryMapper[category],
                }).then(data => cb({ data }));
            },
            columnDefs,
        });

        modal[type][category] = new abp.ModalManager({
            viewUrl: `/Sales/TradePartner/DefaultFreight/CreateUpdate${type.toUpperCase()}`,
        });

        modal[type][category].onResult(() => {
            datatable[type][category].ajax.reload();
        });
    });
});