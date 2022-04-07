
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
		public void ThingsCantBeHealedTest1()
		{
			var target = new Thing( 1 );
			Assert.False( target.CanBeHealed );
		}

		[Fact]
		public void ThingsCantBeHealedTest2()
		{
			var target = new Thing( 1 );
			var healer = new Character();
			healer.ApplyHealingTo( target, 1 );
			Assert.Equal( 1, target.Health );
		}

		[Fact]
		public void ThingsDontDealDamageTest()
		{
			var attacker = new Thing();
			var defender = new Character
			{
				Health = 2,
			};
			attacker.DealDamageTo( defender, 1 );
			Assert.Equal( 2, defender.Health );
		}

		[Fact]
		public void ThingsDoNotBelongToFactionsTest()
		{
			var thing = new Thing();
			Assert.Empty( thing.Factions );
		}

		[Fact]
		public void ThingsAreNeutralTest()
		{
			var thing = new Thing();
			Assert.True( thing.IsNeutral );
		}

		[Fact]
		public void ThingsReducedToZeroHealthAreDestroyedTest()
		{
			var target = new Thing( health: 1 );
			var attacker = new Character();
			attacker.DealDamageTo( target, 1 );
			Assert.True( target.IsDestroyed );
		}

		[Fact]
		public void YouMayCreateATreeWith2000HealthTest1()
		{
			var thing = new Thing( health: 2000 )
			{
				Name = "Tree",
			};
			Assert.Equal( "Tree", thing.Name );
		}

		[Fact]
		public void YouMayCreateATreeWith2000HealthTest2()
		{
			var thing = new Thing( health: 2000 )
			{
				Name = "Tree",
			};
			Assert.Equal( 2000, thing.Health );
		}

	}

}