using Microsoft.EntityFrameworkCore;
using SOTAM.Models;
using SOTAM.Services;
using Xunit;

public class QueueManagementServiceTests
{
    private readonly QueueManagementService _service;
    private readonly SotamContext _context;

    public QueueManagementServiceTests()
    {
        // Set up an in-memory database
        var options = new DbContextOptionsBuilder<SotamContext>()
            .UseInMemoryDatabase("TestDB")
            .Options;

        _context = new SotamContext(options);
        _service = new QueueManagementService(_context);

        SeedData();
    }

    // Seed test data
    private void SeedData()
    {
        _context.Tables.Add(new Table { TableId = 1, Status = "Available" });
        _context.Tables.Add(new Table { TableId = 2, Status = "Occupied" });
        _context.QueueLists.Add(new QueueList { QueueId = 1, Customer = "John Doe", Hours = 2 });
        _context.SaveChanges();
    }

    [Fact]
    public void AddToQueue_ShouldAddCustomerToQueue()
    {
        var result = _service.AddToQueue("Jane Smith", 3);

        Assert.NotNull(result);
        Assert.Equal("Jane Smith", result.Customer);
        Assert.Equal(3, result.Hours);
    }

    [Fact]
    public void AssignTable_ShouldAssignAvailableTable()
    {
        var result = _service.AssignTable(1, 1);

        Assert.NotNull(result);
        Assert.Equal(1, result.TableId);

        var table = _context.Tables.FirstOrDefault(t => t.TableId == 1);
        Assert.Equal("Occupied", table?.Status);
    }

    [Fact]
    public void ConfirmSession_ShouldRemoveQueueEntry()
    {
        _service.ConfirmSession(1);

        var queue = _context.QueueLists.FirstOrDefault(q => q.QueueId == 1);
        Assert.Null(queue);
    }

    [Fact]
    public void CancelQueueEntry_ShouldRemoveQueueEntry()
    {
        _service.CancelQueueEntry(1);

        var queue = _context.QueueLists.FirstOrDefault(q => q.QueueId == 1);
        Assert.Null(queue);
    }
}
