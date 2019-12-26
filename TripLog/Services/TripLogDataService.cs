﻿namespace TripLog.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models;

    public interface ITripLogDataService
    {
        Task<IList<TripLogEntry>> ReadAllEntriesAsync();
        Task AddEntryAsync(TripLogEntry entry);
    }
}