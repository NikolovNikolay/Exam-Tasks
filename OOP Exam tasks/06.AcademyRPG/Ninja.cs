using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class Ninja: Character, IFighter, IGatherer
    {
        private int customAttack;
        public Ninja(string name, Point location, int owner):base(name,location,owner)
        {
            this.HitPoints = 1;
            this.customAttack = 0;
        }

        public int AttackPoints
        {
            get { return this.customAttack; }
        }

        public int DefensePoints
        {
            get { return 0; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int maxHP = 0;
            for (int i = 0; i < availableTargets.Count; i++)
			{
			    if(availableTargets[i].HitPoints > maxHP )
                {
                    maxHP = availableTargets[i].HitPoints;
                }
			}

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if(availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0 && availableTargets[i].HitPoints == maxHP )
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if(resource.Type == ResourceType.Lumber)
            {
                this.customAttack += resource.Quantity;
                return true;
            }
            else if(resource.Type == ResourceType.Stone)
            {
                this.customAttack += (2 * resource.Quantity);
                return true;
            }

            return false;
        }
    }
}
