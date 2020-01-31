using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPRGDemo.Models;
using RazorPagesPRGDemo.Repositories;

namespace RazorPagesPRGDemo
{
public class SearchOldModel : PageModel
{
    private readonly IMapRepository _mapRepo;

    public SearchOldModel(IMapRepository mapRepo)
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

    public void OnGet()
    {

    }

    public void OnPost()
    {
        if(SelectedCountry.HasValue || (StartRange.HasValue && EndRange.HasValue))
        {
            HasSearch = true;
            Results = _mapRepo.Search(SelectedCountry, StartRange, EndRange);
        }
    }
}
}