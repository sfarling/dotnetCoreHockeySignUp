using System;
using System.Configuration;

namespace HockeySignUpCore
{
    class DateTimeDay
    {
        //Get the date 2 days future and format it for use in the URI value
        public String GetDate()
        {
            DateTime newDate = DateTime.Now.AddDays(+2);
            String signUpDate = newDate.ToString("yyyy-MM-dd");
            return signUpDate;
        }

        /*
        Actual signup time is 7:00:00:05
        Get the time now
        Get the dif between now and 7:00:00:01 and wait that long before submission
        */
        public void GetTime()
        {
            DateTime requiredTime = DateTime.Today.AddHours(7).AddMinutes(00).AddSeconds(00).AddMilliseconds(01);
            DateTime currentTime = DateTime.Now;
            TimeSpan difference = requiredTime - currentTime;
            int ms = (int)difference.TotalMilliseconds;
            System.Threading.Thread.Sleep(ms);
        }

        //Get the day of week 2 days future 
        public String GetDay()
        {
            DateTime newDate = DateTime.Now.AddDays(+2);
            String signUpDay = newDate.ToString("dddd");
            return signUpDay;
        }

        /*
        Get the ID number to use for the day of the week
        7252 = Thursday | 7281 = Friday AM | 7252 = Tuesday | 7232 = Saturday | 7388 = Friday PM 
        */
        public String GetId(string signUpDay)
        {
            DateTime dt8AM = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 08, 0, 0);
            if
            //Actual day is Sunday + 2 days = Tuesday signup
            (signUpDay == "Tuesday")
                return (ConfigurationManager.AppSettings["Tues"]);

            //Actual day is Tuesday + 2 days = Thursday signup 
            else if (signUpDay == "Thursday" && DateTime.Now < dt8AM)
                return (ConfigurationManager.AppSettings["Thurs"]);

            //Actual day is Tuesday + 2 days = Thursday signup pm 
            else if (signUpDay == "Thursday" && DateTime.Now > dt8AM)
                return (ConfigurationManager.AppSettings["Thurspm"]);

            //Actual day is Wednesday + 2 days = Friday AM signup
            else if (signUpDay == "Friday" && DateTime.Now < dt8AM)
                return (ConfigurationManager.AppSettings["Fri"]);

            //Actual day is Wednesday + 2 days = Friday PM signup
            else if (signUpDay == "Friday" && DateTime.Now > dt8AM)
                return (ConfigurationManager.AppSettings["Fripm"]);

            //Actual day is Thursday + 2 days = Saturday signup
            else if (signUpDay == "Saturday")
                return (ConfigurationManager.AppSettings["Sat"]);

            //Actual day is Saturday + 2 days = Monday signup
            else if (signUpDay == "Monday")
                return (ConfigurationManager.AppSettings["Mon"]);

            else return "Not Found";
        }
    }
}
