using System.ComponentModel.DataAnnotations;

namespace SlidEnglish.Domain
{
    public class Word
	{
		public int Id { get; set; }

        [Required]
		public string Text { get; set; }
	}
}
