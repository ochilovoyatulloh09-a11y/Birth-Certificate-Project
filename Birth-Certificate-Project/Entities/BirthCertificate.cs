namespace BirthCertificate.Entities;

public class BirthCertificate
{
    public long Id { get; set; }
    public long BabyId { get; set; }
    public string SerialNumOfBirthCertificate { get; set; }
    public string Nationality { get; set; }
    public DateTime GivenDate { get; set; }
    
}