using System;
namespace  LibraryToDo.Models.Settings
{
    /// <summary>
    /// App Settings
    /// </summary>
    public class AppSettings
	{
		/// <summary>
		/// ctor
		/// </summary>
		public AppSettings()
		{
		}
		
		/// <summary>
		/// Secret
		/// </summary>
        public string Secret { get; set; }

    }
}

