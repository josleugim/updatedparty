$(document).ready(function () {
    $("#searchForm").submit(function () {
        $.getJSON($(this).attr("action"),
     $(this).serialize(),
     function (data) {
         var result = $("#searchTemplate").tmpl(data);
         $("#searchResults").empty()
         .append(result);
     }
     );
        return false;
    });
})