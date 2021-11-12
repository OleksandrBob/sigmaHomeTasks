using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    abstract class AbstractNicholasAdapter : IGiftSender
    {//Діти викликають завжди ці методи
        public abstract IGift GetGift1(Child child);

        public abstract IGift GetGift2(Child child);
    }

    class AgeNicholasAdapter : AbstractNicholasAdapter
    {
        List<ToyVariant> toysBoyBelow10 = null;
        List<ToyVariant> toysBoyAbove9 = null;
        List<ToyVariant> toysGirlsBelow10 = null;
        List<ToyVariant> toysGirlsAbove9 = null;


        public AgeNicholasAdapter(List<ToyVariant> toysBoyBelow10, List<ToyVariant> toysBoyAbove9, List<ToyVariant> toysGirlsBelow10, List<ToyVariant> toysGirlsAbove9) 
        {
            this.toysBoyBelow10 = toysBoyBelow10;
            this.toysBoyAbove9 = toysBoyAbove9;
            this.toysGirlsBelow10 = toysGirlsBelow10;
            this.toysGirlsAbove9 = toysGirlsAbove9;
        }


        public override IGift GetGift1(Child child)
        {
            var classicNicholas = Nicholas.GetInstance();
            if (classicNicholas.builder1 == null)
            {
                throw new Exception("Nicholas is uninitialised!");
            }

            var oldGift = classicNicholas.GetGift1(child);
            Random randInd = new Random();
            

            if (child.ChildGender == Gender.male && child.Age < 10)
            {
                return new GiftByAge(oldGift, new Toy(toysBoyBelow10[randInd.Next(0, toysBoyBelow10.Count)], randInd.Next(0, 100), "Toy for boy"));
            }
            else if (child.ChildGender == Gender.male && child.Age > 9)
            {
                return new GiftByAge(oldGift, new Toy(toysBoyAbove9[randInd.Next(0, toysBoyAbove9.Count)], randInd.Next(0, 100), "Toy for boy"));
            }
            else if (child.ChildGender == Gender.female && child.Age < 10)
            {
                return new GiftByAge(oldGift, new Toy(toysGirlsBelow10[randInd.Next(0, toysGirlsBelow10.Count)], randInd.Next(0, 100), "Toy for girl"));
            }
            else if (child.ChildGender == Gender.female && child.Age > 9)
            {
                return new GiftByAge(oldGift, new Toy(toysGirlsAbove9[randInd.Next(0, toysGirlsAbove9.Count)], randInd.Next(0, 100), "Toy for girl"));
            }

            return null;
        }

        public override IGift GetGift2(Child child)
        {
            var classicNicholas = Nicholas.GetInstance();
            if (classicNicholas.builder1 == null)
            {
                throw new Exception("Nicholas is uninitialised!");
            }

            var oldGift = classicNicholas.GetGift2(child);
            Random randInd = new Random();


            if (child.ChildGender == Gender.male && child.Age < 10)
            {
                return new GiftByAge(oldGift, new Toy(toysBoyBelow10[randInd.Next(0, toysBoyBelow10.Count)], randInd.Next(0, 100), "Toy for boy"));
            }
            else if (child.ChildGender == Gender.male && child.Age > 9)
            {
                return new GiftByAge(oldGift, new Toy(toysBoyAbove9[randInd.Next(0, toysBoyAbove9.Count)], randInd.Next(0, 100), "Toy for boy"));
            }
            else if (child.ChildGender == Gender.female && child.Age < 10)
            {
                return new GiftByAge(oldGift, new Toy(toysGirlsBelow10[randInd.Next(0, toysGirlsBelow10.Count)], randInd.Next(0, 100), "Toy for girl"));
            }
            else if (child.ChildGender == Gender.female && child.Age > 9)
            {
                return new GiftByAge(oldGift, new Toy(toysGirlsAbove9[randInd.Next(0, toysGirlsAbove9.Count)], randInd.Next(0, 100), "Toy for girl"));
            }

            return null;
        }
    }
}
