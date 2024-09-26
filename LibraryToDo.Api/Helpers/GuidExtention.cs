using System;
namespace LibraryToDo.Helpers
{
	public static class GuidExtention
	{
        public static bool IsGuid(string value)
        {
            Guid x;
            return Guid.TryParse(value, out x);
        }
    }
}

