using System.Data.SqlTypes;

namespace TesteConexão.Models
{
    public class ClienteModel
    {
        public int? id { get; set; }
        public string nome_completo { get; set; }

        public string email { get; set; }

        public string cpf { get; set; }

        public DateOnly aniversario { get; set; }
    }
}
