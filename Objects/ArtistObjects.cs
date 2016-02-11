using System.Collections.Generic;
using CDs.Objects;

namespace Artists.Objects
{
    public class Artist
  {
    private static List<Artist> _instances = new List<Artist> {};
    private static Dictionary<string, Artist> AlbumSearcher = new Dictionary<string, Artist> {};
    private string _name;
    private int _id;
    private List<CD> _CDs;

      public Artist(string artistName)
      {
        _name = artistName;
        _instances.Add(this);
        _id = _instances.Count;
        _CDs = new List<CD>{};
        if (AlbumSearcher.ContainsKey(this.GetName()) == false) {
          AlbumSearcher.Add(this.GetName(), this);
        }
      }

      public string GetName()
       {
         return _name;
       }

       public int GetArtistId()
        {
          return _id;
        }

       public static List<Artist> GetAllArtists()
       {
         return _instances;
       }

       public List<CD> GetAllArtistsCDs()
       {
         List<CD> CDs = CD.GetAllCDs();
         List<CD> results = new List<CD> {};
           foreach (var CD in CDs) {
             if (this.IsArtist(CD)){
               results.Add(CD);
             }
         }
         return results;
       }

       public void AddArtistCD(CD cd)
       {
         _CDs.Add(cd);
       }

       public static Artist Find(string name)
        {
          return AlbumSearcher[name];
        }

         public bool IsArtist(CD CurrentCD)
         {
           string MyName = CurrentCD.GetArtist();
           if (MyName == _name)
           {
             return true;
           } else {
             return false;
           }
         }

    }
}
