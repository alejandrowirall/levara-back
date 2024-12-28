
using Levara.Domain.Enum;
using Levara.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Maintenances.GetByGrid;

public class GetMaintenanceByGridQueryResponse
{
    public GetMaintenanceByGridQueryResponse(Maintenance maintenance)
    {
        Id = maintenance.Id;
        Title = maintenance.Title;
        Description = maintenance.Description;
        TypeId = maintenance.TypeId;
        Type= maintenance.Type;
        Status = maintenance.Status;
        DueDate=maintenance.DueDate;
        PropertyId = maintenance.PropertyId;
        Property=maintenance.Property;  
    }
    public int Id { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }

    public int TypeId { get; set; }
    public MaintenanceType Type { get; set; }

    public MaintenanceStatus Status { get; set; }

    public DateTime DueDate { get; set; }

    public int PropertyId { get; set; }

    public Property Property { get; set; }
}