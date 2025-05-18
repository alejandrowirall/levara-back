using Levara.Domain.Models;
using Levara.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds;

public class LeaseSeed : SeedBase
{
    protected override void Execute()
    {
        var userHasher = new PasswordHasher<ApplicationUser>();

        DateTime datatimeApp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        List<Lease> leasesToAdd = new List<Lease>();
        for (int i = 1; i < 11; i++)
        {
            leasesToAdd.Add(new Lease
            {
                Id = i,
                OwnerId = i,
                TenantId = i,
                PropertyId = i,
                DateFrom = new DateTime(2024, 1, i, 0, 0, 0, DateTimeKind.Utc),
                DateTo = new DateTime(2024, 12, i, 0, 0, 0, DateTimeKind.Utc),
                Frequency = FrequencyType.Monthly,
                Amount = 1000 + 100 * i,
                StatusLease = LeaseStatus.UploadDocumentation,
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            });
        }

        this.modelBuilder.Entity<Lease>().HasData(leasesToAdd);
    }
}
