using SampleAPI.Domain;
using System.Collections.Generic;

namespace SampleAPI.Data.Repositories
{
    public class Repository : BaseRepository
    {
		public override List<Course> GetCourses()
		{
			return _courses;
		}
	}
}
