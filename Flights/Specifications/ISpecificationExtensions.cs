namespace Flights.Specifications
{
    public static class ExtensionMethods
    {
        public static ISpecification<TEntity> And<TEntity>(
            this ISpecification<TEntity> s1,
            ISpecification<TEntity> s2)
        {
            return new AndSpecification<TEntity>(s1, s2);
        }
    }
}
