using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Locato.Data.Web
{
    [ComplexType]
    public class Phone
    {
        public int CountryCode { get; set; }

        public long NationalNumber { get; set; }

        public string RawInput { get; set; }

        [Required]
        public long E164Format { get; set; }

        public override string ToString()
        {
            return CountryCode.ToString(CultureInfo.InvariantCulture) + NationalNumber;
        }
    }


}