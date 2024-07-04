namespace PilotoWebAPI.Dtos
{
    public class PilotoDtoUpdate
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int cant_hrs_vuelo { get; set; }
        public int idPais { get; set; }
        public string Email { get; set; }
    }
}
