using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class Giant: Character, IFighter, IGatherer
    {
        private bool helthAlreadyIncreased = false;
        private int customAttack = 150;

        public Giant(string name, Point location, int owner): base(name,location,owner)
        {
            this.HitPoints = 200;
        }
        public int AttackPoints
        {
            get { return this.customAttack; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++ )
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if(resource.Type == ResourceType.Stone)
            {
                if(helthAlreadyIncreased == false)
                {
                    this.customAttack += 100;
                    this.helthAlreadyIncreased = true;

                }

                return true;
            }

            return false;
        }
    }
}
