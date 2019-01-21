using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using _8anu.Api.Common;
using _8anu.Api.Data.Repositories;
using _8anu.Api.Data.Repositories.Interfaces;

namespace _8anu.Api.Managers.Tests
{
    [TestClass]
    public class ArticlesManagerTests
    {
        private Mock<IArticlesRepository> _articlesRepositoryMock;
        [TestInitialize]
        public void Init()
        {
            _articlesRepositoryMock = new Mock<IArticlesRepository>();
        }

        [TestMethod]
        public void GetAll_NoParameters_ListWithOne()
        {
            //Arrange
            var articleId = Guid.NewGuid();
            _articlesRepositoryMock.Reset();
            _articlesRepositoryMock.Setup
                    (x => x.GetAll(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Article>
                {
                    GetNewArticleEntity(articleId)
                });

            var articlesManager = new ArticlesManager(_articlesRepositoryMock.Object);

            //Act
            var result = articlesManager.GetAll();
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == articleId);
            Assert.IsTrue(result[0].Description == $"Article descrption with Id {articleId}");
            Assert.IsTrue(result[0].Title == $"Article Title {articleId}");
            Assert.IsTrue(result[0].DatePublished == DateTime.Today.AddDays(-5));
            _articlesRepositoryMock.Verify(x=>x.GetAll(
                It.Is<int>(pageIndex => pageIndex == 0),
                It.Is<int>(pageSize=>pageSize == 50)), Times.Once);
        }

        [TestMethod]
        public void GetAll_PagingParameters_ListWithOne()
        {
            //Arrange
            var articleId = Guid.NewGuid();
            _articlesRepositoryMock.Reset();
            _articlesRepositoryMock.Setup
                    (x => x.GetAll(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Article>
                {
                    GetNewArticleEntity(articleId)
                });

            var articlesManager = new ArticlesManager(_articlesRepositoryMock.Object);

            //Act
            var result = articlesManager.GetAll(2, 25);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            _articlesRepositoryMock.Verify(x => x.GetAll(
                It.Is<int>(pageIndex => pageIndex == 2),
                It.Is<int>(pageSize => pageSize == 25)), Times.Once);
        }

        [TestMethod]
        public void GetRecentArticles_NoParameters_ListWithOne()
        {
            //Arrange
            var articleId = Guid.NewGuid();
            _articlesRepositoryMock.Reset();
            _articlesRepositoryMock.Setup
                    (x => x.GetRecentArticles(
                    It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Article>
                {
                    GetNewArticleEntity(articleId)
                });

            var articlesManager = new ArticlesManager(_articlesRepositoryMock.Object);

            //Act
            var result = articlesManager.GetRecentArticles();
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            _articlesRepositoryMock.Verify(x => x.GetRecentArticles(
                It.Is<DateTime>(d => d == DateTime.Today.AddDays(-5)),
                It.Is<int>(pageIndex => pageIndex == 0),
                It.Is<int>(pageSize => pageSize == 50)), Times.Once);
        }

        [TestMethod]
        public void GetRecentArticles_PagingParameters_ListWithOne()
        {
            //Arrange
            var articleId = Guid.NewGuid();
            _articlesRepositoryMock.Reset();
            _articlesRepositoryMock.Setup
                (x => x.GetRecentArticles(
                    It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Article>
                {
                    GetNewArticleEntity(articleId)
                });

            var articlesManager = new ArticlesManager(_articlesRepositoryMock.Object);

            //Act
            var result = articlesManager.GetRecentArticles(2,25);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            _articlesRepositoryMock.Verify(x => x.GetRecentArticles(
                It.Is<DateTime>(d => d == DateTime.Today.AddDays(-5)),
                It.Is<int>(pageIndex => pageIndex == 2),
                It.Is<int>(pageSize => pageSize == 25)), Times.Once);
        }

        private Article GetNewArticleEntity( Guid id)
        {
            return new Article
            {
                Id = id,
                Description = $"Article descrption with Id {id}",
                Title = $"Article Title {id}",
                DatePublished = DateTime.Today.AddDays(-5)
            };
        }
    }
}
