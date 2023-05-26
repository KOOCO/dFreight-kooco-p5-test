using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Dolphin.Freight.Models
{
    public class GroupIdCmpStn
    {
        public string GroupId { get; set; }
        public string Cmp { get; set; }
        public string Stn { get; set; }

        public GroupIdCmpStn() { }

        public GroupIdCmpStn(string groupId = null, string cmp = null, string stn = null)
        {
            GroupId = groupId;
            Cmp = cmp;
            Stn = stn;
        }

        public override string ToString()
        {
            return $"{GroupId}, {Cmp}, {Stn}";
        }

    }

}
