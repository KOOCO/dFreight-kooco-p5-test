﻿(function ($) {
    var l = abp.localization.getResource('AbpIdentity');

    var _identityUserAppService = volo.abp.identity.identityUser;

    var togglePasswordVisibility = function () {
        $("#PasswordVisibilityButton").click(function (e) {
            var button = $(this);
            var passwordInput = button.parent().find("input");
            if (!passwordInput) {
                return;
            }

            if (passwordInput.attr("type") === "password") {
                passwordInput.attr("type", "text");
            }
            else {
                passwordInput.attr("type", "password");
            }

            var icon = button.find("i");
            if (icon) {
                icon.toggleClass("fa-eye-slash").toggleClass("fa-eye");
            }
        });
    }

    abp.modals.createUser = function () {
        var initModal = function (publicApi, args) {
            togglePasswordVisibility();
        };
        return { initModal: initModal };
    }

    abp.modals.editUser = function () {
        var initModal = function (publicApi, args) {
            togglePasswordVisibility();
        };
        return { initModal: initModal };
    }

    var _editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Identity/Users/EditModal',
        modalClass: "editUser"
    });

    var _ResetPasswordModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'User/ResetPassword'
    });

    var _createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Identity/Users/CreateModal',
        modalClass: "createUser"
    });
    var _permissionsModal = new abp.ModalManager(
        abp.appPath + 'AbpPermissionManagement/PermissionManagementModal'
    );

    var _dataTable = null;

    abp.ui.extensions.entityActions.get('identity.user').addContributor(
        function (actionList) {
            return actionList.addManyTail(
                [
                    {
                        text: 'Reset Password',                       
                        action: function (data) {
                            _ResetPasswordModal.open({
                                id: data.record.id,
                            });
                        },
                    },
                    {
                        text: l('Delete'),
                        visible: abp.auth.isGranted(
                            'AbpIdentity.Users.Update'
                        ),
                        confirmMessage: function (data) {
                            return l(
                                'UserDeletionConfirmationMessage',
                                data.record.userName
                            );
                        },
                        action: function (data) {
                            _identityUserAppService
                                .delete(data.record.id)
                                .then(function () {
                                    _dataTable.ajax.reload();
                                    abp.notify.success(l('SuccessfullyDeleted'));
                                });
                        },
                    },
                ]
            );
        }
    );

    abp.ui.extensions.tableColumns.get('identity.user').addContributor(
        function (columnList) {
            columnList.addManyByIndex(
                [
                    {
                        title: 'Name',
                        data: 'name',
                    },
                    {
                        title: 'Surname',
                        data: 'surname'
                    }
                ], 1
            );
        }
    );

    $(function () {
        var _$wrapper = $('#IdentityUsersWrapper');
        var _$table = _$wrapper.find('table');
        $.fn.dataTable.ext.errMode = 'none';
        _dataTable = _$table.DataTable(
            abp.libs.datatables.normalizeConfiguration({
                order: [[1, 'asc']],
                processing: true,
                serverSide: true,
                scrollX: true,
                paging: true,
                ajax: abp.libs.datatables.createAjax(
                    _identityUserAppService.getList
                ),
                columnDefs: abp.ui.extensions.tableColumns.get('identity.user').columns.toArray()
            })
        );
        
        _createModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _editModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        $('#AbpContentToolbar button[name=CreateUser]').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });
})(jQuery);
