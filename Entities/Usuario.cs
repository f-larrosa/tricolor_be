namespace Tricolor_BE.Entities
{
    public class Usuario
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public Usuario() { }

        public Usuario(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public Usuario(string email, string password, string nombre, string apellido)
        {
            this.Email = email;
            this.Password = password;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }
    }
}
