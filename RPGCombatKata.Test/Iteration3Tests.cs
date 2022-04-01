
using Xunit;

namespace RPGCombatKata.Test
{

	public class Iteration3Tests
	{

		[Fact]
		public void PointSubtractTest()
		{
			var point1 = new Point
			{
				X = 0.0,
				Y = 1.0,
			};
			var point2 = new Point
			{
				X = 0.0,
				Y = 2.0,
			};
			var vector = point2.Subtract( point1 );
			Assert.Equal( 0.0, vector.X );
			Assert.Equal( 1.0, vector.Y );
		}

		[Fact]
		public void VectorLengthTest1()
		{
			var vector = new Vector
			{
				X = 0.0,
				Y = 1.0,
			};
			Assert.Equal( 1.0, vector.Length );
		}

		[Fact]
		public void VectorLengthTest2()
		{
			var vector = new Vector
			{
				X = -1.0,
				Y = 1.0,
			};
			Assert.Equal( 1.414, vector.Length, 3 );
		}

		[Fact]
		public void CharacterDistanceTest()
		{
			var char1 = new Character
			{
				Position =
				{
					X = 0.0,
					Y = -3.0,
				},
			};
			var char2 = new Character
			{
				Position =
				{
					X = 4.0,
					Y = 0.0,
				},
			};
			Assert.Equal( 5.0, char1.DistanceTo( char2 ), 1 );
		}

		[Fact]
		public void MeleeFighterRangeTest()
		{
			var meleeFighter = new Character
			{
				Type = CharacterType.MeleeFighter,
			};
			Assert.Equal( Character.MaxMeleeFighterRange, meleeFighter.MaxRange );
		}

		[Fact]
		public void RangedFighterRangeTest()
		{
			var rangedFighter = new Character
			{
				Type = CharacterType.RangedFighter,
			};
			Assert.Equal( Character.MaxRangedFighterRange, rangedFighter.MaxRange );
		}

		[Fact]
		public void MeleeFighterDealDamageInRange()
		{
			var attacker = new Character
			{
				Type = CharacterType.MeleeFighter,
				Position =
				{
					X = 0.0,
					Y = 0.0,
				},
			};
			var defender = new Character
			{
				Position =
				{
					X = Character.MaxMeleeFighterRange,
					Y = 0.0,
				},
			};
			attacker.DealDamageTo( defender, 1 );
			Assert.Equal( Character.MaxHealth - 1, defender.Health );
		}

		[Fact]
		public void MeleeFighterDealCantDamageOutOfRange()
		{
			var attacker = new Character
			{
				Type = CharacterType.MeleeFighter,
				Position =
				{
					X = 0.0,
					Y = 0.0,
				},
			};
			var defender = new Character
			{
				Position =
				{
					X = 3.0,
					Y = 0.0,
				},
			};
			attacker.DealDamageTo( defender, 1 );
			Assert.Equal( Character.MaxHealth, defender.Health );
		}

		[Fact]
		public void RangedFighterDealDamageInRange()
		{
			var attacker = new Character
			{
				Type = CharacterType.RangedFighter,
				Position =
				{
					X = 0.0,
					Y = 0.0,
				},
			};
			var defender = new Character
			{
				Position =
				{
					X = Character.MaxRangedFighterRange,
					Y = 0.0,
				},
			};
			attacker.DealDamageTo( defender, 1 );
			Assert.Equal( Character.MaxHealth - 1, defender.Health );
		}

		[Fact]
		public void RangedFighterDealCantDamageOutOfRange()
		{
			var attacker = new Character
			{
				Type = CharacterType.RangedFighter,
				Position =
				{
					X = 0.0,
					Y = 0.0,
				},
			};
			var defender = new Character
			{
				Position =
				{
					X = Character.MaxRangedFighterRange + 1.0,
					Y = 0.0,
				},
			};
			attacker.DealDamageTo( defender, 1 );
			Assert.Equal( Character.MaxHealth, defender.Health );
		}

	}

}
