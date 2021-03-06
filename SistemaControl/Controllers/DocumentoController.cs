﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BackEnd.BLL;
using BackEnd.Model;
using PagedList;
using SistemaControl.Models;

namespace SistemaControl.Controllers
{
    //[Authorize]
    public class DocumentoController : Controller
    {
        private IDocumentoBLL documentoBll;
        private ITablaGeneralBLL tablaGeneralBLL;
        private static PagedList<Documento> model;
        public int pageglobal;
        public List<Documento> referencias =new List<Documento>();

        public ActionResult Index(string option, string search, int page = 1, int pageSize = 4)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return null;
            }

            if (option == "Número de Oficio" && !String.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                ViewBag.option = option;
                //ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                //List<Documento> listaDocumentos = documentoBll.Find(x => x.numeroDocumento == search && x.idTipo == 3|| search == null).ToList();
                //PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, pageNumber, pageSize);
                //return View(model.ToPagedList(pageNumber, pageSize));
                var listaDocumentos = documentoBll.Find(x => x.numeroDocumento.Contains(search) && x.idTipo == 3 && x.idEstado != 9 && x.numeroIngreso!=null|| search == null).ToList();
                if (!String.IsNullOrEmpty(search))
                {
                    ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                    ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                    foreach (Documento documento in listaDocumentos)
                    {
                        documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                        documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                        documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                        if (documento.idEstado.HasValue)
                        {
                            int i = (int)(documento.idEstado);
                            documento.TablaGeneral = tablaGeneralBLL.Get(i);
                        }
                    }
                }
                PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
            else if (option == "Número de Ingreso" && !String.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                ViewBag.option = option;
                //ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                //List<Documento> listaDocumentos = documentoBll.Find(x => x.numeroIngreso == search && x.idTipo == 3|| search == null).ToList();
                //PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, pageNumber, pageSize);
                //return View(model);
                var listaDocumentos = documentoBll.Find(x => x.numeroIngreso.Contains(search) && x.idTipo == 3 && x.idEstado != 9 && x.numeroIngreso != null || search == null).ToList();
                if (!String.IsNullOrEmpty(search))
                {
                    ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                    ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                    foreach (Documento documento in listaDocumentos)
                    {
                        documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                        documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                        documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                        if (documento.idEstado.HasValue)
                        {
                            int i = (int)(documento.idEstado);
                            documento.TablaGeneral = tablaGeneralBLL.Get(i);
                        }
                    }
                }
                PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
            else if (option == "Fecha" && !String.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                ViewBag.option = option;
                //ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                //List<Documento> listaDocumentos = documentoBll.Find(x => x.asunto == search && x.idTipo == 3 || search == null && x.idTipo == 3).ToList();
                //PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, pageNumber, pageSize);
                //return View(model);
                DateTime date = Convert.ToDateTime(search);
                var listaDocumentos = documentoBll.Find(x => x.fecha.Equals(date) && x.idTipo == 3 && x.idEstado != 9 && x.numeroIngreso != null || search == null).ToList();
                if (!String.IsNullOrEmpty(search))
                {
                    ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                    ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                    foreach (Documento documento in listaDocumentos)
                    {
                        documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                        documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                        documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                        if (documento.idEstado.HasValue)
                        {
                            int i = (int)(documento.idEstado);
                            documento.TablaGeneral = tablaGeneralBLL.Get(i);
                        }
                    }
                }
                PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
            else if (option == "" || String.IsNullOrEmpty(search))
            {
                option = "";
                search = null;
                ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                var documentos = documentoBll.Find(x => search == null && x.idTipo == 3 && x.idEstado != 9 && x.numeroIngreso != null || x.idTipo == 23);
                List<Documento> listaDocumentos = documentos.ToList();
                foreach (Documento documento in listaDocumentos)
                {
                    documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                    documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                    documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                    if (documento.idEstado.HasValue)
                    {
                        int i = (int)(documento.idEstado);
                        documento.TablaGeneral = tablaGeneralBLL.Get(i);
                    }
                }
                PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
            else
            {
                ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                var documentos = documentoBll.Find(x => search == null && x.idTipo == 3 && x.idEstado != 9 && x.numeroIngreso != null || x.idTipo == 23);
                List<Documento> listaDocumentos = documentos.ToList();
                foreach (Documento documento in listaDocumentos)
                {
                    documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                    documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                    documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                    if (documento.idEstado.HasValue)
                    {
                        int i = (int)(documento.idEstado);
                        documento.TablaGeneral = tablaGeneralBLL.Get(i);
                    }
                }
                PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
        }

        public ActionResult IndexSalidas(string option, string search, int page = 1, int pageSize = 4)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return null;
            }

            if (option == "Número de Oficio" && !String.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                ViewBag.option = option;
                //ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                //List<Documento> listaDocumentos = documentoBll.Find(x => x.numeroDocumento == search && x.idTipo == 3|| search == null).ToList();
                //PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, pageNumber, pageSize);
                //return View(model.ToPagedList(pageNumber, pageSize));
                var listaDocumentos = documentoBll.Find(x => x.numeroDocumento.Contains(search) && x.idTipo == 3 && x.idEstado != 9 && x.numeroIngreso == null || search == null).ToList();
                if (!String.IsNullOrEmpty(search))
                {
                    ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                    ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                    foreach (Documento documento in listaDocumentos)
                    {
                        documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                        documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                        documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                        if (documento.idEstado.HasValue)
                        {
                            int i = (int)(documento.idEstado);
                            documento.TablaGeneral = tablaGeneralBLL.Get(i);
                        }
                    }
                }
                PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
            else if (option == "Número de Ingreso" && !String.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                ViewBag.option = option;
                //ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                //List<Documento> listaDocumentos = documentoBll.Find(x => x.numeroIngreso == search && x.idTipo == 3|| search == null).ToList();
                //PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, pageNumber, pageSize);
                //return View(model);
                var listaDocumentos = documentoBll.Find(x => x.numeroIngreso.Contains(search) && x.idTipo == 3 && x.idEstado != 9 && x.numeroIngreso == null || search == null).ToList();
                if (!String.IsNullOrEmpty(search))
                {
                    ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                    ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                    foreach (Documento documento in listaDocumentos)
                    {
                        documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                        documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                        documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                        if (documento.idEstado.HasValue)
                        {
                            int i = (int)(documento.idEstado);
                            documento.TablaGeneral = tablaGeneralBLL.Get(i);
                        }
                    }
                }
                PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
            else if (option == "Fecha" && !String.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                ViewBag.option = option;
                //ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                //List<Documento> listaDocumentos = documentoBll.Find(x => x.asunto == search && x.idTipo == 3 || search == null && x.idTipo == 3).ToList();
                //PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, pageNumber, pageSize);
                //return View(model);
                DateTime date = Convert.ToDateTime(search);
                var listaDocumentos = documentoBll.Find(x => x.fecha.Equals(date) && x.idTipo == 3 && x.idEstado != 9 && x.numeroIngreso == null || search == null).ToList();
                if (!String.IsNullOrEmpty(search))
                {
                    ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                    ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                    foreach (Documento documento in listaDocumentos)
                    {
                        documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                        documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                        documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                        if (documento.idEstado.HasValue)
                        {
                            int i = (int)(documento.idEstado);
                            documento.TablaGeneral = tablaGeneralBLL.Get(i);
                        }
                    }
                }
                PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
            else if (option == "" || String.IsNullOrEmpty(search))
            {
                option = "";
                search = null;
                ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                var documentos = documentoBll.Find(x => search == null && x.idTipo == 3 && x.idEstado != 9 && x.numeroIngreso == null || x.idTipo == 23);
                List<Documento> listaDocumentos = documentos.ToList();
                foreach (Documento documento in listaDocumentos)
                {
                    documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                    documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                    documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                    if (documento.idEstado.HasValue)
                    {
                        int i = (int)(documento.idEstado);
                        documento.TablaGeneral = tablaGeneralBLL.Get(i);
                    }
                }
                PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
            else
            {
                ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                var documentos = documentoBll.Find(x => search == null && x.idTipo == 3 && x.idEstado != 9 && x.numeroIngreso == null || x.idTipo == 23);
                List<Documento> listaDocumentos = documentos.ToList();
                foreach (Documento documento in listaDocumentos)
                {
                    documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                    documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                    documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                    if (documento.idEstado.HasValue)
                    {
                        int i = (int)(documento.idEstado);
                        documento.TablaGeneral = tablaGeneralBLL.Get(i);
                    }
                }
                PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
        }

        public ActionResult IndexReferencias(string option,int id, string search, int page = 1, int pageSize = 15)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return null;
            }
            search = id.ToString();

            //Documento docu = documentoBll.Get(id);
            //// var doc = documentoBll.Find(x => x.numeroDocumento.Equals(search) && x.idTipo == 3 || search == null).ToList();
            //var referencias = documentoBll.listaReferencias(docu.idReferencia);

            ////var listaDocumentos = doc.Union(referencias);
            //var listaDocumentos = referencias;

            ////listaDocumentos.Union(listaDocumentos);
            if (!String.IsNullOrEmpty(search))
            {
                //var doc = documentoBll.Find(x => x.numeroDocumento.Equals(search) && x.idTipo == 3 && x.idEstado != 9 || search == null).ToList();
                var doc = documentoBll.Find(x => x.idDocumento.Equals(id) && x.idTipo == 3 && x.idEstado != 9).ToList();
                var referencias = documentoBll.listaReferencias(doc[0].idReferencia);
                var listaDocumentos = referencias;

              //  listaDocumentos.Union(listaDocumentos);
                if (!String.IsNullOrEmpty(search))
                {
                    ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                    ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                    ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                    ViewBag.numeroDocumento = new SelectList(tablaGeneralBLL.Consulta("Documentos", "numeroDocumento"), "idTablaGeneral", "descripcion");
                    foreach (Documento documento in listaDocumentos)
                    {
                        documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                        documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                        documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                        if (documento.idEstado.HasValue)
                        {
                            int i = (int)(documento.idEstado);
                            documento.TablaGeneral = tablaGeneralBLL.Get(i);
                        }
                    }
                }

                model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
            
            else
            {
                ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
                ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion");
                ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion");
                var documentos = documentoBll.Find(x => search == null && x.idTipo == 3 && x.idEstado != 9 || x.idTipo == 23);
                List<Documento> listaDocumentos = documentos.ToList();
                foreach (Documento documento in listaDocumentos)
                {
                    documento.TablaGeneral1 = tablaGeneralBLL.Get(documento.idOrigen);
                    documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idTipo);
                    documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                    if (documento.idEstado.HasValue)
                    {
                        int i = (int)(documento.idEstado);
                        documento.TablaGeneral = tablaGeneralBLL.Get(i);
                    }
                }
                referencias = listaDocumentos;
                model = new PagedList<Documento>(listaDocumentos, page, pageSize);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearDocumento(Documento documento)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                documento.idReferencia = documentoBll.generaNumeroReferencia();
                documentoBll.Agregar(documento);
                documentoBll.SaveChanges();
                return RedirectToAction("Index");
            }
            DocumentoViewModel documentoVista = (DocumentoViewModel)documento;
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion", documento.idTipo);
            ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion", documento.tipoOrigen);
            ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion", documento.idOrigen);
            ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion", documento.idEstado);
            return PartialView("Crear", documentoVista);
        }

        public ActionResult Crear()
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return View();
            }
            DocumentoViewModel documento = new DocumentoViewModel();
            documento.fecha = DateTime.Now.Date;
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion", 0);
            ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion", 0);
            ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion", 0);
            ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion", null);
            return PartialView("Crear",documento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmitirDocumento(Documento documento)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                documentoBll.Agregar(documento);
                documentoBll.SaveChanges();
                return RedirectToAction("Index");
            }
            DocumentoViewModel documentoVista = (DocumentoViewModel)documento;
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion", documento.idTipo);
            ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion", documento.tipoOrigen);
            ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion", documento.idOrigen);
            ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion", documento.idEstado);
            return PartialView("Crear", documentoVista);
        }

        public ActionResult Emitir()
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return View();
            }
            DocumentoViewModel documento = new DocumentoViewModel();
            documento.fecha = DateTime.Now.Date;
            documento.numeroDocumento = getNumeroDocumento();
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion", 0);
            ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion", 0);
            ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion", 0);
            ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion", null);
            return PartialView("Crear", documento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetallesDocumento(Documento documento)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                documentoBll.Modificar(documento);
                documentoBll.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion", documento.idTipo);
            ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion", documento.tipoOrigen);
            ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion", documento.idOrigen);
            ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion", documento.idEstado);
            return PartialView("Detalle", documento);

        }

        public ActionResult Detalles(int id)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return View();
            }
            Documento documento = documentoBll.Get(id);
            DocumentoViewModel documentoVista = (DocumentoViewModel)documento;
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion", documentoVista.idTipo);
            ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion", documentoVista.tipoOrigen);
            ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion", documentoVista.idOrigen);
            ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion", documentoVista.idEstado);
            return PartialView("Detalle", documentoVista);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarDocumento(Documento documento)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                documentoBll.generaNumIngreso();
                documentoBll.Modificar(documento);
                documentoBll.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion", documento.idTipo);
            ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion", documento.tipoOrigen);
            ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion", documento.idOrigen);
            ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion", documento.idEstado);
            return PartialView("Editar", documento);

        }

