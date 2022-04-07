using System;

using Xunit;

namespace RPGCombatKata.Test
{

	public class Iteration5Tests
	{

		[Fact]
		public void CharsCanDamageThingsTest()
		{
			var thing = new Thing( 2000 );
			var attacker = new Character();
			attacker.DealDamageTo( thing, 1 );
			Assert.Equal( 1999, thing.Health );
		}

		[Fact]
		public void CharacterWithHealthIsATargetTest()
		{
			var target = new Character
			{
				Health = 1,
			};
			Assert.True( target.IsTarget );
		}

		[Fact]
		public void ThingWithHealthIsATargetTest()
		{
			var target = new Thing
			{
				Health = 1,
			};
			Assert.True( target.IsTarget );
		}

		[Fact]
		public void ThingsCantBeHealedTest()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void ThingsDontDealDamageTest()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void ThingsDoNotBelongToFactionsTest()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void ThingsAreNeutralTest()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void ThingsReducedToZeroHealthAreDestroyedTest()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void YouMayCreateATreeWith2000HealthTest()
		{
			throw new NotImplementedException();
		}

	}

}