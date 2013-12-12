using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class CustomizedEngine : Engine
    {
        public override void ExecuteCreateObjectCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "knight":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Knight(name, position, owner));
                        break;
                    }
                case "house":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        int owner = int.Parse(commandWords[3]);
                        this.AddObject(new House(position, owner));
                        break;
                    }
                case "giant":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Giant(name, position, 0));
                        break;
                    }
                case "rock":
                    {
                        int hitPoints = int.Parse(commandWords[2]);
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Rock(position, 0, hitPoints));
                        break;
                    }
                case "ninja":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Ninja(name, position, owner));
                        break;
                    }                    
            }
            base.ExecuteCreateObjectCommand(commandWords);
        }

        public override void ExecuteControllableCommand(string[] commandWords)
        {
            string controllableName = commandWords[0];
            IControllable current = null;

            for (int i = 0; i < this.controllables.Count; i++)
            {
                if (controllableName == this.controllables[i].Name)
                {
                    current = this.controllables[i];
                }
            }

            if (current != null)
            {
                switch (commandWords[1])
                {
                    case "go":
                        {
                            HandleCustomGoCommand(commandWords, current);
                            break;
                        }
                    case "attack":
                        {
                            HandleCustomAttackCommand(current);
                            break;
                        }
                    case "gather":
                        {
                            HandleCustomGatherCommand(current);
                            break;
                        }
                }
            }
            
        }

        private void HandleCustomGatherCommand(IControllable current)
        {
            var currentAsGatherer = current as IGatherer;
            if (currentAsGatherer != null)
            {
                //List<WorldObject> objectsAtGathererPosition = new List<WorldObject>();
                IResource resource = null;
                foreach (var obj in this.resources)
                {
                    if (obj.Position == current.Position)
                    {
                        resource = obj;
                        break;
                    }
                }

                if (resource != null)
                {
                    HandleCustomGathering(currentAsGatherer, resource);
                }
                else
                {
                    Console.WriteLine("No resource to gather at {0}'s position", current);
                }
            }
            else
            {
                Console.WriteLine("{0} can't do that", current);
            }
        }

        private void HandleCustomGathering(IGatherer gatherer, IResource resource)
        {
            bool gatheringSuccess = gatherer.TryGather(resource);
            if (gatheringSuccess)
            {
                Console.WriteLine("{0} gathered {1} {2} from {3}", gatherer, resource.Quantity, resource.Type, resource);
                resource.HitPoints = 0;
            }


        }

        private void HandleCustomAttackCommand(IControllable current)
        {
            var currentAsFighter = current as IFighter;
            if (currentAsFighter != null)
            {
                List<WorldObject> availableTargets = new List<WorldObject>();
                foreach (var obj in this.allObjects)
                {
                    if (obj.Position == current.Position)
                    {
                        availableTargets.Add(obj);
                    }
                }

                int targetIndex = currentAsFighter.GetTargetIndex(availableTargets);
                if (targetIndex != -1)
                {
                    this.HandleCustomBattle(currentAsFighter, availableTargets[targetIndex]);
                }
                else
                {
                    Console.WriteLine("No targets to attack at {0}'s position", current);
                }
            }
            else
            {
                Console.WriteLine("{0} can't do that", current);
            }
        }

        private void HandleCustomBattle(IFighter attacker, WorldObject defender)
        {
            if(defender is Ninja)
            {
                defender.HitPoints = defender.HitPoints;

                Console.WriteLine("{0} attacked {1} and did 0 damage", attacker, defender);
            }
            else
            {
                var defenderAsFighter = defender as IFighter;
                int defenderDefensePoints = 0;
                if (defenderAsFighter != null)
                {
                    defenderDefensePoints = defenderAsFighter.DefensePoints;
                }

                int damage = attacker.AttackPoints - defenderDefensePoints;

                if (damage < 0)
                {
                    damage = 0;
                }

                if (damage > defender.HitPoints)
                {
                    damage = defender.HitPoints;
                }

                defender.HitPoints -= damage;

                Console.WriteLine("{0} attacked {1} and did {2} damage", attacker, defender, damage);
            }
        }

        private void HandleCustomGoCommand(string[] commandWords, IControllable current)
        {
            var currentAsMoving = current as MovingObject;
            currentAsMoving.GoTo(Point.Parse(commandWords[2]));
            Console.WriteLine("{0} is now at position {1}", current, current.Position);
        }
    }
}
