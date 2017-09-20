using System.ComponentModel.DataAnnotations;

namespace DemoWebApi.Models
{
    /// <summary>
    /// Categoria de teste.
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Identificação única de uma categoria.
        /// </summary>
        [Key]
        public int CategoriaId { get; set; }

        /// <summary>
        /// Descrição pertinente a categoria.
        /// </summary>
        public string Descricao { get; set; }
    }
}