namespace RPGCombatKata
{

	public class Character
	{

		public int Health { get; private set; }

		public int Level { get; private set; }

		public bool Alive => Health > 0;

		public bool Dead => !Alive;

		public Character( bool alive = true )
		{
			Health = alive ? 1000 : 0;
			Level = 1;
		}

		public void Damage( int damage )
		{
			if ( damage > Health )
			{
				Health = 0;
			}
			else
			{
				Health -= damage;
			}
		}

		public void Heal( int health )
		{
			if ( Alive )
			{
				if ( Health + health > 1000 )
				{
					Health = 1000;
				}
				else
				{
					Health += health;
				}
			}
		}

	}

}