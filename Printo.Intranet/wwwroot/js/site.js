// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#dataTable-1').DataTable(
    {
        "language": {
            "lengthMenu": "Pokaż _MENU_ pozycji",
            "search": "Szukaj:",
            "zeroRecords": "Brak rekordów w tabeli",
            "info": "Wyświetlono _START_ do _END_ z łącznie _TOTAL_ pozycji",
            "infoEmpty": "Brak rekordów w tabeli",
            "infoFiltered": "(sfiltrowano z łącznie _MAX_ pozycji)",
            "paginate": {
                "first": "Pierwsza",
                "last": "Ostatnia",
                "next": "Następna",
                "previous": "Poprzednia"
            }
        },
        "lengthMenu": [
            [16, 32, 64, -1],
            [16, 32, 64, "All"]
        ],
        //"scrollX": true,
    });

$('#dataTable-2').DataTable(
    {
        "language": {
            "lengthMenu": "Pokaż _MENU_ pozycji",
            "search": "Szukaj:",
            "zeroRecords": "Brak rekordów w tabeli",
            "info": "Wyświetlono _START_ do _END_ z łącznie _TOTAL_ pozycji",
            "infoEmpty": "Brak rekordów w tabeli",
            "infoFiltered": "(sfiltrowano z łącznie _MAX_ pozycji)",
            "paginate": {
                "first": "Pierwsza",
                "last": "Ostatnia",
                "next": "Następna",
                "previous": "Poprzednia"
            }
        },
        "lengthMenu": [
            [16, 32, 64, -1],
            [16, 32, 64, "All"]
        ],
        //"scrollX": true,
    });

$('#dataTable-orders').DataTable(
    {
        "language": {
            "lengthMenu": "Pokaż _MENU_ pozycji",
            "search": "Szukaj:",
            "zeroRecords": "Brak rekordów w tabeli",
            "info": "Wyświetlono _START_ do _END_ z łącznie _TOTAL_ pozycji",
            "infoEmpty": "Brak rekordów w tabeli",
            "infoFiltered": "(sfiltrowano z łącznie _MAX_ pozycji)",
            "paginate": {
                "first": "Pierwsza",
                "last": "Ostatnia",
                "next": "Następna",
                "previous": "Poprzednia"
            }
        },
        "lengthMenu": [
            [16, 32, 64, -1],
            [16, 32, 64, "All"]
        ],
        "scrollX": true
    });