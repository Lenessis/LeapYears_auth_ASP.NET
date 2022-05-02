using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace zad7._4.Models
{
    public class YearUser
    {

        public int Id { get; set; }

        [Display(Name = "Rok")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Range(1899, 2022, ErrorMessage = "Oczekiwany rok powinien być z zakresu {1} - {2}.")]
        public int year { get; set; }

        [Display(Name = "Imię użytkownika")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [StringLength(100, ErrorMessage = "Oczekiwana {0} powinna zawierać do {1}  znaków.")]
        [RegularExpression(@"^[a-z A-Z]*$", ErrorMessage = "{0} powinna zawierać tylko litery!")]
        public string name { get; set; }
        // wyrażenia regularne
        // https://docs.microsoft.com/pl-pl/dotnet/standard/base-types/regular-expression-language-quick-reference
        // https://docs.microsoft.com/pl-pl/dotnet/api/system.componentmodel.dataannotations.regularexpressionattribute?view=net-6.0

        [Display(Name = "Nazwisko użytkownika")]
        [StringLength(100, ErrorMessage = "Oczekiwana {0} powinna zawierać do {1}  znaków.")]
        [RegularExpression(@"^[a-z A-Z]*$", ErrorMessage = "{0} powinna zawierać tylko litery!")]
        public string lastname { get; set; }

        public virtual ICollection<HistoryUser>? history { get; set; }


        public bool ExtraYear()
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            else
                return false;
        }

        public bool Gender()
        {
            //true = female
            //false = male
            string a = name.Substring(name.Length - 1, 1);
            if (a == "a")
                return true;

            else
                return false;
        }

        public HistoryUser AddView(string phrase)
        {
            return new HistoryUser(phrase, Id);
        }

        public HistoryUser AddView(string phrase, object id)
        {
            return new HistoryUser(phrase, Id, id);
        }

    }
}
