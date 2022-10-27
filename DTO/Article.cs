namespace Virtualize_bug.DTO;

internal class Article
{
    public Guid Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public List<string> Cultures { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Nsfw { get; set; } = false;
    public bool Sponsor { get; set; } = false;
    public bool Logged { get; set; } = false;
    public bool Premium { get; set; } = false;
    public decimal ReadingTime { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;
    public List<string> Tags { get; set; } = new();
    public string ImageHead { get; set; } = string.Empty;
    public List<Article> Articles { get; set; } = null!;
}
