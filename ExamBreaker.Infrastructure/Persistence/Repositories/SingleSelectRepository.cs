using ExamBreaker.Application.Common.Interfaces.Persistence;
using ExamBreaker.Domain.Agggregates.SingleSelects;
using ExamBreaker.Domain.Agggregates.SingleSelects.ValueObjects;

namespace ExamBreaker.Infrastructure.Persistence.Repositories;

internal class SingleSelectRepository : ISingleSelectRepository
{
    private readonly ExamBreakerDbContext _context;

    public SingleSelectRepository(ExamBreakerDbContext context)
    {
        _context = context;
    }

    public SingleSelectQuestion? GetById(
        SingleSelectId id)
    {
        return _context.Set<SingleSelectQuestion>()
            .FirstOrDefault(e => e.Id == id);
    }

    public void Add(SingleSelectQuestion singleSelectQuestion)
    {
        _context.Set<SingleSelectQuestion>().Add(singleSelectQuestion);
        _context.SaveChanges();

    }

    public void Delete(SingleSelectQuestion singleSelectQuestion)
    {
        throw new NotImplementedException();
    }


    public SingleSelectQuestion Update()
    {
        throw new NotImplementedException();
    }
}
