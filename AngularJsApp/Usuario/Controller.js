usuarioApp.controller('usuarioCtrl', function ($scope, usuarioservice) {


    carregarUsuario();

    function carregarUsuario() {
        var listarUsuario = usuarioservice.getTodosUsuarios();

        listarUsuario.then(function (d) {
            $scope.usuario = d.data;
        }),
            function () {
                alert("Erro");
            }
    }


});