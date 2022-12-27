using BeyondCode.Core;
using BeyondCode.Models.API.Agent;
using BeyondCode.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeyondCode.Services
{
    public interface IUserService
    {
        Task<List<AgentUser>> GetAgentUserAsync();
        Task<ResponseData<UserViewModel>> GetUserAsync(LoginViewModel loginvm);
    }
}