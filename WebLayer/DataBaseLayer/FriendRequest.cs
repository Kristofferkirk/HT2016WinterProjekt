//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class FriendRequest
    {
        public int FRId { get; set; }
        public int FutureFriendID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
    }
}