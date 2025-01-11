namespace Application.Specifications.Factory;

public interface ISpecificationFactory
{
    T Create<T>(params object[] args) where T : class, ISpecification;
}