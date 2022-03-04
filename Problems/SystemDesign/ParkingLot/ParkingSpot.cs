using System;

namespace Problems.SystemDesign.ParkingLot
{
    public enum Size 
    {
        Large = 1,
        Medium = 2,
        Small = 3,
        XSmall = 4,
    }

    interface IReserved
    {
        public bool Reserved { get; set; }
    }

    public abstract class ParkingSpot
    {
        public ParkingSpot()
        {
        }

        public int Id { get; set; }
    }

    public class LargeParkingSpot: ParkingSpot, IReserved
    {
        public readonly Size Size;

        public LargeParkingSpot()
        {
            Size = Size.Large;
        }

        public bool Reserved { get; set; }
    }

    public class SmallParkingSpot: ParkingSpot, IReserved
    {
        public readonly Size Size;

        public SmallParkingSpot()
        {
            Size = Size.Small;

        }
        public bool Reserved { get; set; }
    }

    public class MediumParkingSpot: ParkingSpot, IReserved
    {
        public readonly Size Size;

        public MediumParkingSpot()
        {
            Size = Size.Medium;

        }
        public bool Reserved { get; set; }
    }

    public class XSmallParkingSpot : ParkingSpot, IReserved
    {
        public readonly Size Size;

        public XSmallParkingSpot()
        {
            Size = Size.XSmall;

        }
        public bool Reserved { get; set; }
    }
}
