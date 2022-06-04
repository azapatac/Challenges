using AutoMapper;
using Challenges.Settings.Mapper.Profiles;
using Prism.Ioc;

namespace Challenges.Settings.Mapper
{
    public static class MapperContainer
    {
        public static void Register(IContainerRegistry containerRegistry)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration((config) =>
            {
                config.AddProfile(new ChallengeProfile());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            containerRegistry.RegisterInstance(typeof(IMapper), mapper);
        }
    }
}