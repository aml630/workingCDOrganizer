using System.Collections.Generic;
using Artists.Objects;

namespace CDs.Objects
{

  //creates CD class and assigns private variables//
    public class CD
  {
      private static List<CD> _instances = new List<CD> {};
      private int _id;
      private string _title;
      private string _artist;
      private int _year;
      private string _cover;


//CD constructor//

    public CD(string CDtitle, string CDartist, int CDyear, string CDcover)
    {
    _title = CDtitle;
    _artist = CDartist;
    _year = CDyear;
    _cover = CDcover;
    _instances.Add(this);
    _id = _instances.Count;
    }
//Getters//

    public string GetTitle()
    {
      return _title;
    }

    public string GetArtist()
    {
      return _artist;
    }

    public string GetCover()
    {
      return _cover;
    }

    public int GetYear()
    {
      return _year;
    }

    public int GetId()
    {
      return _id;
    }

//methods done on all CDs//

  public static List<CD> GetAllCDs()
      {
        return _instances;
      }

      public static CD Find(int searchId)
      {
      return _instances[searchId-1];
      }
    }
}
