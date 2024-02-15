using System;
using System.Collections.Generic;
using Self.Entity;

namespace Self.Services
{
    public interface IConferenceService
    {
        List<Conference> GetAllConferences();
        Conference GetConferenceById(int id);
        void CreateConference(Conference conference);
        void UpdateConference(Conference conference);
        void DeleteConference(int id);
    }
}
