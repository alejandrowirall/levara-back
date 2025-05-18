using Levara.Domain.Contexts;

namespace Levara.WebApi.Infrastructure.Security;

public class SnapshotUserContext : IUserContext
{
    public SnapshotUserContext()
    {
    }

    public void Initialize(IUserContext userContext)
    {
        Id = userContext.Id;
        IsAdmin = userContext.IsAdmin;
        IsOwner = userContext.IsOwner;
        OwnerId = userContext.OwnerId;
        IsTenant = userContext.IsTenant;
        TenantId = userContext.TenantId;
        IsAuthenticated = userContext.IsAuthenticated;
        Username = userContext.Username;
    }

    public int? Id { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsOwner { get; set; }
    public int? OwnerId { get; set; }
    public bool IsTenant { get; set; }
    public int? TenantId { get; set; }
    public bool IsAuthenticated { get; set; }
    public string? Username { get; set; }

    
}

//public class UserContextSnapshot
//{
//    public int? Id { get; set; }
//    public bool IsAdmin { get; set; }
//    public bool IsOwner { get; set; }
//    public int? OwnerId { get; set; }
//    public bool IsTenant { get; set; }
//    public int? TenantId { get; set; }
//    public bool IsAuthenticated { get; set; }
//    public string? Username { get; set; }
//}
