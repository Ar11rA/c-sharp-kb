using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using QuoteFetcher.DTO;

namespace QuoteFetcher.Services;

public static class CustomReader
{
    public static void ParseXml(string xmlPath, string txtPAth)
    {
        // read all at once
        Assembly assembly = Assembly.GetExecutingAssembly();
        Stream stream = assembly.GetManifestResourceStream(xmlPath)!;
        StreamReader xsr = new(stream);
        string xmlContent = xsr.ReadToEnd();
        XmlSerializer serializer = new(typeof(User));
        MemoryStream memStream = new(Encoding.UTF8.GetBytes(xmlContent));
        if (serializer.Deserialize(memStream) is not User user)
        {
            Console.WriteLine("Could not parse user.");
            return;
        }

        Console.WriteLine($"Parsed XML User key, found {user.FirstName} {user.LastName} with email {user.Email}");

        // read line by line
        int counter = 0;
        using (StreamReader tsr = new(assembly.GetManifestResourceStream(txtPAth)!))
        {
            while (tsr.Peek() >= 0)
            {
                Console.WriteLine(tsr.ReadLine());
                counter++;
            }
        }

        Console.WriteLine("There were {0} lines.", counter);
    }
}
