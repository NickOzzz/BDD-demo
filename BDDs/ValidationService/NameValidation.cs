using LaYumba.Functional;

namespace BDDs.ValidationService
{
    public static class NameValidation
    {
        public static Validation<string> Validate(this string name) => name == "nikita" ? "OK" : new Validation.Invalid();
    }
}
