﻿using EcertApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcertApp.EcertApiHelper.Implementations
{
    public interface IHttpLogic<T>
    {
        Task<string> PostCall(T Entity, string url);
        IEnumerable<T> Get(string url);
    }
}