using Microsoft.Extensions.Logging;
using SampleAPI.Domain;
using System.Collections.Generic;

namespace SampleAPI.Data.Repositories
{
    public sealed class Repository : BaseRepository
    {
		public Repository(ILoggerFactory logger) : base(logger)
        {
			_logger = logger.CreateLogger<Repository>();
        } 
		public override List<Course> GetCourses()
		{
			_logger.LogInformation("returning course information");
			return _courses;
		}
	}
}
