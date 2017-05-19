using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuCardServices.Models;

namespace MenuCardServices.Services
{
    public interface IMenuOfTheWeekService
    {
        Task<IEnumerable<WeeklyMenu>> GetWeeklyMenusAsync(DateTime date);
    }
}