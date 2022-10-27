namespace Virtualize_bug.Models;

internal class Details
{
    public int Id { get; set; }
    public Article Article { get; set; } = null!;
    public Guid ArticleId { get; set; }
    public string Title { get; set; } = string.Empty;           // Nazwa artykułu
    public string Content { get; set; } = string.Empty;         // Zawartość artykułu
    public string Description { get; set; } = string.Empty;     // Krótki opis

    public DateTime Created { get; set; } = DateTime.UtcNow;       // Data dodania
    public DateTime Updated { get; set; } = DateTime.UtcNow;       // Data aktualizacji

}