namespace RPGCombatKata
{
	public class Vector
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Length => Math.Sqrt( X * X + Y * Y );
	}
}
