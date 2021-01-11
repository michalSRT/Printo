// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// ORDERS/EDIT disable fields when UserType == 2
$(document).ready(function () {
    var userTypeID = $("#hdnSession").data('value');
    if (userTypeID == "2") {
        document.getElementById("NetPrice").readOnly = true;
        document.getElementById("PaymentDetails").readOnly = true;
        document.getElementById("DeliveryDetails").readOnly = true;
        document.getElementById("SheetsNumber").readOnly = true;
        document.getElementById("Description").readOnly = true;
        document.getElementById("OrderName").readOnly = true;
        document.getElementById("startDate").readOnly = true;
        document.getElementById("endDate").readOnly = true;
        document.getElementById("Quantity").readOnly = true;
        document.getElementById("Invoice").readOnly = true;
        document.getElementById("clientName").readOnly = true;
    }
})

// CLIENTS/EDIT disable fields when UserType == 2
$(document).ready(function () {
    var userTypeID = $("#hdnSessionClient").data('value');
    if (userTypeID == "2") {
        document.getElementById("clientName").readOnly = true;
        document.getElementById("companyFullName").readOnly = true;
        document.getElementById("nip").readOnly = true;
        document.getElementById("phone").readOnly = true;
        document.getElementById("email").readOnly = true;
        document.getElementById("street").readOnly = true;
        document.getElementById("houseNumber").readOnly = true;
        document.getElementById("appartmentNumber").readOnly = true;
        document.getElementById("postalCode").readOnly = true;
        document.getElementById("city").readOnly = true;
        document.getElementById("descriptionClient").readOnly = true;
    }
})

// Kolorowanie aktywnej zakładki w menu
$(document).ready(function () {
    // get current URL path and assign 'active' class
    var pathname = window.location.pathname;
    $('.navbar-nav > li > a[href="' + pathname + '"]').parent().addClass('active-nav');
})

// SELECT2
$('.select2').select2(
    {
        theme: 'bootstrap4',
    });

$('.myselect').select2(
    {
        width: 'resolve',
        height: 'resolve',
        allowClear: true,
        placeholder: {
            id: '0', // the value of the option
            text: 'Wybierz...'
        },
        sorter: function (data) {
            return data.sort(function (a, b) {
                return a.text < b.text ? -1 : a.text > b.text ? 1 : 0;
            })
        }
    });

$('.select2-multi').select2(
    {
        multiple: true,
        theme: 'bootstrap4',
    });

//DATETIMEPICKERS
$.datetimepicker.setLocale('pl');

$('#startDate').datetimepicker({
    contentWindow: window,
    timepicker: false,
    format: 'd.m.Y',
    dayOfWeekStart: 1,
    defaultDate: new Date()
});

$('#endDate').datetimepicker({
    contentWindow: window,
    timepicker: false,
    format: 'd.m.Y',
    dayOfWeekStart: 1,
    defaultDate: new Date()
});

$('#PrintDate').datetimepicker({
    contentWindow: window,
    step: 15,
    minTime: '7:00',
    maxTime: '23:15',
    format: 'd.m.Y H:i',
    dayOfWeekStart: 1,
    defaultDate: new Date()
});

$('#toDoDate').datetimepicker({
    contentWindow: window,
    step: 15,
    minTime: '7:00',
    maxTime: '23:15',
    format: 'd.m.Y H:i',
    dayOfWeekStart: 1,
    defaultDate: new Date()
});

// DATA TABLES
$('#dataTable-1').DataTable(
    {
        "language": {
            "lengthMenu": "Pokaż _MENU_",
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
            [10, 50, 100, -1],
            [10, 50, 100, "Wszystkie"]
        ],
        "dom": "frtilp",
        //"scrollX": true,
    });

$('#dataTable-2').DataTable(
    {
        "language": {
            "lengthMenu": "Pokaż _MENU_",
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
            [10, 50, 100, -1],
            [10, 50, 100, "Wszystkie"]
        ],
        "dom": "frtilp",
        //"scrollX": true,
    });

$('#dataTable-orders').DataTable(
    {
        "language": {
            "lengthMenu": "Pokaż _MENU_",
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
            [10, 50, 100, -1],
            [10, 50, 100, "Wszystkie"]
        ],
        "dom": "frtilp",
        //"scrollX": true
    });

$('.drgpicker').daterangepicker(
    {
        singleDatePicker: true,
        timePicker: false,
        showDropdowns: true,
        locale:
        {
            format: 'MM/DD/YYYY'
        }
    });
$('.time-input').timepicker(
    {
        'scrollDefault': 'now',
        'zindex': '9999' /* fix modal open */
    });
/** date range picker */
if ($('.datetimes').length) {
    $('.datetimes').daterangepicker(
        {
            timePicker: true,
            startDate: moment().startOf('hour'),
            endDate: moment().startOf('hour').add(32, 'hour'),
            locale:
            {
                format: 'M/DD hh:mm A'
            }
        });
}
var start = moment().subtract(29, 'days');
var end = moment();

function cb(start, end) {
    $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
}
$('#reportrange').daterangepicker(
    {
        startDate: start,
        endDate: end,
        ranges:
        {
            'Today': [moment(), moment()],
            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        }
    }, cb);
cb(start, end);
$('.input-placeholder').mask("00/00/0000",
    {
        placeholder: "__/__/____"
    });
$('.input-zip').mask('00000-000',
    {
        placeholder: "____-___"
    });
$('.input-money').mask("#.##0,00",
    {
        reverse: true
    });
$('.input-phoneus').mask('(000) 000-0000');
$('.input-mixed').mask('AAA 000-S0S');
$('.input-ip').mask('0ZZ.0ZZ.0ZZ.0ZZ',
    {
        translation:
        {
            'Z':
            {
                pattern: /[0-9]/,
                optional: true
            }
        },
        placeholder: "___.___.___.___"
    });
// editor
var editor = document.getElementById('editor');
if (editor) {
    var toolbarOptions = [
        [
            {
                'font': []
            }],
        [
            {
                'header': [1, 2, 3, 4, 5, 6, false]
            }],
        ['bold', 'italic', 'underline', 'strike'],
        ['blockquote', 'code-block'],
        [
            {
                'header': 1
            },
            {
                'header': 2
            }],
        [
            {
                'list': 'ordered'
            },
            {
                'list': 'bullet'
            }],
        [
            {
                'script': 'sub'
            },
            {
                'script': 'super'
            }],
        [
            {
                'indent': '-1'
            },
            {
                'indent': '+1'
            }], // outdent/indent
        [
            {
                'direction': 'rtl'
            }], // text direction
        [
            {
                'color': []
            },
            {
                'background': []
            }], // dropdown with defaults from theme
        [
            {
                'align': []
            }],
        ['clean'] // remove formatting button
    ];
    var quill = new Quill(editor,
        {
            modules:
            {
                toolbar: toolbarOptions
            },
            theme: 'snow'
        });
}
// Example starter JavaScript for disabling form submissions if there are invalid fields
(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();