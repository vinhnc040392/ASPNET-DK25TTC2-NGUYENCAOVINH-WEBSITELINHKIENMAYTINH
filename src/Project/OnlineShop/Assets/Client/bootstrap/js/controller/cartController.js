var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        //su kien cho nut tiep tuc mua hang
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });

        //su kien cho nut update
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        idProduct: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/CartHome/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.Status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        //su kien cho nut delete tat ca gio hang
        $('#btnDeleteAll').off('click').on('click', function () {

            $.ajax({
                url: '/CartHome/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.Status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        //su kien cho nut delete tung san pham trong gio hang
        $('.btn-delete').off('click').on('click', function () {

            $.ajax({
                url: '/CartHome/Delete',
                data: { id: $(this).data('id') },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.Status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        //su kien cho nut thanh toan
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
    }
}
cart.init();