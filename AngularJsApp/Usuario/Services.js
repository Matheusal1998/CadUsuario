usuarioApp.service('usuarioservices', function ($http) {

    this.GetTodosUsuario = function () {
        return $http.get("/Usuario/ListaUsuario");
    }

})