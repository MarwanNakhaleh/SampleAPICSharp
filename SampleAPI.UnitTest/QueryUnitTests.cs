using SampleAPI.Data.Queries;
using SampleAPI.Data.Repositories;
using SampleAPI.Models;
using SampleAPI.UnitTest.Mocks;
using System.Linq;
using Xunit;

namespace SampleAPI.UnitTest
{
    public class QueryUnitTests
    {
        private BaseRepository _dataRepository;

        public QueryUnitTests()
        {
            _dataRepository = new MockRepository();
        }

        [Fact]
        public void TestGetCoursesQuery()
        {
            Query queryService = new Query(_dataRepository);
            CourseModel allCourseData = queryService.GetCourseInformation();
            Assert.Equal("Baby's First Course", allCourseData.coursesList.FirstOrDefault(course => course.Title == "Baby's First Course").Title);
        }
    }
}
