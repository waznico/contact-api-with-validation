using System;
namespace ContactService.Application
{
    public static class RegexValidationStrings
    {
        public static string Name => @"^[\w-.\s]{1,50}$";
        public static string Message => @"^[^<>%$\\\[\]#';]{1,500}$";
    }
}
