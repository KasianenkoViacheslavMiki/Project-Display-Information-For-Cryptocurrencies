﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.API.Interface
{
    public interface IPing
    {
        public Task<HttpResponseMessage> Ping();
    }
}
