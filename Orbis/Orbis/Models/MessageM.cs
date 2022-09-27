using System;
using Orbis.extensions;

namespace Orbis.Models
{
    public class MessageM
    {
        public string Mname { get; set; }
        public string Mtext { get; set; }
        public string Mdate { get; set; }

        public string Titre { get { return Mname.PremiereLettreMajuscule(); } }

        public MessageM()
        {
        }
    }
}
