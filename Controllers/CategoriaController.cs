﻿using ApiCatalogo.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCatalogo.Models;

namespace ApiCatalogo.Controllers
{
    public class CategoriaController : Controller
    {
        [Route("api/[Controller]")]
        [ApiController]
        public class CategoriasController : ControllerBase
        {
            private readonly AppDbContext _context;
            public CategoriasController(AppDbContext contexto)
            {
                _context = contexto;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Categoria>> Get()
            {
                return _context.Categorias.AsNoTracking().ToList();
            }

            [HttpGet("{id}", Name = "ObterCategoria")]
            public ActionResult<Categoria> Get(int id)
            {
                var categoria = _context.Categorias.AsNoTracking()
                    .FirstOrDefault(p => p.CategoriaId == id);

                if (categoria == null)
                {
                    return NotFound();
                }
                return categoria;
            }

            [HttpPost]
            public ActionResult Post([FromBody] Categoria categoria)
            {
                //if(!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}

                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterCategoria",
                    new { id = categoria.CategoriaId }, categoria);
            }

            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] Categoria categoria)
            {
                //if(!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}
                if (id != categoria.CategoriaId)
                {
                    return BadRequest();
                }

                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }

            [HttpDelete("{id}")]
            public ActionResult<Categoria> Delete(int id)
            {
                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
                //var categoria = _context.Categorias.Find(id);

                if (categoria == null)
                {
                    return NotFound();
                }
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
                return categoria;
            }
        }
    }
}
