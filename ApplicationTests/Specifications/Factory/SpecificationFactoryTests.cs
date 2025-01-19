using Application.Specifications.SlateSpecs;

using Common.Enums;

using Domain.ValueTypes;

using System.Reflection;

namespace Application.Specifications.Factory.Tests
{
    [TestClass()]
    public class SpecificationFactoryTests
    {
        [TestMethod]
        [DynamicData(nameof(GetSpecificationImplementations), DynamicDataSourceType.Method)]
        public void CreateInstance_Should_CreateAnInstanceOfEveryTypeOfSpecification(Type predicateType, object[] args)
        {
            var factory = new SpecificationFactory();
            var method = typeof(SpecificationFactory).GetMethod(nameof(SpecificationFactory.Create));
            var genericMethod = method?.MakeGenericMethod(predicateType);

            object[] methodArgs = [args];
            var predicateInstance = genericMethod?.Invoke(factory, methodArgs);

            Assert.IsNotNull(predicateInstance, $"Failed to create instance of {predicateType.Name}");
        }

        // This method uses reflection to find all types in the assembly that implement IPredicate
        public static IEnumerable<object[]> GetSpecificationImplementations()
        {
            var predicateType = typeof(ISpecification);
            var assembly = Assembly.GetAssembly(predicateType); // Adjust the method to get the correct assembly
            var types = assembly?.GetTypes()
                .Where(t => t.IsAssignableTo(predicateType) && !t.IsAbstract)
                .ToList();

            if (types == null) throw new ArgumentNullException(nameof(types));

            foreach (var predicateImplementationType in types)
            {
                switch (predicateImplementationType.Name)
                {
                    case nameof (GetSlateByIDWithSalaries):
                        yield return new object[] { predicateImplementationType, new object[] { new SlateID(Guid.NewGuid()) } };
                        break;
                    case nameof(GetSlatesByDFSSiteAndSport):
                        yield return new object[] { predicateImplementationType, new object[] { DFSSite.DraftKings, Sport.NFL } };
                        break;
                    case nameof(GetSlateByID):
                        yield return new object[] { predicateImplementationType, new object[] { new SlateID(Guid.NewGuid()) } };
                        break;
                    case nameof(GetSlateByIDWithProjections):
                        yield return new object[] { predicateImplementationType, new object[] { new SlateID(Guid.NewGuid()) } };
                        break;
                    default:
                        throw new ArgumentException($"Test Case Needs to be written for: {predicateImplementationType.Name}");
                }
            }
        }
    }
}