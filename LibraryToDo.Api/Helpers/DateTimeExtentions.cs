using System;
namespace LibraryToDo.Helpers
{
	public static class DapperExpperssions
	{
        public static DateTime? NullIfZero(this DateTime when)
        {
            return when == DateTime.MinValue ? (DateTime?)null : when;
        }
    }
}

