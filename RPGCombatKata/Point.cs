namespace RPGCombatKata
{

	public class Point
	{
		public double X { get; set; }
		public double Y { get; set; }
		public Vector Subtract( Point point ) => new Vector
		{
			X = X - point.X,
			Y = Y - point.Y
		};
	}

}
