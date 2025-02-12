﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballDomain.Shared
{
    public class ServiceResponse<T> : ServiceResponse
    {
        public T? Data { get; set; }
    }

    public class ServiceResponse
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
    }
}
