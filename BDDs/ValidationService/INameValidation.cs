using LaYumba.Functional;

namespace BDDs.ValidationService
{
    public interface INameValidation
    {
        Task<Validation<string>> Validate(string name);
    }
}
