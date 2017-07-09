using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeSeriesApp.Models
{
    public enum TimePeriods {Day, Week, Month, Value }; 
    public class SeriesPoints
    {
        public int Id { get; set; }
        private TimeSeries TimeSeriesRef { get; set; }
        public TimePeriods TimePeriod { get; set; }
        public DateTime time { get; set; }
        public decimal Value { get; set; }
    }
}