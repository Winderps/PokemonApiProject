using System.Collections.Generic;
using System.Threading.Tasks;
using Gen2PokemonViewer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Gen2PokemonViewer.Controllers
{
    public class PokemonController : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string q = "")
        {
            
            List<NameAndUrl> results = CachedPokemonList.Pokemon;

            if (!string.IsNullOrEmpty(q))
            {
                results = results.Where(x => x.Name.ToLower().Contains(q)).ToList();
            }
            
            return View(results);
        }
    }
}