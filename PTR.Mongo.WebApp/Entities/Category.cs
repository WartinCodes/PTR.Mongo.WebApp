using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PTR.Mongo.WebApp.Entities;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public int UserId { get; set; }
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}