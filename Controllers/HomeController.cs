using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteSaúde.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace SiteSaúde.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Paciente()
        {
            return View();
        }
        public IActionResult CadastroMed()
        {
            return View();
        }
        public IActionResult CadastroPac()
        {
            return View();
        }
        public IActionResult Agendamentos()
        {
            return View();
        }
        public IActionResult Selecao()
        {
            return View();
        }


        public IActionResult AuthCadMed(string nome, string cpf, string email, string senha, string tel, string especialidade) //Cadastro Do(s) Médico(s)
        {
            MedicoCadastro medico = new MedicoCadastro()
            {
                Nome = nome,
                Cpf = cpf,
                Email = email,
                Senha = senha,
                Tel = tel,
                Especialidade = especialidade
            };
            Response res = MedicoCadastroController.CheckerInsert(medico);
            if (res.Executed)
            {
                return RedirectToAction("Medico", "Home");
            }
            else
            {
                ViewBag.Erro = "Deu Ruim";
                return RedirectToAction("CadastroMed", "Home");
            }
        }
        public IActionResult AuthCadPac(string nome, string cpf, string email, string senha, string tel, string confSenha)// Cadastro do Paciente
        { 
            UsuarioCadastro user = new UsuarioCadastro()
            {
                Nome = nome,
                Cpf = cpf,
                Email = email,
                Senha = senha,
                Tel = tel
            };
            if (senha != confSenha)
            {
                ViewBag.Erro = "Deu Ruim";
                return RedirectToAction("CadastroPac", "Home");
            }
            Response res = UsuarioCadastroController.CheckerInsert(user);
            if (res.Executed)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Erro = "Deu Ruim";
                return RedirectToAction("CadastroPac", "Home");
            }
        }
        public IActionResult AuthPac(string email, string senha) // Login do paciente
        {
            UsuarioLogin user = new UsuarioLogin();

            Response res = UsuarioLoginController.CheckerSelect(email, senha, out user);
            if (res.Executed)
            {
                return RedirectToAction("Paciente", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}