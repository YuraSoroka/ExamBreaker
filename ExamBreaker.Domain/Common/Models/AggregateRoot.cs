namespace ExamBreaker.Domain.Common.Models;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId> 
    where TId : AggregateRootId<TIdType>
{
    public new AggregateRootId<TIdType> Id { get; protected set; }

    protected AggregateRoot(TId id)
    {
        Id = id;
    }


    // need this for suitable constructor in migration
    protected AggregateRoot()
    { }
}
