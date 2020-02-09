using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste_CRUD.DAL;
using Teste_CRUD.Models;

namespace Teste_CRUD.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDAL _UsuarioDAL = new UsuarioDAL();
        public IActionResult Index(string busca)
        {
            List<Usuario> ListaUsuaro = new List<Usuario>();
            ListaUsuaro = _UsuarioDAL.GetAllUsuario().ToList();

            if (busca != null)
            {
                return View(ListaUsuaro.Where(x => x.NomeCompleto.Contains(busca)).ToList());
            }
            else {
                return View(ListaUsuaro);
            }

        }

        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _UsuarioDAL.AddUsuario(usuario);
                return RedirectToAction("Index");
            }

            return View();

        }
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            _UsuarioDAL.DeleteUsuario(id);

            return RedirectToAction("Index");
        }
        public IActionResult Detalhe(int id)
        {

            Usuario usuario = new Usuario();
            usuario = _UsuarioDAL.GetUsuario(id);

            return View(usuario);
        }
        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {

            _UsuarioDAL.UpdateUsuario(usuario);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Editar(int Id)
        {
            Usuario usuario = new Usuario(); 
            usuario = _UsuarioDAL.GetUsuario(Id);

            return View(usuario);
        }

        public JsonResult ListaUsuario(string busca)
        {
            List<Usuario> ListaUsuaro = new List<Usuario>();
            ListaUsuaro = _UsuarioDAL.GetAllUsuario().ToList();

            if (busca != null)
            {
                return Json(ListaUsuaro.Where(x => x.NomeCompleto.Contains(busca)).ToList());
            }
            else
            {
                return Json(ListaUsuaro);
            }

        }
    }
}