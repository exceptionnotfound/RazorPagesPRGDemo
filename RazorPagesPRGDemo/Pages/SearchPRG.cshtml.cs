using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPRGDemo.Models;
using RazorPagesPRGDemo.Repositories;

namespace RazorPagesPRGDemo
{
public class SearchPRGModel : PageModel
{
    private readonly IMapRepository _mapRepo;

    public SearchPRGModel(IMapRepository mapRepo)
    {
        _mapRepo = mapRepo;
    }

    [BindProperty]
    public Country? SelectedCountry { get; set; }

    [BindProperty]
    public DateTime? StartRange { get; set; }

    [BindProperty]
    public DateTime? EndRange { get; set; }

    public List<Map> Results { get; set; }
    public bool HasSearch { get; set; }

    public void OnGet(Country? country, DateTime? startRange, DateTime? endRange)
    {
        SelectedCountry = country;
        StartRange = startRange;
        EndRange = endRange;

        if(country.HasValue || (startRange.HasValue && endRange.HasValue))
        {
            HasSearch = true;
            Results = _mapRepo.Search(country, startRange, endRange);
        }
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("/SearchPRG", new { country = SelectedCountry, 
                                                startRange = StartRange, 
                                                endRange = EndRange });
    }
}
}