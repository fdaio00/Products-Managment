using System.Text.RegularExpressions;

namespace Products_Managment.GlobalClasses
{
    public static class clsValidation
    {
        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regx = new Regex(pattern);

            return regx.IsMatch(Number);
        }
        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regx = new Regex(pattern);

            return regx.IsMatch(Number);
        }

        public static bool IsNumber(string Numbeer)
        {
            return (ValidateFloat(Numbeer) || ValidateInteger(Numbeer));

        }

    }
}
