using SampleAPI.Models;

namespace SampleAPI.Data.Queries
{
    public abstract class BaseQuery
    {
        public abstract CourseModel GetCourseInformation();
    }
}
