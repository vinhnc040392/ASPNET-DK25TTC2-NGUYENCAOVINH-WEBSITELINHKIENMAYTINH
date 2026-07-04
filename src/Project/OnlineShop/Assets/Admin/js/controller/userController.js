var user = {
    init: function () {
        user.registerEvent();
    },
    registerEvent: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.prevenDefault();
            var id = $(this).data('id');
            $ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type:"POST",
                //contenType: "application/json;charset=uft-8",
                success: function (response) {
                    if (response.Status == true) {
                        $(this).text('Kích Hoạt');
                    }
                    else {
                        $(this).text('Khóa');
                    }
                }
            });
        });
    }
}
user.init();