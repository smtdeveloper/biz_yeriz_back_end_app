namespace bizYeriz.Domain.Entities.AuthEntities;
public class Permission : BaseEntity<Guid>
{
    public string Name { get; set; } // AddCompany, UpdateFood, DeleteUser, ListByCompanyIdOrder
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}