        public ActionResult Editar(int id)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return View();
            }

            Documento documento = documentoBll.Get(id);
            DocumentoViewModel documentoVista = new DocumentoViewModel();
            documentoVista = (DocumentoViewModel)documento;
            documentoVista.fecha = documento.fecha;
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion", documentoVista.idTipo);
            ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion", documentoVista.tipoOrigen);
            ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion", documentoVista.idOrigen);
            ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion", documentoVista.idEstado);
            return PartialView("Editar", documentoVista);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResponderDocumento(Documento documento)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
                
            }
            catch (Exception)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                documentoBll.Agregar(documento);
                documentoBll.generaNumIngreso();
                documentoBll.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion", documento.idTipo);
            ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion", documento.tipoOrigen);
            ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion", documento.idOrigen);
            ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion", documento.idEstado);
            return PartialView("Editar", documento);

        }

        public ActionResult Responder(int id)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return View();
            }
            DocumentoViewModel documentoVista = new DocumentoViewModel();

            documentoVista.fecha = DateTime.Now;
            documentoVista.numeroDocumento = getNumeroDocumento();

            documentoVista.idTipo = tablaGeneralBLL.getIdTablaGeneral("Documentos","tipo","Oficio");
            documentoVista.idOrigen = tablaGeneralBLL.getIdTablaGeneral("Documentos", "idOrigen", "Servicios jurídicos");
            documentoVista.tipoOrigen = tablaGeneralBLL.getIdTablaGeneral("Documentos", "tipoOrigen", "Departamento Interno");
            documentoVista.idEstado = tablaGeneralBLL.getIdTablaGeneral("Documentos", "estado", "Activo");
            documentoVista.idReferencia = documentoBll.Get(id).idReferencia;
            //documentoVista.idReferenciaView = documentoBll.Get(id).numeroDocumento;
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion", documentoVista.idTipo);
            ViewBag.tipoOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipoOrigen"), "idTablaGeneral", "descripcion", documentoVista.tipoOrigen);
            ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion", documentoVista.idOrigen);
            ViewBag.idEstado = new SelectList(tablaGeneralBLL.Consulta("Documentos", "estado"), "idTablaGeneral", "descripcion", documentoVista.idEstado);
            return PartialView("Responder", documentoVista);

        }

        //Reportes en PDF de referencias
        public ActionResult ReportesReferencias()
        {

            List<Documento> _referencias = new List<Documento>();
            List<List<string>> Lista = new List<List<string>>();

            foreach (Documento iTem in model)
            {
                Documento doc = new Documento();
                doc.idDocumento = iTem.idDocumento;
                doc.numeroDocumento = iTem.numeroDocumento;
                doc.numeroIngreso = iTem.numeroIngreso;
                doc.fecha = iTem.fecha;
                doc.tipoOrigen = iTem.tipoOrigen;
                doc.idOrigen = iTem.idOrigen;
                doc.idEstado = iTem.idEstado;
                string tipoOrigen = iTem.TablaGeneral3.descripcion;
                string origen= iTem.TablaGeneral1.descripcion;
                string estado = iTem.TablaGeneral.descripcion;

                List<string> datos = new List<string>();
                datos.Add(tipoOrigen);
                datos.Add(origen);
                datos.Add(estado);
                Lista.Add(datos);
                _referencias.Add(doc);
            }

            DateTime fecha = DateTime.Now;
            string _fecha = fecha.ToString("dd/MM/yyyy");

            ReporteModel reportes = new ReporteModel();
            byte[] abyte = reportes.PrepareReport(_referencias,Lista,_fecha);
            return File(abyte, "application/pdf");



        }


        [HttpPost, ValidateInput(false)]
        public ActionResult Archivar(int id)
        {
            try
            {
                documentoBll = new DocumentoBLLImpl();
                documentoBll.archivaDocumento(id);
                documentoBll.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult TablaDocumentos(string option, string search, string currentFilter, string sortOrder,int salent, int? page)
        {

            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return View();
            }
            List<Documento> listaDocumentos;
            if (salent == 1)
            {
                listaDocumentos = documentoBll.listaEntradas();
            }
            else
            {
                listaDocumentos = documentoBll.listaSalidas();
            }
            foreach (Documento documento in listaDocumentos)
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documento.TablaGeneral = tablaGeneralBLL.Get(documento.idOrigen);
                documento.TablaGeneral3 = tablaGeneralBLL.Get(documento.tipoOrigen);
                documento.TablaGeneral2 = tablaGeneralBLL.Get(documento.idOrigen);
                if (documento.idEstado.HasValue)
                {
                    int i = (int)(documento.idEstado);
                    documento.TablaGeneral1 = tablaGeneralBLL.Get(i);
                }
            }
            ViewBag.CurrentSort = sortOrder;

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            ViewBag.idTipo = new SelectList(tablaGeneralBLL.Consulta("Documentos", "tipo"), "idTablaGeneral", "descripcion");
            ViewBag.NumeroOficio = String.IsNullOrEmpty(sortOrder) ? "numerodocdes" : "";
            ViewBag.Ingreso = sortOrder == "Ingreso" ? "IngresoDes" : "Ingreso";
            ViewBag.FechaDeIngreso = sortOrder == "Fecha" ? "FechaDes" : "Fecha";
            var documentos = from s in documentoBll.Find(x => search == null && x.idTipo == 3 || x.idTipo == 23) select s;

            switch (sortOrder)
            {
                case "numerodocdes":
                    documentos = documentos.OrderByDescending(s => s.numeroDocumento);
                    break;
                case "Fecha":
                    documentos = documentos.OrderBy(s => s.fecha);
                    break;
                case "FechaDes":
                    documentos = documentos.OrderByDescending(s => s.fecha);
                    break;
                case "Ingreso":
                    documentos = documentos.OrderBy(s => s.numeroIngreso);
                    break;
                case "IngresoDes":
                    documentos = documentos.OrderByDescending(s => s.numeroIngreso);
                    break;
                default:
                    documentos = documentos.OrderBy(s => s.numeroDocumento);
                    break;
            }

            PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, pageNumber, pageSize);
            return View(model);
        }

        public ActionResult Referencias(string option, string search, string currentFilter, string sortOrder, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            List<Documento> listaDocumentos = new List<Documento>();
            PagedList<Documento> model = new PagedList<Documento>(listaDocumentos, page.Value, 4);
            return PartialView("Referencias", model);
            //return PartialView("Referencias",);
        }

        public string getNumeroDocumento()
        {
            string numeroDocumento = (documentoBll.consultaNumeroIngreso() + 1).ToString();
            if (numeroDocumento.Length == 1)
            {
                numeroDocumento = "000" + numeroDocumento;
            }
            else if (numeroDocumento.Length == 2)
            {
                numeroDocumento = "00" + numeroDocumento;
            }
            else
            {
                numeroDocumento = "0" + numeroDocumento;
            }
            return "MA-" + "PSJ-" + numeroDocumento + "-" + DateTime.Now.Year.ToString();
        }

        public JsonResult ComprobarDocumento(string numeroDocumento, string idDocumento)
        {
            try
            {
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return null;
            }
            if (documentoBll.Comprobar(numeroDocumento,1, idDocumento))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("El número de ingreso no se encuentra disponible o ya se encuentra ocupado.\n Por favor inténtelo de nuevo.", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ComprobarIngreso(string numeroIngreso, string idDocumento)
        {
            try
            {
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return null;
            }
            if (documentoBll.Comprobar(numeroIngreso, 2, idDocumento))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("El número de ingreso no se encuentra disponible.\n Por favor inténtelo de nuevo.", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ComprobarDropdownList(string id)
        {
            if (id != "")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //ModelState.AddModelError("idTipo", "Last Name is required.");
                //return Json(new { success = false, errors = "Debe seleccionar una opción válida.\n Por favor inténtelo de nuevo." }, JsonRequestBehavior.AllowGet);
                return Json("Debe seleccionar una opción válida.\n Por favor inténtelo de nuevo.", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Search(string name)
        {
            try
            {
                documentoBll = new DocumentoBLLImpl();
            }
            catch (Exception)
            {
                return null;
            }
            var resultado = documentoBll.Find(x => x.numeroDocumento.Contains(name)).Select(x => x.numeroDocumento).Take(11).ToList();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoOrigen(int id)
        {
            try
            {
                tablaGeneralBLL = new TablaGeneralBLLImpl();
                documentoBll = new DocumentoBLLImpl();
                switch (id)
                {
                    case 5:
                        ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                        break;
                    case 6:
                        ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigenExterno"), "idTablaGeneral", "descripcion");
                        break;
                    default:
                        ViewBag.idOrigen = new SelectList(tablaGeneralBLL.Consulta("Documentos", "idOrigen"), "idTablaGeneral", "descripcion");
                        break;
                }
            }
            catch (Exception)
            {
                
            }
            return this.Json(new { Id = "idOrigen",Reg="OIJ" ,Data = ViewBag.idOrigen }, JsonRequestBehavior.AllowGet);
        }
        
    }
}