using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.Domain.Constants;

public static class ErrorMessages
{
    // Email
    public const string EmailIsRequired = "Email is required";
    public const string EmailIsWrong = "Email is wrong";

    // Password
    public const string PasswordIsRequired = "Password is required";
    public const string PasswordIsTooShort = "Password is too short";

    // Id
    public const string IdIsRequired = "Id is required";

    // Tests
    public const string AnswersAreRequired = "Answers are required";
    public const string TestNotFound = "Test not found";
    public const string QuestionDescriptionRequired = "Question description is required";
    public const string QuestionDescriptionTooLong = "Question description too long";
    public const string OptionsAreRequired = "Options are required";
    public const string TestTitleTooShort = "Test title is too short";
    public const string TestTitleTooLong = "Test title is too long";
    public const string DescriptionTitleTooShort = "Test description is too short";
    public const string DescriptionTitleTooLong = "Test description is too long";

    // {Prefix}Name
    public static string PrefixNameIsRequired(string prefix) => $"{prefix}name is required";
    public static string PrefixNameIsTooShort(string prefix) => $"{prefix}name is too short";
    public static string PrefixNameIsTooLong(string prefix) => $"{prefix}name is too long";
}
