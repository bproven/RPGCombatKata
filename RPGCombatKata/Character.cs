namespace RPGCombatKata
{

	public class Character
	{

		public const int MaxHealth = 1000;

		public int Health { get; private set; }

		public int Level { get; set; }

		public bool Alive => Health > 0;

		public bool Dead => !Alive;

		public Character( bool alive = true )
		{
			Health = alive ? MaxHealth : 0;
			Level = 1;
		}

		private void ReceiveDamageFrom( Character attacker, int damage )
		{
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

	}

}