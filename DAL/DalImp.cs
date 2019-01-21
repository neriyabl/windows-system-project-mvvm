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
        /// if not found do nothing
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
        /// update the event by find the old one with the id
        /// and replace with the new one
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

        /// <summary>
        /// get the all events or events by conditions asynchronously
        /// </summary>
        /// <param name="predicate">the condition predicat</param>
        /// <returns>list of the relevant events</returns>
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

        /// <summary>
        /// add new report to the table
        /// </summary>
        /// <param name="_event"> the new event </param>
        /// <exception>throw exception if the id already exist</exception>
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

        /// <summary>
        /// remove report by event id
        /// if not found do nothing
        /// </summary>
        /// <param name="id">the report id to remove</param>
        public void RemoveReport(int? id)
        {
            var reportToRemove = GetReport(id);
            if (reportToRemove == null) return;
            using (var db = new ProjectContext())
            {
                db.Reports.Remove(reportToRemove);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// update the report by find the old one with the id
        /// and replace with the new one
        /// </summary>
        /// <param name="_event">the new report to replace</param>
        /// <exception>throw exception if the report id to update not found</exception>
        public void UpdateReport(Report _report)
        {
            if (GetReport(_report.Id) == null)
                throw new Exception("the report to update not found");
            using (var db = new ProjectContext())
            {
                db.Entry(_report);
                db.Reports.AddOrUpdate(_report);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// get the all reports or reports by conditions
        /// </summary>
        /// <param name="predicate">the condition predicat</param>
        /// <returns>list of the relevant reports</returns>
        public List<Report> GetReports(Predicate<Report> predicate = null)
        {
            List<Report> reports;
            using (var db = new ProjectContext())
            {
                reports = (from _report in db.Reports
                           where predicate == null || predicate(_report)
                           select _report).ToList();
            }
            return reports;
        }

        /// <summary>
        /// get the all reports or reports by conditions asynchronously
        /// </summary>
        /// <param name="predicate">the condition predicat</param>
        /// <returns>list of the relevant reports</returns> 
        public async Task<List<Report>> GetReportsAsync(Predicate<Report> predicate = null)
        {
            List<Report> reports;
            using (var db = new ProjectContext())
            {
                reports = await (from _report in db.Reports
                                 where predicate == null || predicate(_report)
                                 select _report).ToListAsync();
            }
            return reports;
        }

        /// <summary>
        /// get report by id
        /// </summary>
        /// <param name="id">the report id</param>
        /// <returns>the report</returns>
        public Report GetReport(int? id)
        {
            Report _report;
            using (var db = new ProjectContext())
            {
                _report = db.Reports.SingleOrDefault(r => r.Id == id);
            }
            return _report;
        }

        #endregion

    }
}
