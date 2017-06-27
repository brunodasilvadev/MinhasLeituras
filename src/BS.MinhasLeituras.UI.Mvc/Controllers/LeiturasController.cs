using BS.MinhasLeituras.Application.Interfaces;
using BS.MinhasLeituras.Application.ViewModels;
using BS.MinhasLeituras.CrossCutting.MvcFilters;
using System;
using System.Net;
using System.Web.Mvc;

namespace BS.MinhasLeituras.UI.Mvc.Controllers
{
    public class LeiturasController : Controller
    {
        private readonly ILeituraAppService _leituraAppService;

        public LeiturasController(ILeituraAppService leituraAppService)
        {
            _leituraAppService = leituraAppService;
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        // GET: Leituras
        public ActionResult Index()
        {
            return View(_leituraAppService.ObterTodos());
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        // GET: Leituras/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var leituraViewModel = _leituraAppService.ObterPorId(id.Value);
            if (leituraViewModel == null)
            {
                return HttpNotFound();
            }
            return View(leituraViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        // GET: Leituras/Create
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        // POST: Leituras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeituraViewModel leituraViewModel)
        {
            if (ModelState.IsValid)
            {
                leituraViewModel = _leituraAppService.Adicionar(leituraViewModel);

                return RedirectToAction("Index");
            }

            return View(leituraViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        // GET: Leituras/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var leituraViewModel = _leituraAppService.ObterPorId(id.Value);
            if (leituraViewModel == null)
            {
                return HttpNotFound();
            }
            return View(leituraViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        // POST: Leituras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeituraViewModel leituraViewModel)
        {
            if (ModelState.IsValid)
            {
                _leituraAppService.Atualizar(leituraViewModel);
                return RedirectToAction("Index");
            }
            return View(leituraViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        // GET: Leituras/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var leituraViewModel = _leituraAppService.ObterPorId(id.Value);
            if (leituraViewModel == null)
            {
                return HttpNotFound();
            }
            return View(leituraViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        // POST: Leituras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _leituraAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _leituraAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
