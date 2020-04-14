// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Get the modal
var modal = document.getElementById("myModal");

// Get the image and insert it inside the modal - use its "alt" text as a caption
var img = document.getElementById("myImg");
var modalImg = document.getElementById("img01");
var captionText = document.getElementById("caption");
img.onclick = function () {
    modal.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

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
