using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportPerformerDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Required]
        [Range(18, 70)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Required]
        [XmlElement("NetWorth")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public ImportPerformedSongsDto[] PerformedSongs { get; set; }
    }

    [XmlType("Song")]
    public class ImportPerformedSongsDto
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}
