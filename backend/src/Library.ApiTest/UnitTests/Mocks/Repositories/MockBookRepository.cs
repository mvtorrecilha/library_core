﻿using Library.Core.Interfaces.Repositories;
using Moq;
using System;
using System.Threading.Tasks;

namespace Library.ApiTest.UnitTests.Mocks.Repositories
{
    public class MockBookRepository : Mock<IBookRepository>
    {
        public MockBookRepository() : base(MockBehavior.Strict) { }

        public MockBookRepository MockIsValidBookAsync(Guid id, string studentEmail, bool output)
        {
            Setup(s => s.IsValidBookAsync(id, studentEmail)).ReturnsAsync(output);

            return this;
        }

        public MockBookRepository MockBorrowBookAsync(Guid id, string studentEmail)
        {
            Setup(s => s.BorrowBookAsync(id, studentEmail)).Returns(Task.CompletedTask);

            return this;
        }

        public MockBookRepository VerifyIsValidBookAsync(Guid id, string studentEmail, Times times)
        {
            Verify(s => s.IsValidBookAsync(id, studentEmail), times);

            return this;
        }

        public MockBookRepository VerifyBorrowBookAsync(Guid id, string studentEmail, Times times)
        {
            Verify(s => s.BorrowBookAsync(id, studentEmail), times);

            return this;
        }
    }
}
