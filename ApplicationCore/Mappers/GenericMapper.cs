using System;
using System.Collections.Generic;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;

namespace Airlines.ApplicationCore.Mappers
{
    public abstract class GenericMapper<TEntity, TDto> : IMapper<TEntity, TDto>
    {
        public abstract TDto Map(TEntity entity);
        public abstract TEntity Map(TDto dto);

        public virtual IEnumerable<TDto> Map(IEnumerable<TEntity> entityList)
        {
            List<TDto> list = new List<TDto>();
            
            foreach (var entity in entityList)
                list.Add(Map(entity));

            return list.AsReadOnly();
        }

        public virtual IEnumerable<TEntity> Map(IEnumerable<TDto> dtoList)
        {
            List<TEntity> list = new List<TEntity>();
            
            foreach (var dto in dtoList)
                list.Add(Map(dto));

            return list.AsReadOnly();
        }
    }
}