﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Models;

namespace Training.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<CompanyModel> Companies { get; set; }
    }
}
