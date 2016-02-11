
using Nancy;
using CDs.Objects;
using Artists.Objects;
using System.Collections.Generic;

namespace Project
{
  public class HomeModule : NancyModule
  {
    public HomeModule()

    {
      Get["/"] = _ => {
        var allCDs = CD.GetAllCDs();
        return View["index.cshtml", allCDs];
      };
// view the mainpage, taking all the CDs as model
    Get["/cd/new"] = _ => {
    return View["addCD.cshtml"];
    };
//if you get CD/new, take to add CD form//
    Post["/cdAdded"] = _ => {
     var newCD = new CD(Request.Form["cd-title"], Request.Form["cd-artist"], Request.Form["cd-year"], Request.Form["cd-cover"]);
     var newArtist = new Artist(Request.Form["cd-artist"]);
     newArtist.AddArtistCD(newCD);
     return View["cdAdded.cshtml", newCD];
   };

   Get["/searchbyartist"] = _ => {
     return View["searchByArtist.cshtml"];
   };

   Post["/searchresults"] = _ => {
    var selectedArtist = Artist.Find(Request.Form["artist-name"]);
    List<CD> resultCDs = selectedArtist.GetAllArtistsCDs();
    return View["searchResults.cshtml", resultCDs];
  };
    }
  }
}
