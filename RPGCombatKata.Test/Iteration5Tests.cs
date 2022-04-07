using System;

using Xunit;

namespace RPGCombatKata.Test
{

	public class Iteration5Tests
	{

		[Fact]
		public void CharsCanDamageThings()
		{
			var thing = new Thing( 2000 );
			var attacker = new Character();
			attacker.DealDamageTo( thing, 1 );
			Assert.Equal( 1999, thing.Health );
		}

		[Fact]
		public void AnythingWithHealthIsATarget()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void ThingsCantBeHealed()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void ThingsDontDealDamage()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void ThingsDoNotBelongToFactions()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void ThingsAreNeutral()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void ThingsReducedToZeroHealthAreDestroyed()
		{
			throw new NotImplementedException();
		}

		[Fact]
		public void YouMayCreateATreeWith2000Health()
		{
			throw new NotImplementedException();
		}

	}

}