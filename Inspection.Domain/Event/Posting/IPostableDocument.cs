using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Event.Posting
{
    public interface IPostableDocument
    {
        long Id { get; }
        DateTime PostingDate { get; }
        string DocumentCode { get; }
        bool Posting { get; }
    }
}
