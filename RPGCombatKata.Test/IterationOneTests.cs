using Xunit;

namespace RPGCombatKata.Test
{

	public class IterationOneTests
	{

		[Fact]
		public void AllCharactersWhenCreatedHaveHealth1000Test()
		{
			var character = new Character();
			Assert.Equal( 1000, character.Health );
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
			var character = new Character();
			character.Damage( 1 );
			Assert.Equal( 999, character.Health );
		}

		[Fact]
		public void WhenDamageExceedsHealthZeroTest()
		{
			var character = new Character();
			character.Damage( character.Health + 1 );
			Assert.Equal( 0, character.Health );
		}

		[Fact]
		public void WhenDamageExceedsHealthCharacterDiesTest()
		{
			var character = new Character();
			character.Damage( character.Health + 1 );
			Assert.True( character.Dead );
		}

		[Fact]
		public void DeadCharactersCannotBeHealedTest1()
		{
			var character = new Character( false );
			character.Heal( 1000 );
			Assert.Equal( 0, character.Health );
		}

		[Fact]
		public void DeadCharactersCannotBeHealedTest2()
		{
			var character = new Character( false );
			character.Heal( 1000 );
			Assert.True( character.Dead );
		}

		[Fact]
		public void HealingCannotRaiseHealthAbove1000Test()
		{
			var character = new Character();
			character.Heal( 1 );
			Assert.Equal( 1000, character.Health );
		}

	}

}