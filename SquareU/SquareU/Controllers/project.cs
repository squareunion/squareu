public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Default to avoid null
    public string Status { get; set; } = "Not Started"; // Default status
}
