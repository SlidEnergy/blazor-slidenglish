using System.Collections.Generic;

namespace SlidEnglish.Shared
{
    public class Word
	{
		public int Id { get; set; }

		public string Text { get; set; }

        public int[] SynonymIds { get; set; }
    }
}
