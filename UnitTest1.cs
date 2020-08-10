using InsuranceClaim.Controllers;
using InsuranceClaim.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceClaimNUnitTestProject
{
    public class Tests
    {
        public List<InsurerDetail> insurerDetail = new List<InsurerDetail>
        {
            new InsurerDetail
            {
                InsurerName = "Bharti Axa",
                InsurerPackageName = "Silver",
                InsuranceAmountLimit = 10000,
                DisbursementDuration = "2 weeks"
            }
        };

        public List<InitiateClaim> initiateClaims = new List<InitiateClaim>
        {
            new InitiateClaim
            {
                PatientName = "Atul",
                Ailment = "Urology",
                TreatmentPackageName = "Package1",
                InsurerName = "Bharti Axa",
                InsuranceAmountLimit = 10000,
                Cost = 3500
            }
        };
        InsuranceClaimController con = new InsuranceClaimController();
        InitiateClaim initiateClaim = new InitiateClaim();
        [SetUp]
        public void Setup()
        {
            var pension = insurerDetail.AsQueryable();
            var mockset = new Mock<InsurerDetail>();
            mockset.As<IQueryable<InsurerDetail>>().Setup(m => m.Provider).Returns(pension.Provider);
            mockset.As<IQueryable<InsurerDetail>>().Setup(m => m.Expression).Returns(pension.Expression);
            mockset.As<IQueryable<InsurerDetail>>().Setup(m => m.ElementType).Returns(pension.ElementType);
            mockset.As<IQueryable<InsurerDetail>>().Setup(m => m.GetEnumerator()).Returns(pension.GetEnumerator());
        }

        [Test]
        public void Test1()
        {
            var result = con.Get();
            var type1 = result;
            var type2 = insurerDetail as List<InsurerDetail>;
            Assert.IsNotNull(type1);
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {

            var result = con.Get();
            var type1 = result;
            var type2 = insurerDetail as List<InsurerDetail>;
            Assert.AreEqual(type1[0].InsurerName, type2[0].InsurerName);

        }

        [Test]
        public void Test3()
        {
            string insurername = insurerDetail[0].InsurerName;
            var result = con.Get(insurername);
            var type1 = result;
            Assert.IsNotNull(insurername);
        }

        [Test]
        public void Test4()
        {
            var result = con.Post(initiateClaim);
            Assert.IsNotNull(result);
        }
    }
}