using Inspection.Domain.Event;
using Inspection.Domain.Event.Posting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Inspection.Application.Posting.Posting.Handlers
{
    public interface IPostingHandler<TEntity> where TEntity : IPostingEntity
    {
        string DocumentCode { get; }

        //Task HandleAsync(IPostableDocument document);

        Task HandleAsync(TEntity entity);
    }
}
