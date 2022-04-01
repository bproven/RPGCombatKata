using Xunit;

namespace RPGCombatKata.Test
{

	public class Iteration1Tests
	{

		[Fact]
		public void AllCharactersWhenCreatedHaveHealth1000Test()
		{
			var character = new Character();
			Assert.Equal( Character.MaxHealth, character.Health );
		}

		[Fact]
		public void AllCharactersWhenCreatedHaveLevel1Test()
		{
			var character = new Character();
			Assert.Equal( 1, character.Level );
		}

		[Fact]
		public void AllCharactersWhenCreatedAliveTest()
		{
			var character = new Character( true );
			Assert.True( character.Alive );
			Assert.False( character.Dead );
		}

		[Fact]
		public void AllCharactersWhenCreatedDeadTest()
		{
			var character = new Character( false );
			Assert.False( character.Alive );
			Assert.True( character.Dead );
		}

		[Fact]
		public void DamageSubtractedFromHealthTest()
		{
			var defender = new Character();
			var attacker = new Character();
			attacker.DealDamageTo( defender, 1 );
			Assert.Equal( 999, defender.Health );
		}

		[Fact]
		public void WhenDamageExceedsHealthZeroTest()
		{
			var defender = new Character();
			var attacker = new Character();
			attacker.DealDamageTo( defender, defender.Health + 1 );
			Assert.Equal( 0, defender.Health );
		}

		[Fact]
		public void WhenDamageExceedsHealthCharacterDiesTest()
		{
			var defender = new Character();
			var attacker = new Character();
			attacker.DealDamageTo( defender, defender.Health + 1 );
			Assert.True( defender.Dead );
		}

		[Fact]
		public void DeadCharactersCannotBeHealedTest1()
		{
			var patient = new Character( false );
			var healer = new Character( true );
			healer.ApplyHealingTo( patient, Character.MaxHealth );
			Assert.Equal( 0, patient.Health );
		}

		[Fact]
		public void DeadCharactersCannotBeHealedTest2()
		{
			var patient = new Character( false );
			var healer = new Character( true );
			healer.ApplyHealingTo( patient, Character.MaxHealth );
			Assert.True( patient.Dead );
		}

		[Fact]
		public void HealingCannotRaiseHealthAbove1000Test()
		{
			var patient = new Character();
			var healer = new Character();
			healer.ApplyHealingTo( patient, 1 );
			Assert.Equal( Character.MaxHealth, patient.Health );
		}

	}

}