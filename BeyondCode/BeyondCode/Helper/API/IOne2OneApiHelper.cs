using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BeyondCode.Services.Helper
{
    public interface IOne2OneApiHelper
    {
        Task<TReturn> PostAsync<T, TReturn>(T req, string post) where T : class;
    }
}