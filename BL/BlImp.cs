using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    internal class BlImp : IBl
    {
        private IDal _dal = new FactoryDal().GetInstance();

        #region Events
        public void AddEvent(Event _event)
        {
            _dal.AddEvent(_event);
        }

        public void RemoveEvent(int id)
        {
            _dal.RemoveEvent(id);
        }

        public void UpdateEvent(Event _event)
        {
            _dal.UpdateEvent(_event);
        }

        public List<Event> GetEvents(Predicate<Event> predicate = null)
        {
            return _dal.GetEvents(predicate);
        }

        public Task<List<Event>> GetEventsAsync(Predicate<Event> predicate = null)
        {
            return _dal.GetEventsAsync(predicate);
        }

        public Event GetEvent(int? id)
        {
            return _dal.GetEvent(id);
        }
        #endregion

        #region Reports
        public void AddReport(Report report)
        {
            List<Event> events = GetEvents()
                .Where(e => e.StartTime <= report.Time.AddMinutes(10) ||
                 e.StartTime.AddMinutes(10) >= report.Time.AddMinutes(-10))
                .ToList();
            if (events.Count == 1)
            {
                //TODO check if need to change the event time
            }
            else if (events.Count > 1)
            {
                //TODO check whitch event contain the report time or which is the closest
            }
            else
            {
                report.Event = new Event {StartTime = report.Time};
            }
            _dal.AddReport(report);
        }

        public void RemoveReport(int id)
        {
            _dal.RemoveReport(id);
        }

        public void UpdateReport(Report report)
        {
            _dal.UpdateReport(report);
        }

        public List<Report> GetReports(Predicate<Report> predicate = null)
        {
            return _dal.GetReports(predicate);
        }

        public Task<List<Report>> GetReportsAsync(Predicate<Report> predicate = null)
        {
            return _dal.GetReportsAsync(predicate);
        }

        public Report GetReport(int? id)
        {
            return _dal.GetReport(id);
        }
        #endregion
    }
}
