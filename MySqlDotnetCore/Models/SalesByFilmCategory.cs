﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MySqlDotnetCore.Models
{
    public partial class SalesByFilmCategory
    {
        public string Category { get; set; }
        public decimal? TotalSales { get; set; }
    }
}
