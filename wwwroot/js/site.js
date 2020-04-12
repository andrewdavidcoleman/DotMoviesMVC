
function initDataTable() {

    $('#movieTable').DataTable({
        searching: false,
        paging: false,
        order: []
    });

}

function movieTableRowClick(url) {
    window.location = url;
}