﻿namespace DEM.Net.Lib
{
	public class ElevationMetrics
	{
		public double MinElevation { get; internal set; }
		public double MaxElevation { get; internal set; }
		public double Distance { get; internal set; }
		public int NumPoints { get; internal set; }
		public double Climb { get; internal set; }
		public double Descent { get; internal set; }

        public override string ToString()
        {
            return $"Min/Max: {MinElevation} / {MaxElevation}, Distance: {Distance} m, Climb/Descent: {Climb} / {Descent}";
        }
    }
}