namespace Application.Specifications.Factory;

internal class SpecificationFactory : ISpecificationFactory
{
    public T Create<T>(params object[] args) where T : class, ISpecification
    {
        return Activator.CreateInstance(typeof(T), args) as T
               ?? throw new InvalidOperationException("Failed to create predicate");
    }
}