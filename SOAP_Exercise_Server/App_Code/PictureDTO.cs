/// <summary>
/// Summary description for Class1
/// </summary>
using System.Runtime.Serialization;



[DataContract]
public class PictureDTO
{
    [DataMember]
    string url;
    [DataMember]
    string width;
    [DataMember]
    string heigth;

    public PictureDTO(string url, string width, string heigth)
    {
        this.url = url;
        this.width = width;
        this.heigth = heigth;
    }

	
}