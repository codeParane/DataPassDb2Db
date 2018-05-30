using System.ComponentModel.DataAnnotations;
namespace EFCoreDemo
{ 
    public class Book
    {
        [Key]
        public string Books{get; set;}
        public string Authors{get; set;}
       
    }
}