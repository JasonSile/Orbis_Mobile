using System;
using System.Collections.Generic;
using System.Text;

namespace OrbisXamarin.Models
{
    public class ReliefWebModel
    {
        public int Time { get; set; }
        public string Href { get; set; }
        public Links Links { get; set; }
        public int Took { get; set; }
        public int TotalCount { get; set; }
        public int Count { get; set; }
        public List<Datum> Data { get; set; }
    }

    public class Links
    {
        public HrefModel Self { get; set; }
        public HrefModel Next { get; set; }
    }

    public class HrefModel
    {
        public string Href { get; set; }
    }

    public class Datum
    {
        public string Id { get; set; }
        public int Score { get; set; }
        public Fields Fields { get; set; }
        public string Href { get; set; }
    }

    public class Fields
    {
        public string Title { get; set; }
    }

}
