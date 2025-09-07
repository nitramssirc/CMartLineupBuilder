using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications
{
    public interface ISpecification; 
    public interface ISpecification<T>:ISpecification
    {
        Expression<Func<T, bool>> Expression { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        bool UseSplitQuery { get; }
    }
}
