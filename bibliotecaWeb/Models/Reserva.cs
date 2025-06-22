namespace BibliotecaMVC.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdLivro { get; set; }
        public int IdUsuario { get; set; }

        public DateTime DataReserva { get; set; } = DateTime.Now;
    }
}
