namespace BirthCertificate.Entities;

public class Baby
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? MiddleName { get; set; }
    public string? Nationality { get; set; }
    public string? Gender { get; set; }
    public string? PlaceOfBirth { get; set; }
    public DateTime DateOfBirth { get; set; }
}