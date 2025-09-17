using Microsoft.AspNetCore.Identity;

namespace OnlineShoppingStore.Models;

public class ApplicationUser:IdentityUser
{
    [Required]
    public string FName { get; set; }
    [Required]
    public string LName { get; set; }

    [Required]
    public string Gender { get; set; }
    public DateOnly BirthDate { get; set; }

    public byte[] ProfilePicture { get; set; }
}
