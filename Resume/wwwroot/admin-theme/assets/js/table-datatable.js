$(function() {
	"use strict";

    $(document).ready(function() {
        $('#allContacts').DataTable();
      } );


      $(document).ready(function() {
        var table = $('#allContacts').DataTable( {
            lengthChange: false,
            buttons: [ 'copy', 'excel', 'pdf', 'print']
        } );
     
        table.buttons().container()
            .appendTo( '#wrappertable .col-md-6:eq(0)' );
    } );


});