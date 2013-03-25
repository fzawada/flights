namespace Flights.Specifications
{
    internal class AndSpecification<TEntity> : ISpecification<TEntity>
    {
        private ISpecification<TEntity> spec1;
        private ISpecification<TEntity> spec2;

        internal AndSpecification(ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            this.spec1 = spec1;
            this.spec2 = spec2;
        }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return spec1.IsSatisfiedBy(candidate) && spec2.IsSatisfiedBy(candidate);
        }
    }
}