using Microsoft.EntityFrameworkCore;

namespace WorkspaceBooking.Api.Data;

public class WorkspaceBookingDbContext : DbContext
{
    public WorkspaceBookingDbContext(DbContextOptions<WorkspaceBookingDbContext> options) : base(options)
    {
    }
}