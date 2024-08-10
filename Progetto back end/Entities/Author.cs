using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Caso_Di_Studio.Entities
{
    public class Author
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Cognome {get; set;}
        public string Citta {get; set;}
        public string Indirizzo {get; set;}

        [JsonIgnore]
        public ICollection<Book>? Books { get; set; }
    }
}