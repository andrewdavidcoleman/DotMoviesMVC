

function starOnClick(id, saveUrl, deleteUrl, element, event) {
    
    $(element).css("pointer-events", "none");                           //disable click to prevent user from rapid-fire clicking
    const url = $(element).hasClass('saved') ? deleteUrl : saveUrl;     //if the movie is not saved, save it, if it is, delete it
    $(element).toggleClass('saved');                                    //toggle the .saved class to highlight/unhighlight star

    $.post(url, { id }, function () {               //ajax to save/delete, passing movie id    
        $(element).css("pointer-events", "none");   //reenable click
    });

}

function initDataTableHTML() {

    $('#movieTable').DataTable({
        searching: false,       //no search bar
        paging: false,          //no pagination
        order: []               //just display in order returned by OMDB API
    });

}

function initDataTableJS(movies, detailUrl) {

    $('#movieTable').DataTable({
        searching: false,       //no search bar
        paging: false,          //no pagination
        order: [],              //just display in order returned by OMDB API
        data: movies,           //row data source
        rowId: 'imdbId',        //set imdbId to rows id attribute
        columns: [              //column data and titles
            { data: 'title', title: 'Title' },
            { data: 'year', title: 'Year' },
            { data: 'actors', title: 'Starring' },
            { data: 'director', title: 'Director' }
        ]
    });

    $('#movieTable tbody').on('click', 'tr', function () {  //add onclick event for table rows
        window.location = detailUrl + '/' + $(this).attr('id') //get imdbId of movie and go to detail page
    });

}