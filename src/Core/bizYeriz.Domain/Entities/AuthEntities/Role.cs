namespace bizYeriz.Domain.Entities.AuthEntities;

public class Role : BaseEntity<Guid>
{
    public string Name { get; set; } //"SystemAdmin", "BasicManager", "ProManager","Customer", 
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }   
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}