using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class Rock: StaticObject, IResource
    {
        public Rock(Point location, int owner, int hitpoints) : base(location, owner)
        {
            this.HitPoints = hitpoints;
        }

        public int Quantity
        {
            get { return this.HitPoints / 2; }
        }

        public ResourceType Type
        {
            get { return ResourceType.Stone; }
        }
    }
}
