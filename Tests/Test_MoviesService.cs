using System;
using Lab1.Data;
using Lab1.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests
{
    public class Test_MoviesService
    {
        private ApplicationDbContext _context;
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("In setup");
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            _context = new ApplicationDbContext(options, new OperationalStoreOptionsForTest());

            _context.Movies.Add(new Lab1.Models.Movie { Name = "test film1", Director = "test rendezo1", Rating = 5.5, Description = "asdfsdaf asdfasf asdfsadf" });
            _context.Movies.Add(new Lab1.Models.Movie { Name = "test film2", Director = "test rendezo2", Rating = 9.9, Description = "qwerqwer qwreqwr qwerqwer" });
            _context.SaveChanges();
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("Tear down");

            foreach (var movie in _context.Movies)
            {
                _context.Remove(movie);
            }
            _context.SaveChanges();
        }

        [Test]
        public void TestGetByMinRating()
        {
            var service = new MoviesService(_context);
            Assert.AreEqual(2, service.GetAllAboveRating(5).Count);
            Assert.AreEqual(1, service.GetAllAboveRating(7).Count);
            Assert.AreEqual(2, service.GetAllAboveRating(2).Count);
            Assert.AreEqual(0, service.GetAllAboveRating(10).Count);
        }
    }
}