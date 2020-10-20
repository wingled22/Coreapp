// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$('button[data-toggle="ajax-modal"]').click(

$(function () {
    var placeHolderElement = $('#placeholder');

    //this is the undelegated function which the buttons dont function when the body was rendered of ajax
    //$('button[data-toggle="ajax-modal"]').click(function (event) {
    //    var url = $(this).data('url');
    //    var decodedUrl = decodeURIComponent(url);
    //    $.get(decodedUrl).done(function (data) {
    //        placeHolderElement.html(data);
    //        placeHolderElement.find('.modal').modal('show');
    //    });
    //});

    //new delegate code for same as above
    $(document).on('click', 'button[data-toggle="ajax-modal"]', function (event) {
        //get the url of @url.action code
        var url = $(this).data('url');
        //decode the uri component this is used for updating to display the existing data
        //on to the input fields
        var decodedUrl = decodeURIComponent(url);
        //send  a get request
        //if success the put the return data to the html and open the modakl
        $.get(decodedUrl).done(function (data) {
            placeHolderElement.html(data);
            placeHolderElement.find('.modal').modal('show');
        });
    });

    //if the use click save 
    placeHolderElement.on("click", '[data-save="modal"]', function (event) {
        event.preventDefault();
        //get the form, action and serialize the form and send it to the controller
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();

        //post the changes
        $.post(actionUrl, sendData).done(function (data) {

            //if the post was success then replace the body with the new body
            var newBody = $('.modal-body', data);
            placeHolderElement.find('.modal-body').replaceWith(newBody);

            //check if the isValid : use for validation
            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            if (isValid) {
                //hide the modal
                placeHolderElement.find('.modal').modal('hide');
                //replace the contents of the body using ajax
                var tableElement = $('#tableElement');
                var tableUrl = tableElement.data('url');
                $.get(tableUrl).done(function (table) {
                    tableElement.replaceWith(table);
                });

            }

            //the only issue of this code we cannot close the delete modal
            //if the action was delete because there is no[name = "isvalid"] field
            //so add <input name="IsDelete" type="hidden" value="True" /> to the form of the delete modal
            //check if the current modal was a corect modal
            var isDeleteModal = newBody.find('[name="IsDelete"]').val() == 'True';
            if (isDeleteModal) {
                //hide the modal
                placeHolderElement.find('.modal').modal('hide');
                //replace the contents of the body using ajax
                var tableElement = $('#tableElement');
                var tableUrl = tableElement.data('url');
                $.get(tableUrl).done(function (table) {
                    tableElement.replaceWith(table);
                });

            }
        });
    });
})
