using System.Text.Json.Serialization;

namespace bizYeriz.Domain.Entities.AuthEntities;

public class Role : BaseEntity<Guid>
{
    public string Name { get; set; } //"SystemAdmin", "Manager","Customer", 
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}