using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal class DalImp : IDal
    {

        #region Event methods
        /// <summary>
        /// add new event to the table
        /// </summary>
        /// <param name="_event"> the new event </param>
        /// <exception>throw exception if the id already exist</exception>
        public void AddEvent(Event _event)
        {
            if (_event.Id != null && GetEvent(_event.Id) != null)
            {
                throw new Exception("the event already exist");
            }
            using (var db = new ProjectContext())
            {
                db.Events.Add(_event);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// remove event by event id
        /// if not fount do nuthing
        /// </summary>
        /// <param name="id">the event id to remove</param>
        public void RemoveEvent(int id)
        {
            var eventToRemove = GetEvent(id);
            if (eventToRemove == null) return;
            using (var db = new ProjectContext())
            {
                db.Events.Remove(eventToRemove);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// update the event by find the old one whith the id
        /// and replace whith the new one
        /// </summary>
        /// <param name="_event">the new event to replace</param>
        /// <exception>throw exception if the event id to update not found</exception>
        public void UpdateEvent(Event _event)
        {
            if (GetEvent(_event.Id) == null)
                throw new Exception("the event to update not found");
            using (var db = new ProjectContext())
            {
                db.Entry(_event);
                db.Events.AddOrUpdate(_event);
                db.SaveChanges();
            }

        }

        /// <summary>
        /// get the all events or events by conditions
        /// </summary>
        /// <param name="predicate">the condition predicat</param>
        /// <returns>list of the relevant events</returns>
        public List<Event> GetEvents(Predicate<Event> predicate = null)
        {
            List<Event> events;
            using (var db = new ProjectContext())
            {
                events = (from _event in db.Events
                          where predicate == null || predicate(_event)
                          select _event).ToList();
            }
            return events;
        }

        public async Task<List<Event>> GetEventsAsync(Predicate<Event> predicate = null)
        {
            List<Event> events;
            using (var db = new ProjectContext())
            {
                events = await (from _event in db.Events
                                where predicate == null || predicate(_event)
                                select _event).ToListAsync();
            }
            return events;
        }

        /// <summary>
        /// get event by id
        /// </summary>
        /// <param name="id">the event id</param>
        /// <returns>the event</returns>
        public Event GetEvent(int? id)
        {
            Event _event;
            using (var db = new ProjectContext())
            {
                _event = db.Events.SingleOrDefault(e => e.Id == id);
            }
            return _event;
        }
        #endregion

        #region Report methods
        public void AddReport(Report report)
        {
            if (report.Id != null && GetReport(report.Id) != null)
            {
                throw new Exception("the report already exist");
            }
            using (var db = new ProjectContext())
            {
                db.Reports.Add(report);
                db.SaveChanges();
            }
        }

        public void RemoveReport(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateReport(Report report)
        {
            throw new NotImplementedException();
        }

        public List<Report> GetReports(Predicate<Report> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<Report>> GetReportsAsync(Predicate<Report> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Report GetReport(int? id)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
