using System.Linq;

using Xunit;

namespace RPGCombatKata.Test
{

	public class Iteration4Tests
	{

		const Faction alliance = Faction.Alliance;
		const Faction horde = Faction.Horde;
		const Faction fed = Faction.Federation;

		[Fact]
		public void CharactersMayBelongToOneOrMoreFactionsTest1()
		{
			var character = new Character();
			character.Join( alliance );
			Assert.Single( character.Factions );
		}

		[Fact]
		public void CharactersMayBelongToOneOrMoreFactionsTest2()
		{
			var character = new Character();
			character.Join( alliance );
			character.Join( horde );
			Assert.Equal( 2, character.Factions.Count );
		}

		[Fact]
		public void NewCharactersBelongToNoFactionTest()
		{
			var character = new Character();
			Assert.False( character.Factions.Any() );
		}

		[Fact]
		public void CharacterMayJoinOneFactionTest()
		{
			var character = new Character();
			character.Join( horde );
			Assert.Single( character.Factions );

		}

		[Fact]
		public void CharacterMayJoinMoreFactionsTest()
		{
			var character = new Character();
			character.Join( alliance, fed );
			Assert.Equal( 2, character.Factions.Count );
		}

		[Fact]
		public void SelfAllyTest()
		{
			var character = new Character();
			Assert.True( character.IsAlliesWith( character ) );
		}

		[Fact]
		public void AlliesTest()
		{
			var character1 = new Character();
			var character2 = new Character();
			character1.Join( alliance );
			character2.Join( alliance );
			Assert.True( character1.IsAlliesWith( character2 ) );
		}

		[Fact]
		public void NotAlliesTest()
		{
			var character1 = new Character();
			var character2 = new Character();
			character1.Join( alliance );
			character2.Join( horde );
			Assert.False( character1.IsAlliesWith( character2 ) );
		}

		[Fact]
		public void AlliesCantDealDamageTest()
		{
			var attacker = new Character();
			var defender = new Character();
			attacker.Join( alliance );
			defender.Join( alliance );
			attacker.DealDamageTo( defender, 1 );
			Assert.Equal( Character.MaxHealth, defender.Health );
		}

		[Fact]
		public void NonAlliesCanDealDamageTest()
		{
			var attacker = new Character();
			var defender = new Character();
			attacker.Join( alliance );
			defender.Join( horde );
			attacker.DealDamageTo( defender, 1 );
			Assert.Equal( Character.MaxHealth - 1, defender.Health );
		}

		[Fact]
		public void AlliesCanHealTest()
		{
			var attacker = new Character();
			var defender = new Character();
			var healer = new Character();
			attacker.Join( horde );
			defender.Join( alliance );
			healer.Join( alliance );
			attacker.DealDamageTo( defender, 1 );
			healer.ApplyHealingTo( defender, 1 );
			Assert.Equal( Character.MaxHealth, defender.Health );
		}

		[Fact]
		public void NonAlliesCantHealTest()
		{
			var attacker = new Character();
			var defender = new Character();
			var healer = new Character();
			attacker.Join( horde );
			defender.Join( alliance );
			healer.Join( horde );
			attacker.DealDamageTo( defender, 1 );
			healer.ApplyHealingTo( defender, 1 );
			Assert.Equal( Character.MaxHealth - 1, defender.Health );
		}

	}

}
