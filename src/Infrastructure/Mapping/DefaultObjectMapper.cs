using AutoMapper;

namespace Tour.Infrastructure
{
    public class DefaultObjectMapper : Tour.Domain.Interfaces.IObjectMapper
    {
        private readonly IMapper _mapper;

        public DefaultObjectMapper(IMapper mapper)
        {
            _mapper = mapper;
        }


        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

    }
}