public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
