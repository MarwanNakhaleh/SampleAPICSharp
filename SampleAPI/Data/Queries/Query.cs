using SampleAPI.Data.Repositories;
using SampleAPI.Domain;
using SampleAPI.Models;
using System.Collections.Generic;

namespace SampleAPI.Data.Queries
{
    public class Query : BaseQuery
    {
        private readonly BaseRepository _repository;

        public Query(BaseRepository repository)
        {
            _repository = repository;
        }

        public override CourseModel GetCourseInformation()
        {
            return new CourseModel(_repository.GetCourses());
        }
    }
}
