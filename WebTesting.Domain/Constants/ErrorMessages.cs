using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.Domain.Constants;

public static class ErrorMessages
{
    // Email
    public static string EmailIsRequired = "Email is required";
    public static string EmailIsWrong = "Email is wrong";

    // Password
    public static string PasswordIsRequired = "Password is required";
    public static string PasswordIsTooShort = "Password is too short";

    // Id
    public static string IdIsRequired = "Id is required";

    // Tests
    public static string AnswersAreRequired = "Answers are required";
    public static string TestNotFound = "Test not found";
    public static string QuestionDescriptionRequired = "Question description is required";
    public static string QuestionDescriptionTooLong = "Question description too long";
    public static string OptionsAreRequired = "Options are required";
    public static string TestTitleTooShort = "Test title is too short";
    public static string TestTitleTooLong = "Test title is too long";
    public static string DescriptionTitleTooShort = "Test description is too short";
    public static string DescriptionTitleTooLong = "Test description is too long";

    // {Prefix}Name
    public static string PrefixNameIsRequired(string prefix) => $"{prefix}name is required";
    public static string PrefixNameIsTooShort(string prefix) => $"{prefix}name is too short";
    public static string PrefixNameIsTooLong(string prefix) => $"{prefix}name is too long";
}
