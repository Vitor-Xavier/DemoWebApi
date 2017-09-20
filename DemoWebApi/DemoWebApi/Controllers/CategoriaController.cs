using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using DemoWebApi.Context;
using DemoWebApi.Models;

namespace DemoWebApi.Controllers
{
    /// <summary>
    /// Controla as requisição de manipulação e consulta de categorias de testes.
    /// </summary>
    public class CategoriaController : ApiController
    {
        private DatabaseContext _context;

        /// <summary>
        /// Inicia conexão com a base de dados.
        /// </summary>
        public CategoriaController()
        {
            _context = new DatabaseContext();
        }

        /// <summary>
        /// Retorna todas as categorias de teste registradas.
        /// </summary>
        /// <returns>Coleção com todas as categorias.</returns>
        [Route("categoria/get")]
        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias;
        }

        /// <summary>
        /// Retorna categoria que possui a identificação informada.
        /// </summary>
        /// <param name="id">Identificação da categoria para busca.</param>
        /// <returns>Categoria correspondente.</returns>
        [Route("categoria/get/{id:int}")]
        public Categoria Get(int id)
        {
            return (from t in _context.Categorias
                   where t.CategoriaId == id
                   select t).FirstOrDefault();
        }

        /// <summary>
        /// Retorna categoria que possui a identificação informada ou 1.
        /// </summary>
        /// <param name="id">Identificação da categoria para busca.</param>
        /// <returns>Categoria correspondente.</returns>
        [Route("categoria/get/default")]
        [Route("categoria/get/default/{id?}")]
        public Categoria GetDefault(int id = 1)
        {
            return (from t in _context.Categorias
                    where t.CategoriaId == id
                    select t).FirstOrDefault();
        }

        /// <summary>
        /// Retorna categoria que possuam a texto informado em sua descricao.
        /// </summary>
        /// <param name="descricao">Texto da descricão para busca.</param>
        /// <returns>Coleção de categorias compatíveis.</returns>
        [Route("categoria/get/desc")]
        [Route("categoria/get/desc/{descricao}")]
        public IEnumerable<Categoria> Get(string descricao = "entity")
        {
            return _context.Categorias.Where(c => c.Descricao.ToLower().Contains(descricao.ToLower()));
        }

        /// <summary>
        /// Adiciona categoria de teste perante dados informados.
        /// </summary>
        /// <param name="categoria">Objeto a ser inserido na base de dados.</param>
        /// <returns>Sucesso da operação.</returns>
        [Route("categoria/post")]
        public IHttpActionResult Post([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            return Created("", _context.SaveChanges());
        }

        /// <summary>
        /// Altera categoria de teste na base de dados.
        /// </summary>
        /// <param name="categoria">Objeto a ser atualizado na base de dados.</param>
        /// <returns>Sucesso da operação.</returns>
        [Route("categoria/post/alter")]
        public IHttpActionResult PostAlter([FromBody] Categoria categoria)
        {
            _context.Categorias.AddOrUpdate(categoria);
            return Created("", _context.SaveChanges());
        }

        /// <summary>
        /// Deleta categoria de teste na base de dados.
        /// </summary>
        /// <param name="categoria">Objeto a ser removido na base de dados.</param>
        /// <returns>Sucesso da operação.</returns>
        [Route("categoria/post/delete")]
        public IHttpActionResult PostDelete([FromBody] Categoria categoria)
        {
            _context.Entry(categoria).State = System.Data.Entity.EntityState.Deleted;
            return Created("", _context.SaveChanges());
        }
    }
}
