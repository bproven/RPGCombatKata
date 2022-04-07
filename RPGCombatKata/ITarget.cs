

namespace RPGCombatKata
{

	public interface ITarget
	{

		int TargetMaxHealth => 1000;

		int Health { get; set; }

		bool IsTarget { get; }

		bool CanBeHealed { get; }

		bool CanDealDamage { get; }

		Point Position { get; }

		public double MaxRange => 0.0;

		ISet<Faction> Factions { get; }

		int AdjustDamageFrom( ITarget attacker, int damage );

		bool IsAlliesWith( ITarget character ) => false;

	}

	public static class TargetExtensions
	{

		public static double DistanceTo( this ITarget source, ITarget target ) => target.Position.Subtract( source.Position ).Length;

		public static bool IsInRangeFrom( this ITarget target, ITarget attacker ) => attacker.DistanceTo( target ) <= attacker.MaxRange;

		public static void ReceiveDamageFrom( this ITarget target, ITarget attacker, int damage )
		{

			if ( !attacker.CanDealDamage )
			{
				return;
			}

			if ( !target.IsInRangeFrom( attacker ) )
			{
				return;
			}

			if ( target.IsAlliesWith( attacker ) )
			{
				return;
			}

			damage = target.AdjustDamageFrom( attacker, damage );

			if ( damage > target.Health )
			{

				target.Health = 0;
			}
			else
			{
				target.Health -= damage;
			}

		}

		public static void DealDamageTo( this ITarget attacker, ITarget defender, int damage ) => defender.ReceiveDamageFrom( attacker, damage );


		public static void ReceiveHealingFrom( this ITarget target, Character healer, int health )
		{

			if ( !target.CanBeHealed )
			{
				return;
			}

			if ( !target.IsAlliesWith( healer ) )
			{
				return;
			}

			if ( target.Health + health > target.TargetMaxHealth )
			{
				target.Health = target.TargetMaxHealth;
			}
			else
			{
				target.Health += health;
			}

		}

	}

}
