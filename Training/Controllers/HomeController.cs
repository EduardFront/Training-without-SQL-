using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Training.Models;
using Training.ViewModels;

namespace Training.Controllers
{
    
    public class HomeController : Controller
    {
        List<Phone> phones;

        List<Company> companies;
        public HomeController()
        {
            Company apple = new Company { Id = 1, Name = "Apple", Country = "США" };
            Company microsoft = new Company { Id = 2, Name = "Samsung", Country = "Республика Корея" };
            Company google = new Company { Id = 3, Name = "Google", Country = "США" };
            companies = new List<Company> { apple, microsoft, google };

            phones = new List<Phone>
            {
                new Phone { Id=1, Maker= apple, Name="iPhone X", Price=56000 },
                new Phone { Id=2, Maker= apple, Name="iPhone XZ", Price=41000 },
                new Phone { Id=3, Maker= microsoft, Name="Galaxy 9", Price=9000 },
                new Phone { Id=4, Maker= microsoft, Name="Galaxy 10", Price=40000 },
                new Phone { Id=5, Maker= google, Name="Pixel 2", Price=30000 },
                new Phone { Id=6, Maker= google, Name="Pixel XL", Price=50000 }
            };
        }
        public IActionResult Index(int? companyId)
        {
            // формируем список компаний для передачи в представление
            List<CompanyModel> compModels = companies
                .Select(c => new CompanyModel { Id = c.Id, Name = c.Name })
                .ToList();
            // добавляем на первое место
            compModels.Insert(0, new CompanyModel { Id = 0, Name = "Все" });

            IndexViewModel ivm = new IndexViewModel { Companies = compModels, Phones = phones };

            // если передан id компании, фильтруем список
            if (companyId != null && companyId > 0)
                ivm.Phones = phones.Where(p => p.Maker.Id == companyId);

            return View(ivm);
        }
    }

}
