

namespace RPGCombatKata
{

	public interface ITarget
	{

		int TargetMaxHealth => 1000;

		int Health { get; set; }

		bool IsTarget { get; }

		Point Position { get; }

		int AdjustDamageFrom( Character attacker, int damage ) => damage;

		bool IsAlliesWith( Character character ) => false;

	}

	public static class TargetExtensions
	{

		public static bool IsInRangeFrom( this ITarget target, Character attacker ) => attacker.DistanceTo( target ) <= attacker.MaxRange;

		public static void ReceiveDamageFrom( this ITarget target, Character attacker, int damage )
		{

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

		public static void ReceiveHealingFrom( this ITarget target, Character healer, int health )
		{

			if ( !target.IsAlliesWith( healer ) )
			{
				return;
			}

			if ( target.Health > 0 )
			{
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

}
