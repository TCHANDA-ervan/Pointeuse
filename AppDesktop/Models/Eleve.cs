﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AppDesktop.Models
{
    public class Eleve
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }

        


        // [ForeignKey("Promotion")]
        public int IdPromotion { get; set; }
        

        //[ForeignKey("Groupe")]
        public int IdGroupe { get; set; }
        



       
    }
}
