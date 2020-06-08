using System;
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
        public async Task<IActionResult> Search([FromQuery] string q = "", [FromQuery] int page = 0, [FromQuery] int perPage = 25)
        {
            
            List<NameAndUrl> results = CachedPokemonList.Pokemon;

            if (!string.IsNullOrEmpty(q))
            {
                results = results.Where(x => x.Name.ToLower().Contains(q)).ToList();
            }

            ViewBag.Page = page;
            ViewBag.PerPage = perPage;
            ViewBag.Pages = (int)Math.Ceiling((double)results.Count / perPage);
            ViewBag.Query = q;

            int startIndex = (page * perPage > results.Count)
                ? (results.Count - perPage - 1)
                : page * perPage;
            int count = (startIndex + perPage > results.Count)
                ? (results.Count - startIndex)
                : perPage;
            
            ViewBag.StartIndex = startIndex;

            return View(results.GetRange(startIndex, count));
        }

     [HttpGet]
        public async Task<IActionResult> PokemonResults([FromQuery] int id = 0)
        {
            Pokemon pokemon = await Utilities.GetApiResponse<Pokemon>(
            "api/v2", "pokemon", "https://pokeapi.co", id.ToString());
            return View(pokemon);
        }
    }
}