using LaYumba.Functional;

namespace BDDs.ValidationService
{
    public class NameValidation : INameValidation
    {
        private readonly List<string> ValidNames = new()
        {
            "Nikita",
            "Peter",
            "John"
        };

        public Task<Validation<string>> Validate(string name)
            => FindName(name)
                .Map(optionFound => optionFound
                    .Match(
                        None: () => new Validation.Invalid(new List<Error>() { new($"Name {name} not found:(") }),
                        Some: foundName => F.Valid(foundName + " has been found")))
                .Recover(ex => new Validation.Invalid(new List<Error>() { new($"Exception was thrown {ex.Message}") }));

        private Task<Option<string>> FindName(string name)
            => Task.FromResult(ValidNames.Contains(name) 
                ? F.Some(name)
                : F.None);
    }
}
