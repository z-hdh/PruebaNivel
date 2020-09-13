using AutoMapper;
using CrossCutting.Extension;

namespace Prueba.Mapping.AutoMapper
{
    public static class MappingManagement
    {
        private static IMapper _mapper;
        public static IMapper GetMappingConfiguration()
        {
            if (_mapper.IsNull())
            {
                var automaperConfig = new MapperConfiguration(x => { x.AddProfiles(new MappingProfile().GetProfiles()); });
                _mapper = automaperConfig.CreateMapper();
            }
            return _mapper;
        }
    }
}
