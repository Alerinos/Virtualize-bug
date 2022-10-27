using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Virtualize_bug.Pages;

[Route("Articles")]
public partial class Articles : ComponentBase
{
    [Inject] IDbContextFactory<Context> DbFactory { get; set; } = null!;

    private async ValueTask<ItemsProviderResult<DTO.Article>> LoadEmployees(ItemsProviderRequest request)
    {
        await Task.Delay(TimeSpan.FromSeconds(1));

        using var context = DbFactory.CreateDbContext();

        var count = await context.Article.AsNoTracking().CountAsync(); // request.CancellationToken
        var numEmployees = Math.Min(request.Count, count - request.StartIndex);

        var dto2 = await context.Article
            .AsNoTracking()
            .Include(x => x.Details)
            .OrderByDescending(x => x.Details.Created)
            .Skip(request.StartIndex)
            .Take(request.Count)
            .ToListAsync(); // request.CancellationToken

        var dto3 = dto2.Select(x => new DTO.Article
        {
            Title = x.Details.Title,
            Description = x.Details.Description,
            Created = x.Details.Created
        }).ToList();

        return new ItemsProviderResult<DTO.Article>(dto3, count);
    }
}
