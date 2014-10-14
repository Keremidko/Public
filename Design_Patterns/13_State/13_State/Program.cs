using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_State
{
    //В компютърна игра, героя може да има различни състояния
    //в зависимост от състоянието си, функциите които може да изпълнява са различни
    //със изпълнение на функция - се сменя състоянието

    class Program
    {

        abstract class CharacterState
        {
            public virtual void Move(Character character) { }
            public virtual void Attack(Character character) { }
            public virtual void Sleep(Character character) { }
            public virtual void WakeUp(Character character) { }
        }

        class MovingState : CharacterState {
            public override void Move(Character character)
            {
                Console.WriteLine(character.Name + " is moving forward!");
            }
            public override void Attack(Character character)
            {
                Console.WriteLine(character.Name + " started attacking!");
                character.State = new AttacikngState();
            }
            public override void Sleep(Character character)
            {
                Console.WriteLine(character.Name + " has fallen asleep!");
                character.State = new SleepingState();
            }
            public override void WakeUp(Character character)
            {
                Console.WriteLine("Your character is in moving state, so this has no effect!");
            }
        }

        class AttacikngState : CharacterState
        {
            public override void Move(Character character)
            {
                character.State = new MovingState();
                Console.WriteLine(character.Name + "slowly starts to move while attacking!");
            }
            public override void Attack(Character character)
            {
 	             Console.WriteLine(character.Name + " IS ATTACKING FUCKING FURIOUSLY!");
            }
            public override void Sleep(Character character)
            {
                Console.WriteLine("YOU CRAZY! YOU FIGHTIN RIGHT NOW MAN! U CANT GO TO SLEEP, NO!");
            }

            public override void WakeUp(Character character)
            {
                Console.WriteLine("U are already waken up");
            }
        }

        class SleepingState : CharacterState
        {
            public override void Move(Character character)
            {
                character.State = new MovingState();
                Console.WriteLine(character.Name + " has just awaken, and is now starting to MOVE HIS ASS!");
            }
            public override void Attack(Character character)
            {
                Console.WriteLine(character.Name + " is still sleeping, he needs to wake up first and go to moving state!");
            }
            public override void Sleep(Character character)
            {
                Console.WriteLine("You are already sleeping ffs ....");
            }

            public override void WakeUp(Character character)
            {
                character.State = new AwakenState();
                Console.WriteLine(character.Name + " has awaken!");
            }
        }

        class AwakenState : CharacterState
        {
            public override void Move(Character character)
            {
                character.State = new MovingState();
                Console.WriteLine(character.Name + " has started moving!");
            }
            public override void Attack(Character character)
            {
                character.State = new AttacikngState();
                Console.WriteLine(character.Name + " is going into attack state!");
            }
            public override void Sleep(Character character)
            {
                character.State = new SleepingState();
                Console.WriteLine(character.Name + " is going to sleep.");
            }

            public override void WakeUp(Character character)
            {
                Console.WriteLine(character.Name + " is already awaken and is standing still.");
            }
        }

        class Character
        {
            public CharacterState State { get; set; }
            public string Name { get; set; }
            public Character(String s)
            {
                Name = s;
                State = new AwakenState();
            }

            public void Move()
            {
                State.Move(this);
            }

            public void Attack()
            {
                State.Attack(this);
            }

            public void Sleep()
            {
                State.Sleep(this);
            }

            public void WakeUp()
            {
                State.WakeUp(this);
            }
        }

        static void Main(string[] args)
        {
            Character character = new Character("Ocelote");
            character.Move();
            character.Move();
            character.Attack();
            character.Attack();
            character.Sleep();
            character.Move();
            character.Sleep();
            Console.ReadLine();
        }
    }
}
