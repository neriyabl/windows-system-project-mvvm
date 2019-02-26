using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public Task<Report> AddReport(Report report)
        {
            //TODO after adding endTime to event replace this disgusting query
            List<Event> events = (from e in GetEvents()
                                  //let endTime = (from r in e.Reports
                                  //              orderby r.Time descending
                                  //              select r.Time).First()
                                 where e.StartTime <= report.Time.AddMinutes(10) &&
                                 e.StartTime.AddMinutes(10) >= report.Time.AddMinutes(-10)
                                  select e).ToList();
            if (events.Count == 1)
            {
                if (report.Time < events[0].StartTime)
                {
                    events[0].StartTime = report.Time;
                    UpdateEvent(events[0]);
                }
                else if (report.Time > events[0].StartTime.AddMinutes(10))
                {
                    //TODO need to add and time to event
                }
                report.Event = events[0];
               // events[0].Reports?.Add(report);
            }
            else if (events.Count > 1)
            {
                //TODO check whitch event contain the report time or which is the closest
            }
            else
            {
                report.Event = new Event { StartTime = report.Time };
            }
            return _dal.AddReport(report);
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
