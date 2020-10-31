using System;

namespace GuardLibrary
{
    public class SampleUsage
    {
        public SampleUsage(
            string text,
            string filePath,
            int count)
        {
            //Because of generics, auto completion will show the relevant checks for each type
            //Checks can be added by extension methods. Refer to EnsureExtensions.cs

            //Ensure that text is not null or empty,
            Guard.Ensure(text, nameof(text))
                .IsNotNullOrEmpty();

            //Or ensure that text is a GUID,
            Guard.Ensure(text, nameof(text))
                .IsValidGuid();

            //Or you can chain both of above together
            Guard.Ensure(text, nameof(text))
                .IsNotNullOrEmpty()
                .IsValidGuid();

            //Ensure filePath is a valid file path
            Guard.Ensure(filePath, nameof(filePath))
                .IsNotNullOrEmpty()
                .FilePathExist();

            //Ensure that count falls within limit
            Guard.Ensure(count, nameof(count))
                .IsMoreThenZero();

            //Ensure own logic
            Guard.EnsureThisConditionIsMet(() => count > 10 && count < 20)
                .OrThrowException(new ArgumentException(
                    FormattableString.Invariant($"The parameter {nameof(count)} must be within 10 to 20.")));
        }
    }
}