using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestNinja.Mocking;
using Xunit;

namespace TestNinja.xUnitTests.Mocking
{
    public class InstallerHelperXTests
    {
        [Fact]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            var fileDownloader = new Mock<IFileDownloader>();
            var installHelper = new InstallerHelper(fileDownloader.Object);
            fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = installHelper.DownloadInstaller("customer", "installer");

            result.Should().BeFalse();
        }

        [Fact]
        public void DownloadInstaller_File_Downloaded_Successfully_ReturnTrue()
        {
            {
                var fileDownloader = new Mock<IFileDownloader>();
                var installHelper = new InstallerHelper(fileDownloader.Object);

                var result = installHelper.DownloadInstaller("customer", "installer");

                result.Should().BeTrue();
            }
        }
    }
}
