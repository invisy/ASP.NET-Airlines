using System.Collections.Generic;

namespace Airlines.ApplicationCore.Interfaces
{
    public interface IMapper<TSource, TDestination>
    {
        public TDestination Map(TSource entity);
        public TSource Map(TDestination dto);
        public IEnumerable<TDestination> Map(IEnumerable<TSource> entityList);
        public IEnumerable<TSource> Map(IEnumerable<TDestination> dtoList);
    }
}