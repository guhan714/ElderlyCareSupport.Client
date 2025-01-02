using ElderlyCareSupport.Client.Models;

namespace ElderlyCareSupport.Client.Interfaces;

public interface IFeeService
{
    Task<ApiResponseWrapper<IEnumerable<FeeModel>>> GetFeeDetails();
}