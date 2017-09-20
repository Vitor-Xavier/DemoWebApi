using System.ComponentModel.DataAnnotations;

namespace DemoWebApi.Models
{
    /// <summary>
    /// Modelo do teste.
    /// </summary>
    public class Teste
    {
        /// <summary>
        /// Identificação única do teste.
        /// </summary>
        [Key]
        public int TesteId { get; set; }

        /// <summary>
        /// Nome do teste.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Identificação da categoria do teste.
        /// </summary>
        public int CategoriaId { get; set; }

        /// <summary>
        /// Categoria do teste.
        /// </summary>
        public virtual Categoria Categoria { get; set; }
    }
}