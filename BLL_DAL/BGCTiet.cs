﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BGCTiet
    {
        public string MaBG { get; internal set; }
        public string MaKH { get; internal set; }
        public string TenKH { get; internal set; }
        public DateTime? NgayLap { get; internal set; }
        public string MaNV { get; internal set; }
        public string TenNV { get; internal set; }
    }
}
