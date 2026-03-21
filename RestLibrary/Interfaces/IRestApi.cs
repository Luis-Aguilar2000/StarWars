using System;
using System.Collections.Generic;
using System.Text;

namespace RestLibrary.Interfaces
{
    public interface IRestApi
    {
       Task<T> Get<T>(string url, string endpoint = "") where T : class;
    }
}
  