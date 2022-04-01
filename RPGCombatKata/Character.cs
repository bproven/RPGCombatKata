
namespace RPGCombatKata
{

	public class Character
	{

		public const int MaxHealth = 1000;

		public const double MaxMeleeFighterRange = 2.0;

		public const double MaxRangedFighterRange = 20.0;

		public int Health { get; private set; }

		public int Level { get; init; }

		public bool Alive => Health > 0;

		public bool Dead => !Alive;

		public Point Position { get; private set; } = new Point { X = 0.0, Y = 0.0 };

		public CharacterType Type { get; init; } = CharacterType.MeleeFighter;

		public double MaxRange => Type switch
		{
			CharacterType.MeleeFighter => MaxMeleeFighterRange,
			CharacterType.RangedFighter => MaxRangedFighterRange,
			_ => 0.0,
		};

		public Character( bool alive = true )
		{
			Health = alive ? MaxHealth : 0;
			Level = 1;
		}

		private void ReceiveDamageFrom( Character attacker, int damage )
		{

			if ( attacker.DistanceTo( this ) > attacker.MaxRange )
			{
				return;
			}

			if ( Level - attacker.Level >= 5 )
			{
				damage /= 2;
			}
			else if ( attacker.Level - Level >= 5 )
			{
				damage += damage / 2;
			}

			if ( attacker == this )
			{
				return;
			}

			if ( damage > Health )
			{

				Health = 0;
			}
			else
			{
				Health -= damage;
			}

		}

		public void DealDamageTo( Character defender, int damage ) => defender.ReceiveDamageFrom( this, damage );

		private void ReceiveHealingFrom( Character healer, int health )
		{
			if ( healer != this )
			{
				return;
			}
			if ( Alive )
			{
				if ( Health + health > MaxHealth )
				{
					Health = MaxHealth;
				}
				else
				{
					Health += health;
				}
			}
		}

		public void ApplyHealingTo( Character patient, int health ) => patient.ReceiveHealingFrom( this, health );

		public double DistanceTo( Character character ) => character.Position.Subtract( Position ).Length;

	}

}