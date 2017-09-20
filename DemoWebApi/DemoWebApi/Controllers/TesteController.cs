using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using DemoWebApi.Context;
using DemoWebApi.Models;

namespace DemoWebApi.Controllers
{
    /// <summary>
    /// Controla as requisição de manipulação e consulta de testes.
    /// </summary>
    [Authorize]
    public class TesteController : ApiController
    {
        private DatabaseContext _context;

        /// <summary>
        /// Inicia conexão com a base de dados.
        /// </summary>
        public TesteController()
        {
            _context = new DatabaseContext();
        }

        /// <summary>
        /// Retorna todos os testes registrados.
        /// </summary>
        /// <returns>Coleção com todas os testes realizados.</returns>
        [Route("teste/get")]
        public IEnumerable<Teste> Get()
        {
            return _context.Testes;
        }

        /// <summary>
        /// Retorna teste com a identificacão informada.
        /// </summary>
        /// <param name="id">Identificação do teste.</param>
        /// <returns>Teste correspondente ao parâmetro.</returns>
        [Route("teste/get/{id:int}")]
        public Teste Get(int id)
        {
            return (from t in _context.Testes
                    where t.TesteId == id
                    select t).FirstOrDefault();
        }

        /// <summary>
        /// Retorna teste que contenham a sequência de caracteres informados por parâmetro.
        /// </summary>
        /// <param name="nome">Texto para busca.</param>
        /// <returns>Coleção de testes.</returns>
        [Route("teste/get/{nome}")]
        public IEnumerable<Teste> Get(string nome)
        {
            return _context.Testes.Where(t => t.Nome.ToLower().Contains(nome.ToLower()));
        }

        /// <summary>
        /// Adiciona teste mediante dados informados.
        /// </summary>
        /// <param name="teste">Dados do teste a ser inserido.</param>
        /// <returns>Sucesso da operação.</returns>
        [Route("teste/post")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult Post([FromBody] Teste teste)
        {
           _context.Testes.Add(teste);
           return Created("", _context.SaveChanges());
        }

        /// <summary>
        /// Atualiza teste na base de dados.
        /// </summary>
        /// <param name="teste">Dados do teste a ser atualizado.</param>
        /// <returns>Sucesso da operação.</returns>
        [Route("teste/post/alter")]
        public IHttpActionResult PostAlter([FromBody] Teste teste)
        {
            _context.Testes.AddOrUpdate(teste);
            return Created("", _context.SaveChanges());
        }

        /// <summary>
        /// Deleta teste na base de dados.
        /// </summary>
        /// <param name="teste">Identificação do teste a ser removido.</param>
        /// <returns>Sucesso da operação.</returns>
        [Route("teste/post/delete")]
        public IHttpActionResult PostDelete([FromBody] Teste teste)
        {
            _context.Entry(teste).State = System.Data.Entity.EntityState.Deleted;
            return Created("", _context.SaveChanges());
        }
    }
}
