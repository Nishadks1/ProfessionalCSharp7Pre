using MenuCardServices.Models;
using MenuCardServices.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MenuCardServices.ViewModels
{
    public class MainViewModel
    {
        private readonly IMenuOfTheWeekService _menuOfTheWeekService;
        private readonly ObservableCollection<WeeklyMenu> _weeklyMenus;

        public MainViewModel(IMenuOfTheWeekService menuOfTheWeekService)
        {
            _menuOfTheWeekService = menuOfTheWeekService;
        }
        public Task GetWeeklyMenusAsync() 
        {
            return _menuOfTheWeekService.GetWeeklyMenusAsync(DateTime.Today);
        }
        private void FillWeeklyMenus(IEnumerable<WeeklyMenu> weeklyMenus)
        {
            _weeklyMenus.Clear();
            foreach (var menu in weeklyMenus)
            {
                _weeklyMenus.Add(menu);
            }
        }
    }
}
