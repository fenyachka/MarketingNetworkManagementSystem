﻿using Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Distributors
{
    public class DistributorParams : PagingParams
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
