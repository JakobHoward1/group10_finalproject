using Group10_FinalProject.API.Models;
namespace Group10_FinalProject.API.Services;
public interface ICustomerService
{
    Task<List<Customer>> GetReviewsAsync();
    Task<Customer> AddReviewAsync(string name, string review, int rating);

    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task<Customer> AddAsync(Customer customer);
    Task<Customer> UpdateAsync(Customer customer);
    Task DeleteAsync(Guid id);
}
