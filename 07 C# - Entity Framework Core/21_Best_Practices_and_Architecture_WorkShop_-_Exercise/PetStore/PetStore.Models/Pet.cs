using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using PetStore.Models.Enumeration;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        
        public Gender Gender { get; set; }
        [Range(0,200)]
        public byte Age { get; set; }
        [Required]
        [ForeignKey("Breed")]
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        public bool IsSold { get; set; }
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }
        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

    }
}
