using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNinja.Mocking;
using Xunit;

namespace TestNinja.xUnitTests.Mocking
{
    public class VedeoServiceXTests
    {
        [Fact]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var service = new VideoService(fileReader.Object);
            var result = service.ReadVideoTitle();

            result.Should().Contain("Error");
        }

        [Fact]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAllObjectsFromListAsString()
        {
            const string expectedResult = "";
            var videos = new List<Video>();

            var repository = new Mock<IVideoRepository>();
            var service = new VideoService(null, repository.Object);
            repository.Setup(r => r.GetUnprocessedVideos())
                .Returns(videos);

            var result = service.GetUnprocessedVideosAsCsv();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void GetUnprocessedVideosAsCsv_AddVideoIdToListFromDb_ReturnAllObjectsFromListAsString()
        {
            const string expectedResult = "1,2,3";
            var videos = new List<Video>
            {
            new Video { Id = 1 },
            new Video { Id = 2 },
            new Video { Id = 3 },
        };
            var repository = new Mock<IVideoRepository>();
            var service = new VideoService(null, repository.Object);
            repository.Setup(r => r.GetUnprocessedVideos())
                .Returns(videos);

            var result = service.GetUnprocessedVideosAsCsv();

            result.Should().Be(expectedResult);
        }
    }
}
