using SampleAPI.Domain;
using System.Collections.Generic;

namespace SampleAPI.Data.Repositories
{
    public abstract class BaseRepository
    {
        public List<Course> _courses { get; }

        public BaseRepository()
        {
            _courses = new List<Course>();
        }

        public abstract List<Course> GetCourses();
    }
}
