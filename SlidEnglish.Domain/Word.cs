using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlidEnglish.Domain
{
    public class Word
	{
		public int Id { get; set; }

        [Required]
		public string Text { get; set; }

        [Required]
        public virtual ICollection<Word> Synonyms { get; set; }

        [Required]
        public string Associations { get; set; } = "";

        [Required]
        public virtual ICollection<UsageExample> UsageExamples { get; set; }
    }
}
