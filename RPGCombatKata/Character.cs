namespace RPGCombatKata
{

	public class Character : ITarget
	{

		public const int MaxHealth = 1000;

		public const double MaxMeleeFighterRange = 2.0;

		public const double MaxRangedFighterRange = 20.0;

		public int TargetMaxHealth => MaxHealth;

		public int Health { get; set; }

		public bool CanBeHealed => Health > 0;

		public bool IsTarget => Health > 0;

		public int Level { get; init; }

		public bool Alive => Health > 0;

		public bool Dead => !Alive;

		public Point Position { get; private set; } = new Point { X = 0.0, Y = 0.0 };

		public CharacterType Type { get; init; } = CharacterType.MeleeFighter;

		public ISet<Faction> Factions { get; } = new HashSet<Faction>();

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

		public int AdjustDamageFrom( Character attacker, int damage )
		{
			if ( Level - attacker.Level >= 5 )
			{
				damage /= 2;
			}
			else if ( attacker.Level - Level >= 5 )
			{
				damage += damage / 2;
			}
			return damage;
		}

		public void DealDamageTo( ITarget defender, int damage ) => defender.ReceiveDamageFrom( this, damage );

		public void ApplyHealingTo( ITarget patient, int health ) => patient.ReceiveHealingFrom( this, health );

		public double DistanceTo( ITarget target ) => target.Position.Subtract( Position ).Length;

		public void Join( params Faction[] factions ) => Join( (IEnumerable<Faction>)factions );

		public void Join( IEnumerable<Faction> factions )
		{
			foreach ( Faction f in factions )
			{
				Factions.Add( f );
			}
		}

		public bool IsAlliesWith( Character character ) => character == this || Factions.Intersect( character.Factions ).Any();

	}

}