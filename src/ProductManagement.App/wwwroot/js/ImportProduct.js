$(document).ready(function () {
    $('#divUpload').hide();
    $('#divSuccess').hide();
    $('#divProcessing').hide();

    $(':file').on('change', function () {
        var file = this.files[0];

        if (!(/\.(csv)$/i).test(file.name)) {
            errorAlert('File must be a CSV');
            this.form.reset();
        }
    });

    $(':button').on('click',
        function () {
            $.ajax({
                url: '/api/ImportProduct',
                type: 'POST',
                data: new FormData($('form')[0]),

                cache: false,
                contentType: false,
                processData: false,

                xhr: function () {
                    var myXhr = $.ajaxSettings.xhr();
                    if (myXhr.upload) {
                        $('#divUpload').show();
                        myXhr.upload.addEventListener('progress',
                            function (e) {
                                if (e.lengthComputable) {
                                    $('progress').attr({
                                        value: e.loaded,
                                        max: e.total
                                    });

                                    if (e.loaded === e.total) {
                                        $('#divUpload').hide();
                                        $('#divProcessing').show();
                                    }
                                }
                            },
                            false);
                    }

                    return myXhr;
                }
            }).done(function () {
                $('#divUpload').hide();
                $('#divProcessing').hide();

                swal({
                    type: 'success',
                    title: 'Success!',
                    text: 'The import was a success!',
                    showConfirmButton: true,
                }).then(function() {
                    window.location.href = productsUrl;
                });
            })
            .fail(function (message) {
                $('#divUpload').hide();
                $('#divProcessing').hide();
                $('#divSuccess').hide();
                errorAlert(message.responseText);
            });
        });
});

function errorAlert(message) {
    swal({
        type: 'error',
        title: 'Oops...',
        text: message,
    });
}