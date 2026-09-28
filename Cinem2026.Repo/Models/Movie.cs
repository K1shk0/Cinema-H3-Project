namespace Cinema2026.Repo.Models;

public class Movie
{
    public int movieId { get; set; } // variable / property
    public string name { get; set; }
    public decimal rating { get; set; }
    public string genre { get; set; }
    public string description { get; set; }
    public int requiredAge { get; set; }
    public int duration { get; set; } 
    public string cover { get; set; }
}