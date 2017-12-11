using MBDVC.WAPISecurity.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MBDVC.WAPISecurity.IServices
{
    public interface IProductsService
    {
        IList<Product> Get();

        Product Get(int id);
    }
}
