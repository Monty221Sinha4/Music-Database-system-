//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicWorld.com
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrackList
    {
        public int ID { get; set; }
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public string Track { get; set; }
        public int GenreID { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Artists Artist { get; set; }
        public virtual Genres Genre { get; set; }
    }
}
