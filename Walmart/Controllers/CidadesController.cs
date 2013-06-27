using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Walmart.Entity;
using Walmart.Data;

namespace Walmart.Controllers
{
    public class CidadesController : Controller
    {

        public ActionResult Index()
        {
            List<Cidade> cidades = CidadeDAO.Listar();
            return View(cidades);
        }        

        public ActionResult Incluir()
        {
            ViewBag.Estados = EstadoDAO.Listar();
            return View();
        } 

        [HttpPost]
        public ActionResult Incluir(Cidade cidade)
        {
            try
            {
                CidadeDAO.Adicionar(cidade);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Estados = EstadoDAO.Listar();
                ViewBag.Erro = "Erro";
                return View(cidade);
            }
        }
        
 
        public ActionResult Editar(int codigo)
        {
            ViewBag.Estados = EstadoDAO.Listar();
            Cidade c = CidadeDAO.ObterCidade(codigo: codigo);
            return View(c);
        }


        [HttpPost]
        public ActionResult Editar(Cidade cidade)
        {
            try
            {
                CidadeDAO.Atualizar(cidade); 
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Erro = "Erro";
                ViewBag.Estados = EstadoDAO.Listar();
                return View(cidade);
            }
        }
        [HttpPost]
        public JsonResult Delete(int codigo)
        {
            try
            {
                CidadeDAO.Delete(codigo);
                return Json("sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Detalhes(int codigo)
        {
            Cidade cidade = CidadeDAO.ObterCidadeXml(codigo: codigo);
            return View(cidade);
        }

      
    }
}
