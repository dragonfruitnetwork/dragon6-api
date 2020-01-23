using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonFruit.Six.API.Tests
{
    [TestClass]
    public class AccountInfoTests
    {
        [TestMethod]
        public async Task GetSingleUserTests()
        {
            //test user id & platform id lookup (for other platforms)
            await AccountInfo.GetUser(Platforms.PSN, LookupMethod.UserId, "a5e7c9c4-a225-4d8e-810f-0c529d829a34", TestData.Token);
            await AccountInfo.GetUser(Platforms.PSN, LookupMethod.PlatformId, "7729747787525340203", TestData.Token);

            //test username lookup
            await AccountInfo.GetUser(Platforms.PC, LookupMethod.Name, "Frost_Bites_", TestData.Token);

            //test user id lookup
            await AccountInfo.GetUser(Platforms.PC, LookupMethod.UserId, "14c01250-ef26-4a32-92ba-e04aa557d619", TestData.Token);
        }

        [TestMethod]
        public async Task GetMultipleUsersTest()
        {
            //a list of PC identifiers for testing bulk queries
            var accountIds = new[]
            {
                "14c01250-ef26-4a32-92ba-e04aa557d619",
                "00515703-cc25-4fe1-ac64-0c271a6edab1",
                "21d95808-d692-4bf3-b825-f5ad3396d079",
                "e76672be-1269-4afd-a1f5-d2ec6f5a2c7f",
                "216c88f6-72ac-43c3-a3bc-a2115aab1e13"
            };

            var userInfo = await AccountInfo.GetUser(Platforms.PC, LookupMethod.UserId, accountIds, TestData.Token);

            Assert.AreEqual(accountIds.Length, userInfo.Count());
        }
    }
}