using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDal
    {
        #region Event methods
        void AddEvent(Event _event);
        void RemoveEvent(int id);
        void UpdateEvent(Event _event);
        List<Event> GetEvents(Predicate<Event> predicate = null);
        Event GetEvent(int id);
        #endregion


        #region Report methods
        void AddReport(Event _event);
        void RemoveReport(int id);
        void UpdateReport(Event _event);
        List<Event> GetReports(Predicate<Event> predicate = null);
        Event GetReport(int id);
        #endregion
    }
}
