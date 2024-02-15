using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Self.Database;
using Self.Entity;

namespace Self.Services
{
    public class ConferenceService : IConferenceService
    {
        private readonly MyContext _context;

        public ConferenceService(MyContext context)
        {
            _context = context;
        }

        public List<Conference> GetAllConferences()
        {
            try
            {
                return _context.Conferences.Include(c => c.User).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving conferences.", ex);
            }
        }

        public Conference GetConferenceById(int id)
        {
            try
            {
                return _context.Conferences.Include(c => c.User).FirstOrDefault(c => c.conferenceID == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the conference with ID {id}.", ex);
            }
        }

        public void CreateConference(Conference conference)
        {
            try
            {
                _context.Conferences.Add(conference);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the conference.", ex);
            }
        }

        public void UpdateConference(Conference conference)
        {
            try
            {
                _context.Conferences.Update(conference);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the conference with ID {conference.conferenceID}.", ex);
            }
        }

        public void DeleteConference(int id)
        {
            try
            {
                var conference = _context.Conferences.FirstOrDefault(c => c.conferenceID == id);
                if (conference != null)
                {
                    _context.Conferences.Remove(conference);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the conference with ID {id}.", ex);
            }
        }
    }
}
