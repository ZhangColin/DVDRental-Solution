using System.Collections.Generic;
using AutoMapper;
using DVDRenatal.Infrastructure.Extensions;
using DVDRenatal.Infrastructure.IoC;

namespace DVDRenatal.Infrastructure.AutoMapper
{
    public static class AutoMapperConfig {
        public static void Initialize() {
            IEnumerable<Profile> profiles = ServiceLocator.GetServices<Profile>();
            Mapper.Initialize(config => profiles.ForEach(profile => config.AddProfile(profile)));
            Mapper.AssertConfigurationIsValid();
        }
    }
}