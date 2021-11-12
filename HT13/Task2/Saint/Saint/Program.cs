using System;
using System.Collections.Generic;

namespace Saint
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> wishes = new List<string>() { "good Luck", "marry Christmas", "all the best", "many friends" };
            List<ToyVariant> toysB = new List<ToyVariant>() { ToyVariant.Ball, ToyVariant.Car, ToyVariant.Guitare, ToyVariant.Gun, ToyVariant.Wolf };
            List<ToyVariant> toysG = new List<ToyVariant>() { ToyVariant.Doll, ToyVariant.House, ToyVariant.Rabbit, ToyVariant.Ring };
            List<FoodVariant> foodv = new List<FoodVariant>() { FoodVariant.Apple, FoodVariant.Grapes, FoodVariant.Orange, FoodVariant.Pear, FoodVariant.Pineapple, FoodVariant.Strawberry };

            var s = Nicholas.GetInstance();
            var s1 = Nicholas.GetInstance();//Checking singleton
            s1.builder1 = new BuilderFirstVariant(wishes, toysB, toysG, foodv);
            s1.builder2 = new BuilderSecondVariant(wishes, toysB, toysG, foodv);


            var ch1 = new Child("Marta", Gender.female, 4, 1, 12);
            var ch2 = new Child("Mark", Gender.male, 4, 5, 9);
            var ch3 = new Child("Anton", Gender.male, 4, 3, 11);
            var ch4 = new Child("Mark", Gender.male, 3, 1, 7);

            AgeNicholasAdapter ageNicholasAdapter = new AgeNicholasAdapter(
                                                    new List<ToyVariant>() { ToyVariant.Ball, ToyVariant.Car, },
                                                    new List<ToyVariant>() { ToyVariant.Guitare, ToyVariant.Gun, ToyVariant.Wolf },
                                                    new List<ToyVariant>() { ToyVariant.Doll, ToyVariant.Rabbit, },
                                                    new List<ToyVariant>() { ToyVariant.House, ToyVariant.Ring });


            //ch1.GetMyGift1(s1);
            //ch2.GetMyGift2(s1);
            //ch3.GetMyGift2(s1);
            //ch4.GetMyGift1(s1);

            ch1.GetMyGift1(ageNicholasAdapter);
            ch2.GetMyGift2(ageNicholasAdapter);
            ch3.GetMyGift2(ageNicholasAdapter);
            ch4.GetMyGift1(ageNicholasAdapter);

            Console.WriteLine(ch1.ChildGift);
            Console.WriteLine(ch2.ChildGift);
            Console.WriteLine(ch3.ChildGift);
            Console.WriteLine(ch4.ChildGift);
        }
    }
}
