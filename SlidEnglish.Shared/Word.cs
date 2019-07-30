using System.Collections.Generic;

namespace SlidEnglish.Shared
{
    public class Word
	{
        public int Id { get; set; }

		public string Text { get; set; }

        public string[] Synonyms { get; set; }

        public string Associations { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
