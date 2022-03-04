using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Priority_Queue;
using Problems.SystemDesign.ParkingLot;
namespace Problems.SystemDesign.ParkingAllocation
{
    public class ParkingSpot
    {
        public int Id { get; set; }

        public Size size { get; set; }
    }

    public interface IParkingSpotCollection
    {
        public SimplePriorityQueue<ParkingSpot> ParkingSpots { get; set; }
        public SimplePriorityQueue<ParkingSpot> ReservedSpots { get; set; }

        ParkingSpot FindParkingSpot();
        public ParkingSpot FindReservedParkingSpot();
    }

    public class ParkingSpotCollection : IParkingSpotCollection
    {
        public readonly Size _size;

        public ParkingSpotCollection(Size size, SimplePriorityQueue<ParkingSpot>  parkingSpots, SimplePriorityQueue<ParkingSpot>  reservedSpots)
        {
            _size = size;
            ParkingSpots = parkingSpots;
            ReservedSpots = reservedSpots;
        }

        public Size Size { get { return _size; } }
        public SimplePriorityQueue<ParkingSpot> ParkingSpots { get; set; }
        public SimplePriorityQueue<ParkingSpot> ReservedSpots { get; set; }

        public ParkingSpot FindParkingSpot()
        {
            ParkingSpot result = null;
            if (ParkingSpots.Any())
                result = ParkingSpots.Dequeue();

            return result;
        }

        public ParkingSpot FindReservedParkingSpot()
        {
            ParkingSpot result = null;
            if (ReservedSpots.Any())
                result = ReservedSpots.Dequeue();

            return result;
        }

        public void RemoveParkingSpot(ParkingSpot spot)
        {
            if (ParkingSpots.Any() && ParkingSpots.Contains(spot))
                ReservedSpots.Remove(spot);
        }

        public void RemoveReservedParkingSpot(ParkingSpot spot)
        {
            if (ReservedSpots.Any() && ReservedSpots.Contains(spot))
                ReservedSpots.Remove(spot);
        }
    }

    public class ParkingEntrance
    {
        public ParkingEntrance(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public ParkingSpotCollection LargeParkingSpots { get; set; }

        public ParkingSpotCollection MediumParkingSpots { get; set; }

        public ParkingSpotCollection SmallParkingSpots { get; set; }

        public ParkingSpotCollection XSmallParkingSpots { get; set; }

        public ParkingSpot FindLargeSpot(bool isReserved)
        {
            return FindSpotInternal(isReserved, LargeParkingSpots);
        }

        public ParkingSpot FindMediumSpot(bool isReserved)
        {
            return FindSpotInternal(isReserved, MediumParkingSpots);
        }

        public ParkingSpot FindSmallSpot(bool isReserved)
        {
            return FindSpotInternal(isReserved, SmallParkingSpots);
        }

        public ParkingSpot FindXSmallSpot(bool isReserved)
        {
            return FindSpotInternal(isReserved, XSmallParkingSpots);
        }

        private ParkingSpot FindSpotInternal(bool isReserved, IParkingSpotCollection parkingSpotCollection)
        {
            ParkingSpot spot = null;
            if (isReserved)
                spot = parkingSpotCollection.FindReservedParkingSpot();
            else
                spot = parkingSpotCollection.FindParkingSpot();

            return spot;
        }
    }

    public class ParkingSpotAllocationServiceResponse
    {
        public bool Success { get { return !(ParkingSpot == null); } }

        public ParkingSpot ParkingSpot { get; set; }
    }

    public class ParkingSpotAllocationService
    {
        public Dictionary<int, ParkingEntrance> Entrances;

        public ParkingSpotAllocationService(Dictionary<int, ParkingEntrance> entrances)
        {
            Entrances = entrances;
        }

        public ParkingSpotAllocationServiceResponse FindParkingSpot(int entranceId, Size size, bool isReserved)
        {
            var result = new ParkingSpotAllocationServiceResponse();

            if (!Entrances.ContainsKey(entranceId))
                throw new ArgumentException($"Invalid entrance {entranceId}");

            ParkingEntrance entrance = Entrances[entranceId];
            ParkingSpot spot;
            switch(size)
            {
                case Size.Large:
                    spot = entrance.FindLargeSpot(isReserved);
                    break;
                case Size.Medium:
                    spot = entrance.FindMediumSpot(isReserved);
                    break;
                case Size.Small:
                    spot = entrance.FindSmallSpot(isReserved);
                    break;
                case Size.XSmall:
                    spot = entrance.FindXSmallSpot(isReserved);
                    break;
                default:
                    throw new ArgumentException($"Invalid size {size}");
            }

            RemoveSpotFromOtherEntrances(spot, entranceId, isReserved);
            result.ParkingSpot = spot;
            return result;
        }

        private void RemoveSpotFromOtherEntrances(ParkingSpot spot, int entranceId, bool isReserved)
        {
            foreach(var k in Entrances.Keys)
            {
                if (k == entranceId)
                    continue;

                switch(spot.size)
                {
                    case Size.Large:
                        RemoveSpotFromEntrance(isReserved, spot, Entrances[k].LargeParkingSpots.ParkingSpots, Entrances[k].LargeParkingSpots.ReservedSpots);
                        break;
                    case Size.Medium:
                        RemoveSpotFromEntrance(isReserved, spot, Entrances[k].MediumParkingSpots.ParkingSpots, Entrances[k].MediumParkingSpots.ReservedSpots);
                        break;
                    case Size.Small:
                        RemoveSpotFromEntrance(isReserved, spot, Entrances[k].SmallParkingSpots.ParkingSpots, Entrances[k].SmallParkingSpots.ReservedSpots);
                        break;
                    case Size.XSmall:
                        RemoveSpotFromEntrance(isReserved, spot, Entrances[k].XSmallParkingSpots.ParkingSpots, Entrances[k].XSmallParkingSpots.ReservedSpots);
                        break;
                    default:
                        throw new ArgumentException($"Invalid size {spot.size}");
                }
            }
        }

        private void RemoveSpotFromEntrance(bool isReserved, ParkingSpot spot, SimplePriorityQueue<ParkingSpot> ParkingSpots, SimplePriorityQueue<ParkingSpot> ReservedSpots)
        {
            if (isReserved)
                RemoveSpot(spot, ReservedSpots);
            else
                RemoveSpot(spot, ParkingSpots);
        }

        private void RemoveSpot(ParkingSpot spot, SimplePriorityQueue<ParkingSpot> spots)
        {
            spots.Remove(spot);
        }
    }
}
