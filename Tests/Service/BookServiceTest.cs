using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Service
{
    [Collection("BookService")]
    public class BookServiceTest
    {
        public BookServiceTest() { }

        [Fact]
        public void ShouldAddBook()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(true);
         
        }
    }
}
