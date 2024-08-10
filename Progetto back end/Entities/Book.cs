using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Caso_Di_Studio.Entities;

namespace Caso_Di_Studio.Entities
{
    public class Book
    {
      public int Id { get; set; }
      public string Titolo { get; set; }
      public string Anno { get; set; }
      public string Descrizione { get; set; }
      public int CategoryId { get; set; }
      public int AuthorId{ get; set; }
      public int PublishingHId{ get; set; }

      [JsonIgnore]
      public Category? Category { get; set; }
      [JsonIgnore]
      public Author? Author { get; set; }
      [JsonIgnore]
      public  PublishingH? PublishingH { get; set; }

    }
}
