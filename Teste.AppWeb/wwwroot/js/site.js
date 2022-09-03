const CustomDatatable = function () {

    const renderBooleanFields = (data, type,) => {
        if (type === "display")
            return '<input type="checkbox" class="editor-active editor-boolean" ' + (data ? "checked" : "") + '>';
        return data;
    }
    const adjustDefColumnsEditors = (columns) => {
        if (!columns)
            return;

        columns.forEach(function (item) {
            if (!item.isCheckbox)
                return;
            item.render = renderBooleanFields;
        });
    }
    const adjustDataTable = () => {
        const checkboxes = $(".editor-boolean");
        checkboxes
            .off("click")
            .on("click", function () {
                return false;
            });

        checkboxes
            .parent()
            .addClass("text-center");
    }
    const createTable = (selector, options) => {
        adjustDefColumnsEditors(options.columns);
        return selector
            .DataTable(options)
            .on("draw.dt", () => adjustDataTable());
    }
    const createGridHeader = (downloadExcel, print, filter, toolbarButtons) => {
        let s = "<'row'<'col-sm-3'l>";
        if (downloadExcel || print)
            s += "<'col-sm-6 text-center'B>";
        if (filter)
            s += "<'col-sm-3'f>";
        if (toolbarButtons)
            s += "<'col-sm-3 grid-additional-toolbar text-right'>";
        s += ">";
        return s;
    }

    return {
        /**
         * ExtraOptions: default {downloadExcel:true, print:true, filter:true, toolbarButtons:false}
         */
        create: (selector, url, method, columns, buttons, extraOptions) =>
            CustomDatatable.createWithParams(selector, url, method, undefined, columns, buttons, extraOptions),
        createWithParams: (selector, url, method, params, columns, buttons, extraOptions) => {
            if (!extraOptions) extraOptions = {};
            if (extraOptions.downloadExcel === undefined) extraOptions.downloadExcel = true;
            if (extraOptions.print === undefined) extraOptions.print = true;
            if (extraOptions.filter === undefined) extraOptions.filter = true;
            if (extraOptions.toolbarButtons === undefined) extraOptions.toolbarButtons = false;

            return createTable(
                selector,
                {
                    dom:
                        createGridHeader(extraOptions.downloadExcel, extraOptions.print, extraOptions.filter, extraOptions.toolbarButtons) +
                        "<'row'<'col-sm-12'tr>>" +
                        "<'row'<'col-sm-5'i><'col-sm-7'p>>",
                    processing: true,
                    serverSide: true,
                    columns: columns,
                    buttons: {
                        buttons: buttons
                    },
                    searchDelay: 350,
                    ordering: false,
                    ajax: {
                        url: url,
                        type: method,
                        data: params,
                        processing: true,
                        serverSide: true,
                    },
                    language: {
                        sEmptyTable: "Nenhum registro encontrado",
                        sInfo: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                        sInfoEmpty: "Mostrando 0 até 0 de 0 registros",
                        sInfoFiltered: "(Filtrados de _MAX_ registros)",
                        sInfoPostFix: "",
                        sInfoThousands: ".",
                        sLengthMenu: "_MENU_ resultados por página",
                        sLoadingRecords: "Carregando...",
                        sProcessing: "Processando...",
                        sZeroRecords: "Nenhum registro encontrado",
                        sSearch: "Pesquisar",
                        oPaginate: {
                            sNext: "Próximo",
                            sPrevious: "Anterior",
                            sFirst: "Primeiro",
                            sLast: "Último"
                        },
                        oAria: {
                            sSortAscending: ": Ordenar colunas de forma ascendente",
                            sSortDescending: ": Ordenar colunas de forma descendente"
                        }
                    }
                })
        },
        createLocal: (selector, data, columns, buttons) =>
            createTable(
                selector,
                {
                    columns: columns,
                    buttons: {
                        buttons: buttons
                    },
                    ordering: false,
                    data: data,
                    ordering: false,
                    paging: true,
                    searching: false,
                    lengthChange: false,
                    pageLength: 5,
                    showNEntries: false,
                    language: {
                        sEmptyTable: "Nenhum registro encontrado",
                        sInfo: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                        sInfoEmpty: "",
                        sInfoFiltered: "(Filtrados de _MAX_ registros)",
                        sInfoPostFix: "",
                        sInfoThousands: ".",
                        sLengthMenu: "_MENU_ resultados por página",
                        sLoadingRecords: "Carregando...",
                        sProcessing: "Processando...",
                        sZeroRecords: "Nenhum registro encontrado",
                        sSearch: "Pesquisar",
                        oPaginate: {
                            sNext: "Próximo",
                            sPrevious: "Anterior",
                            sFirst: "Primeiro",
                            sLast: "Último"
                        },
                        oAria: {
                            sSortAscending: ": Ordenar colunas de forma ascendente",
                            sSortDescending: ": Ordenar colunas de forma descendente"
                        }
                    }
                })
    }
}();