// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.form-disable').on('submit', function ()
{
    var self = $(this),
        button = self.find('input[type="submit"], button');
    submitValue = button.data('submit-value');

    button.attr('disabled', 'disabled').val(submitValue);
    return false;
});