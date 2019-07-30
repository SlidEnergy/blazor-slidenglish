using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlidEnglish.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlidEnglish.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly SlidEnglishContext _context;
        private readonly IMapper _mapper;

        public WordsController(IMapper mapper, SlidEnglishContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shared.Word>>> GetWord()
        {
            var words = await _context.Word.ToListAsync();

            return _mapper.Map<Shared.Word[]>(words);
        }

        // GET: api/Words/5
        [HttpGet("{text}")]
        public async Task<ActionResult<Shared.Word>> GetWord(string text)
        {
            var word = await _context.Word.Where(x=> x.Text == text).FirstOrDefaultAsync();

            if (word == null)
            {
                return NotFound();
            }

            return _mapper.Map<Shared.Word>(word);
        }

        // PUT: api/Words/5
        [HttpPut("{text}")]
        public async Task<IActionResult> PutWord(string text, Shared.Word word)
        {
            if (text != word.Text)
            {
                return BadRequest();
            }

            var newWord = _mapper.Map<Domain.Word>(word);

            _context.Entry(newWord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(text))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Words
        [HttpPost]
        public async Task<ActionResult<Word>> PostWord(Shared.Word word)
        {
            var newWord = new Domain.Word()
            {
                Text = word.Text
            };

            _context.Word.Add(newWord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { text = word.Text}, _mapper.Map<Shared.Word>(newWord));
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Word>> DeleteWord(int id)
        {
            var word = await _context.Word.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _context.Word.Remove(word);
            await _context.SaveChangesAsync();

            return word;
        }

        private bool WordExists(string text)
        {
            return _context.Word.Any(e => e.Text == text);
        }
    }
}
