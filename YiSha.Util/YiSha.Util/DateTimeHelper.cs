using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiSha.Util
{
    public class DateTimeHelper
    {
        #region 毫秒转天时分秒
        /// <summary>
        /// 毫秒转天时分秒
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public static string FormatTime(long ms)
        {
            int ss = 1000;
            int mi = ss * 60;
            int hh = mi * 60;
            int dd = hh * 24;

            long day = ms / dd;
            long hour = (ms - day * dd) / hh;
            long minute = (ms - day * dd - hour * hh) / mi;
            long second = (ms - day * dd - hour * hh - minute * mi) / ss;
            long milliSecond = ms - day * dd - hour * hh - minute * mi - second * ss;

            string sDay = day < 10 ? "0" + day : "" + day; //天
            string sHour = hour < 10 ? "0" + hour : "" + hour;//小时
            string sMinute = minute < 10 ? "0" + minute : "" + minute;//分钟
            string sSecond = second < 10 ? "0" + second : "" + second;//秒
            string sMilliSecond = milliSecond < 10 ? "0" + milliSecond : "" + milliSecond;//毫秒
            sMilliSecond = milliSecond < 100 ? "0" + sMilliSecond : "" + sMilliSecond;

            return string.Format("{0} 天 {1} 小时 {2} 分 {3} 秒", sDay, sHour, sMinute, sSecond);
        }
        #endregion

        #region 获取unix时间戳
        /// <summary>
        /// 获取unix时间戳
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long GetUnixTimeStamp(DateTime dt)
        {
            long unixTime = ((DateTimeOffset)dt).ToUnixTimeMilliseconds();
            return unixTime;
        }
        #endregion

        #region 获取日期天的最小时间
        public static DateTime GetDayMinDate(DateTime dt)
        {
            DateTime min = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
            return min;
        }
        #endregion

        #region 获取日期天的最大时间
        public static DateTime GetDayMaxDate(DateTime dt)
        {
            DateTime max = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            return max;
        }
        #endregion

        #region 获取日期天的最大时间
        public static string FormatDateTime(DateTime? dt)
        {
            if (dt != null)
            {
                if (dt.Value.Year == DateTime.Now.Year)
                {
                    return dt.Value.ToString("MM-dd HH:mm");
                }
                else
                {
                    return dt.Value.ToString("yyyy-MM-dd HH:mm");
                }
            }
            return string.Empty;
        }
        #endregion

        /// <summary>
        /// 获取当前周初日期
        /// </summary>
        /// <returns></returns>
        public static DateTime GetStartWeek(DateTime dt)
        {
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))); //本周周一
            return startWeek;
        }

        /// <summary>
        /// 获取当前周末日期
        /// </summary>
        /// <returns></returns>
        public static DateTime GetEndWeek(DateTime dt)
        {
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))); //本周周一
            DateTime endWeek = startWeek.AddDays(6); //本周周日
            return endWeek;
        }

        /// <summary>
        /// 获取当前月初日期
        /// </summary>
        /// <returns></returns>
        public static DateTime GetStartMonth(DateTime dt)
        {
            DateTime startMonth = dt.AddDays(1 - dt.Day); //本月月初
            return startMonth;
        }

        /// <summary>
        /// 获取当前月的月末日期
        /// </summary>
        /// <returns></returns>
        public static DateTime GetEndMonth(DateTime dt)
        {
            DateTime startMonth = dt.AddDays(1 - dt.Day); //本月月初
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1); //本月月末
            return endMonth;
        }

        /// <summary>
        /// 获取当前月的天数
        /// </summary>
        /// <returns></returns>
        public static int GetDaysInMonth(DateTime dt)
        {
            int days = DateTime.DaysInMonth(dt.Year, dt.Month);
            if (dt.AddDays(1 - dt.Day).Date == DateTime.Now.AddDays(1 - DateTime.Now.Day).Date)
                days = DateTime.Now.Day;
            return days;
        }

        /// <summary>
        /// 获取当前季初日期
        /// </summary>
        /// <returns></returns>
        public static DateTime GetStartQuarter(DateTime dt)
        {
            DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day); //本季度初
            return startQuarter;
        }

        /// <summary>
        /// 获取当前季末日期
        /// </summary>
        /// <returns></returns>
        public static DateTime GetEndQuarter(DateTime dt)
        {
            DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day); //本季度初
            DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1); //本季度末
            return endQuarter;
        }

        /// <summary>
        /// 获取当前年初日期
        /// </summary>
        /// <returns></returns>
        public static DateTime GetStartYear(DateTime dt)
        {
            DateTime startYear = new DateTime(dt.Year, 1, 1); //本年年初
            return startYear;
        }

        /// <summary>
        /// 获取当前年末日期
        /// </summary>
        /// <returns></returns>
        public static DateTime GetEndYear(DateTime dt)
        {
            DateTime endYear = new DateTime(dt.Year, 12, 31); //本年年初
            return endYear;
        }
    }
}
