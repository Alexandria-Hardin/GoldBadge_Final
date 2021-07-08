using System;
using System.Security.Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Claim;
using System.Collections.Generic;

namespace ClaimTest
{
    [TestClass]
    public class ClaimTest
    {
        [TestMethod]
        public void AddClaimToDirectory_ShouldGetCorrectBoolean()
        {
            Claims newContent = new Claims();
            ClaimRepository repository = new ClaimRepository();
            bool addResult = repository.AddClaimToDirectory(newContent);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetClaims_ShouldReturnCorrectCollection()
        {
            Claims testContent = new Claims(1, ClaimType.car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 27), new DateTime(2018, 4, 28));
            ClaimRepository repo = new ClaimRepository();
            repo.AddClaimToDirectory(testContent);
            Queue<Claims> contents = repo.GetClaims();
            bool directoryHasContent = contents.Contains(testContent);
            Assert.IsTrue(directoryHasContent);
        }
        private Claims _content;
        private ClaimRepository _repo;
        [TestInitialize]
        public void Arrange()
        {
            _content = new Claims(1, ClaimType.car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 27), new DateTime(2018, 4, 28));
            _repo = new ClaimRepository();
            _repo.AddClaimToDirectory(_content);
        }
        [TestMethod]
        public void GetClaimByID_ShouldReturnCorrectClaim()
        {
            Claims searchResult = _repo.GetClaimByID(1);
            Assert.AreEqual(_content.ClaimID, searchResult.ClaimID);
        }
        [TestMethod]
        public void UpdateExistingClaim_ShouldReturnTrue()
        {
            Claims updatedInfo = new Claims(1, ClaimType.car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 27), new DateTime(2018, 4, 28));
            bool updateResult = _repo.UpdateExistingClaim(1, updatedInfo);
            Assert.IsTrue(updateResult);
        }
    }
}
