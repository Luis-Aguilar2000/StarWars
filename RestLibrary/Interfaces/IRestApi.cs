using System;
using System.Collections.Generic;
using System.Text;

namespace RestLibrary.Interfaces
{
    public interface IRestApi
    {
        public Task Get(string url, string endpoint = "");
    }
}
  