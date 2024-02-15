using AutoMapper;
using Self.DTO;
using Self.Entity;

namespace Self.Profile
{
    public class TrainProfile : AutoMapper.Profile
    {
        public TrainProfile()
        {
            CreateMap<Train, trainDTO>();
            CreateMap<trainDTO, Train>();
        }
    }
}
