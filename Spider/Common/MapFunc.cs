using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Spider.Common
{
    class MapFunc
    {
        /// <summary>
        /// 经纬度之间的距离
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static double CalcDistance(double lngBeg,double latBeg,double lngEnd,double latEnd)
        {
            double rad = 6371; //Earth radius in Km
            double p1X = lngBeg / 180 * Math.PI;
            double p1Y = latBeg / 180 * Math.PI;
            double p2X = lngEnd / 180 * Math.PI;
            double p2Y = latEnd / 180 * Math.PI;
            return Math.Acos(Math.Sin(p1Y) * Math.Sin(p2Y) +
                Math.Cos(p1Y) * Math.Cos(p2Y) * Math.Cos(p2X - p1X)) * rad;
        }

    }
}
