using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InteliTroco.Core;
using System.Collections.Generic;

namespace InteliTroco.Test.InteliTroco.Core.Test {
	[TestClass]
	public class InteliTrocoManagerTest {
		[TestMethod]
		public void CountCoinsTest() {

			InteliTrocoManager manager = new InteliTrocoManager();

			Dictionary<int, long> actual = manager.CountCoins(37);

			Assert.IsNotNull(actual);
			Assert.AreEqual(3, actual.Count);
			Assert.AreEqual(1, actual[25]);
			Assert.AreEqual(1, actual[10]);
			Assert.AreEqual(2, actual[1]);
		}

		[TestMethod]
		public void CountCoinsZeroAmountTest() {

			InteliTrocoManager manager = new InteliTrocoManager();

			Dictionary<int, long> actual = manager.CountCoins(0);

			Assert.IsNotNull(actual);
			Assert.AreEqual(0, actual.Count);
		}

		[TestMethod]
		public void CountCoinsNegativeAmountTest() {
			InteliTrocoManager manager = new InteliTrocoManager();

			Dictionary<int, long> actual = manager.CountCoins(-27);

			Assert.IsNotNull(actual);
			Assert.AreEqual(0, actual.Count);
		}
	}
}
