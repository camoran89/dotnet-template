using cd_plantilla_backend.Interfaces;

namespace cd_plantilla_backend.Models
{
    public class ConnectionStrings : IConnectionStrings
    {
        public string Collection { get; set; } = String.Empty;
        public string Database { get; set; } = String.Empty;
        public string Server { get; set; } = String.Empty;
    }
}
