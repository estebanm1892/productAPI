public class Wishlist
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; } // Propiedad de navegación, pero no debería inicializarse en el constructor
    public int UserId { get; set; }
    public User? User { get; set; } // Propiedad de navegación, pero no debería inicializarse en el constructor
}
