using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeSeriesApp.Models
{
    public class TimeSeries
    {
        public TimeSeries()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryNode category; 
        public DateTime LastUpdateTime { get; set; }
        public List<SeriesPoints> Points { get; set; }

    }
}