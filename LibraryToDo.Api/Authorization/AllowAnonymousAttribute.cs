using System;

namespace LibraryToDo.Authorization
{

    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    { }

}