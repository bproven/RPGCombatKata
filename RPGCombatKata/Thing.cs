namespace RPGCombatKata
{

	public class Thing : ITarget
	{

		public const int MaxHealth = 2000;

		public int TargetMaxHealth => MaxHealth;

		public int Health { get; set; }

		public Point Position { get; private set; } = new Point { X = 0.0, Y = 0.0 };

		public Thing( int health = MaxHealth )
		{
			Health = health;
		}

	}

}
