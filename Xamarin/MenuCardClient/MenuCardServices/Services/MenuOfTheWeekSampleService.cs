using MenuCardServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuCardServices.Services
{
    public class MenuOfTheWeekSampleService : IMenuOfTheWeekService
    {
        private DateTime _selectedDate;
        private readonly List<WeeklyMenu> _menus = new List<WeeklyMenu>();
        public MenuOfTheWeekSampleService()
        {
        }

        private void LoadMenus(DateTime date)
        {
            if (date.Date == _selectedDate.Date) return; // menus already loaded, do nothing
            _menus.AddRange(
                Enumerable.Range(0, 14).Select((x, ix) => new WeeklyMenu
                {
                    Id = x + 1,
                    Title = $"sample title {x}",
                    Subtitle = $"sample subtitle {ix % 2 + 1}",
                    Price = 9.8M,
                    ImageUrl = "http://www.x.y",
                    ThumbnaailUrl = "http://www.z"
                }));
            _selectedDate = date;
        }

        public Task<IEnumerable<WeeklyMenu>> GetWeeklyMenusAsync(DateTime date)
        {
            LoadMenus(date);
            return Task.FromResult<IEnumerable<WeeklyMenu>>(_menus);
        }
    }
}
