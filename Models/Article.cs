namespace Virtualize_bug.Models;

internal class Article
{
    public Guid Id { get; set; }
    public string Culture { get; set; } = "en-US"; 
    public Details Details { get; set; } = null!;                            
}