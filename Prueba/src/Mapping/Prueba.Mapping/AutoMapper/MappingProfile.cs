using AutoMapper;
using Prueba.Mapping.AutoMapper.Profiles;
using System.Collections.Generic;

namespace Prueba.Mapping.AutoMapper
{
    class MappingProfile
    {
        private readonly List<Profile> _profiles;
        public List<Profile> GetProfiles()
        {
            return _profiles;
        }

        public MappingProfile()
        {
            _profiles = new List<Profile>();

            _profiles.Add(new ProductProfile());
        }
    }
}
