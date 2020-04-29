// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var modal = document.getElementById("myModal");
var i;

var img = document.getElementsByClassName("rounded");
var modalImg = document.getElementById("img01");

for (i = 0; i < img.length; i++) {
    img[i].onclick = function () {

        modal.style.display = "block";
        modalImg.src = this.src;

    }
}

var span = document.getElementsByClassName("close")[0];


span.onclick = function () {
    modal.style.display = "none";
}

//$(document).ready(function () {
//    $("img").click(function () {
//        var img = $(this).attr('src');
//        $("#show-img").attr('src', img);
//        $("#imgmodal").modal('show');
//    });
//});



var options = {
    url: function (search) {
        return "/AutocompleteResult";
    },

    getValue: function (element) {
        return element.name;
    },

    ajaxSettings:
    {
        dataType: "Json",
        method: "POST",
        data: {
            dataType: "Json"
        }
    },

    preparePostData: function (data) {
        data.search = $("#search").val();
        return data;
    },

    requestDelay: 400
};

$("#search").easyAutocomplete(options);

