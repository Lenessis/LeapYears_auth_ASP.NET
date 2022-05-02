using Microsoft.AspNetCore.Identity;

namespace zad7._4.Models
{
    public class HistoryUser
    {

        public int Id { get; set; }
        public DateTime date { get; set; }
        //public int      result  { get; set; } // liczba pozostałych wyników
        public string result { get; set; } // wyszukiwany wynik

        public int YearUserId { get; set; }
        public virtual YearUser YearUser { get; set; }

        public string? UserId { get; set; }

        public HistoryUser()
        {
            date = DateTime.Now;
            // result = 1;
            result = "";
        }

        public HistoryUser(string result, int userId)
        {
            date = DateTime.Now;
            this.result = result;
            YearUserId = userId;
        }

        public HistoryUser(string result, int userId, object userIdentityId)
        {
            date = DateTime.Now;
            this.result = result;
            YearUserId = userId;
            UserId = userIdentityId.ToString();
        }

        public HistoryUser(string result, int userId, YearUser user)
        {
            date = DateTime.Now;
            this.result = result;
            YearUserId = userId;
            YearUser = user;
        }

    }
}
