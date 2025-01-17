namespace App.Endpoints.MVC.HW20.Helper
{
    public static class DaysOfWeek
    {
        public static bool IsEvenDayOfWeek(DayOfWeek day)
        {
            var evenDays = new List<DayOfWeek>
        {
            DayOfWeek.Saturday, 
            DayOfWeek.Monday,   
            DayOfWeek.Wednesday,
            DayOfWeek.Friday    
        };

            return evenDays.Contains(day);
        }
    }
}
