using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenParcel
{
    public class Garden
    {
        private readonly List<Parcel> parcels;

        public Parcel this[int index]
        {
            get
            {
                if (index >= 0 && parcels.Count <= index)
                {
                    return parcels.ElementAt(index);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public Garden(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            parcels = new List<Parcel>();
            for (int i = 0; i < size; i++)
            {
                parcels.Add(new Parcel());
            }
        }

        public void Plant(int where, Plant what)
        {
            if (where < 0 || where >= parcels.Count)
            {
                throw new IndexOutOfRangeException();
            }
            parcels[where].Plant(what);
        }

        public void Harvest(int where)
        {
            if (where < 0 || where >= parcels.Count)
            {
                throw new IndexOutOfRangeException();
            }
            this[where].Harvest();
        }

        public List<int> CanHarvest(int month)
        {
            List<int> canBeHarvested = new List<int>();
            for (int i = 0; i < parcels.Count; i++)
            {
                if (parcels.ElementAt(i).HasRipened(month) == true)
                {
                    canBeHarvested.Add(i);
                }
            }
            return canBeHarvested;
        } 
    }
}
