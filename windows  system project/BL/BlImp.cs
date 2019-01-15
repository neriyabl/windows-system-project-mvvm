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
        #region Events
        public void AddEvent(Event _event)
        {
            new FactoryDal().GetInstance().AddEvent(_event);
        }

        public void RemoveEvent(int id)
        {
            new FactoryDal().GetInstance().RemoveEvent(id);
        }

        public void UpdateEvent(Event _event)
        {
            new FactoryDal().GetInstance().UpdateEvent(_event);
        }

        public List<Event> GetEvents(Predicate<Event> predicate = null)
        {
            return new FactoryDal().GetInstance().GetEvents(predicate);
        }

        public Task<List<Event>> GetEventsAsync(Predicate<Event> predicate = null)
        {
            return new FactoryDal().GetInstance().GetEventsAsync(predicate);
        }

        public Event GetEvent(int? id)
        {
            return new FactoryDal().GetInstance().GetEvent(id);
        }
        #endregion

        #region Reports
        public void AddReport(Report report)
        {
            new FactoryDal().GetInstance().AddReport(report);
        }

        public void RemoveReport(int id)
        {
            new FactoryDal().GetInstance().RemoveReport(id);
        }

        public void UpdateReport(Report report)
        {
            new FactoryDal().GetInstance().UpdateReport(report);
        }

        public List<Report> GetReports(Predicate<Report> predicate = null)
        {
            return new FactoryDal().GetInstance().GetReports(predicate);
        }

        public Task<List<Report>> GetReportsAsync(Predicate<Report> predicate = null)
        {
            return new FactoryDal().GetInstance().GetReportsAsync(predicate);
        }

        public Report GetReport(int? id)
        {
            return new FactoryDal().GetInstance().GetReport(id);
        }
        #endregion
    }
}
