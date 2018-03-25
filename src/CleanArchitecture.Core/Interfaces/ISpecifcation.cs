using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DDDGuestbook.Core.Interfaces
{
    public interface ISpecifcation<T>
    {
        Expression<Func<T,bool>> Criteria { get; }
    }
}
