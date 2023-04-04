var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('#btnAddNew').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);

            var username = document.getElementById('m_username');
            var name = document.getElementById('m_name');
            var password = document.getElementById('m_password');

            if (username.value == "" || name.value == "" || password.value == "") {
                bootbox.alert("Chưa nhập thông tin cần thiết")
                return;
            }
            if (password.value == document.getElementById('m_password1')) {
                bootbox.alert("Mật khẩu không trùng khớp")
                return;
            }
            $.ajax({
                url: "/User/RegeditAjax",
                data:
                {
                    username: username.value,
                    name: name.value,
                    password: password.value,
                },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        bootbox.alert({
                            message: "Thêm tài khoản thành công!",
                            size: 'medium',
                            closeButton: false
                        });
                        username.value = "";
                        name.value = "";
                        password = "";
                        window.location.href = "/User/Regedit";
                    }
                    else {
                        bootbox.alert(
                            {
                                message: "Thêm tài khoản lỗi",
                                closeButton: false
                            }
                        );
                    }
                }
            });
        });
    }
}
user.init();