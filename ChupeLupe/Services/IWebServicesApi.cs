using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChupeLupe.Models;

namespace ChupeLupe.Services
{

     public interface IWebServicesApi
        {
            Task<List<Promotion>> GetPromotions();
        }
}
