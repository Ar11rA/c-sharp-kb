using System.Xml.Serialization;

namespace QuoteFetcher.DTO;

public class User
{
    [XmlElement("id")] public int Id { get; set; }
    [XmlElement("first_name")] public string FirstName { get; set; }
    [XmlElement("last_name")] public string LastName { get; set; }
    [XmlElement("email")] public string Email { get; set; }
}
