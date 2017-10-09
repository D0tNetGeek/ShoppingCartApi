(function () {
    $(".make-request").on('click',
        function() {
            var url = $(this).data('url');
            var data = { Id: $(this).data('id') };
            $.ajax({
                    url: url,
                    type: 'POST',
                    dataType: 'json',
                    data: data
                })
                .done(function (data) {
                    alert(data.text);
                })
                .fail(function(data) {
                    alert(data.text);
                });
        });
})();