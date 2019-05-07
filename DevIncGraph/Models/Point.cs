﻿namespace DevIncGraph.Models
{
    public class Point
    {
        public int PointId { get; set; }
        public int ChartId { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }

        public UserData UserData { get; set; }
    }
}
