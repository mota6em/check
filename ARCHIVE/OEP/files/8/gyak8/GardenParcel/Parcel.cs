using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace GardenParcel
{
    public class Parcel
    {
        private int plantingTime;
        public Plant? content { get; private set; }

        public class AlreadyPlantedException : Exception { }

        public void Plant(Plant pla)
        {
            if (content == null)
            {
                content = pla;
                plantingTime = DateTime.Now.Month;
            }
            else
            {
                throw new AlreadyPlantedException();
            }
        }
        public bool HasRipened(int month)
        {
            return content != null && content.IsVegetable() && month - plantingTime == content.RipeningTime;
        }
        public void Harvest()
        {
            content = null;
        }
    }
}
