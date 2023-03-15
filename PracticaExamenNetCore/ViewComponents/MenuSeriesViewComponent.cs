using Microsoft.AspNetCore.Mvc;
using PracticaExamenNetCore.Models;
using PracticaExamenNetCore.Repositories;

namespace PracticaExamenNetCore.ViewComponents
{
    public class MenuSeriesViewComponent: ViewComponent
    {
        private RepositorySeriesPersonajes repo;

        public MenuSeriesViewComponent(RepositorySeriesPersonajes repo)
        {
            this.repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Serie> series = this.repo.GetSeries();
            return View(series);
        }
    }
}
