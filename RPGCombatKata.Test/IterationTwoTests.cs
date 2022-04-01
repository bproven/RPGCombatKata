
using Xunit;

namespace RPGCombatKata.Test
{

	public class IterationTwoTests
	{

		[Fact]
		public void CharacterCannotDamageSelfTest()
		{
			var attacker = new Character();
			var health = attacker.Health;
			attacker.DealDamageTo( attacker, 1000 );
			Assert.Equal( health, attacker.Health );
		}

		[Fact]
		public void CharacterCanOnlyHealSelfTest()
		{
			var healer = new Character();
			var attacker = new Character();
			attacker.DealDamageTo( healer, Character.MaxHealth - 1 );
			healer.ApplyHealingTo( healer, 500 );
			Assert.Equal( 501, healer.Health );
		}

		[Fact]
		public void CharacterCannotHealOthersTest()
		{
			var healer = new Character();
			var attacker = new Character();
			var patient = new Character();
			attacker.DealDamageTo( patient, Character.MaxHealth - 1 );
			healer.ApplyHealingTo( patient, 500 );
			Assert.Equal( 1, patient.Health );
		}

		[Fact]
		public void DamageReducedWhenTargetIsFiveOrMoreLevelsAboveTest()
		{
			var attacker = new Character();
			var defender = new Character
			{
				Level = 6,
			};
			attacker.DealDamageTo( defender, 100 );
			Assert.Equal( Character.MaxHealth - 100 / 2, defender.Health );
		}

		[Fact]
		public void DamageIncreasedWhenTargetIsFiveOrMoreLevelsBelowTest()
		{
			var attacker = new Character()
			{
				Level = 6,
			};
			var defender = new Character();
			attacker.DealDamageTo( defender, 100 );
			Assert.Equal( Character.MaxHealth - 100 - 100 / 2, defender.Health );
		}

	}

}
