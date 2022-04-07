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

		public bool CanDealDamage => Health > 0;

		public bool IsNeutral => !Factions.Any();

		public string Name => "Character";

		public int Level { get; init; }

		public bool Alive => Health > 0;

		public bool Dead => !Alive;

		public Point Position { get; private set; } = new Point { X = 0.0, Y = 0.0 };

		public CharacterType Type { get; init; } = CharacterType.MeleeFighter;

		private readonly HashSet<Faction> _factions = new HashSet<Faction>();

		public IReadOnlySet<Faction> Factions => _factions;

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

		public int AdjustDamageFrom( ITarget attacker, int damage )
		{
			if ( attacker is Character characterAttacker )
			{
				if ( Level - characterAttacker.Level >= 5 )
				{
					damage /= 2;
				}
				else if ( characterAttacker.Level - Level >= 5 )
				{
					damage += damage / 2;
				}
			}
			return damage;
		}

		public void ApplyHealingTo( ITarget patient, int health ) => patient.ReceiveHealingFrom( this, health );

		public double DistanceTo( ITarget target ) => target.Position.Subtract( Position ).Length;

		public void Join( params Faction[] factions ) => Join( (IEnumerable<Faction>)factions );

		public void Join( IEnumerable<Faction> factions )
		{
			foreach ( Faction f in factions )
			{
				_factions.Add( f );
			}
		}

		public bool IsAlliesWith( ITarget character ) => character == this || Factions.Intersect( character.Factions ).Any();

	}

}