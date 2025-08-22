using Group10_FinalProject.API.Data;
using Group10_FinalProject.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Group10_FinalProject.API.Services;
public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetReviewsAsync()
    {
        return await _context.Customers
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task<Customer> AddReviewAsync(string name, string review, int rating)
    {
        var customer = Customer.Create(name, review, rating);
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
    public async Task<List<Customer>> GetAllAsync()
        => await _context.Customers.ToListAsync();

    public async Task<Customer?> GetByIdAsync(Guid id)
        => await _context.Customers.FindAsync(id);

    public async Task<Customer> AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
