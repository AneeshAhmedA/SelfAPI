using Self.DTO;
using Self.Entity;

namespace Self.Profile
{
    public class conferenceProfile
    {
        public class ConferenceProfile : AutoMapper.Profile
        {
            public ConferenceProfile()
            {
                CreateMap<Conference, conferenceDTO>();
                CreateMap<conferenceDTO, Conference>();
            }
        }
    }
}
