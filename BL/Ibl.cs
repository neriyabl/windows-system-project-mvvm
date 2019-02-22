﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBl
    {
        #region Event methods
        void AddEvent(Event _event);
        void RemoveEvent(int id);
        void UpdateEvent(Event _event);
        List<Event> GetEvents(Predicate<Event> predicate = null);
        Task<List<Event>> GetEventsAsync(Predicate<Event> predicate = null);
        Event GetEvent(int? id);
        #endregion

        #region Report methods
        Task<Report> AddReport(Report report);
        void RemoveReport(int id);
        void UpdateReport(Report report);
        List<Report> GetReports(Predicate<Report> predicate = null);
        Task<List<Report>> GetReportsAsync(Predicate<Report> predicate = null);
        Report GetReport(int? id);
        #endregion
    }
}
