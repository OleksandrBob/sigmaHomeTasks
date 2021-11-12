using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    interface IGiftSender 
    {
        IGift GetGift1(Child child);
        IGift GetGift2(Child child);
    }

    class Nicholas: IGiftSender
    {
        private static Nicholas instance = null;

        private Nicholas() { }

        static Nicholas()
        {
            instance = new Nicholas();
        }

        public static Nicholas GetInstance() 
        {
            return instance;
        }

        public AbstractBuilder builder1 { get; set; }
        public AbstractBuilder builder2 { get; set; }


        public IGift GetGift1(Child child)
        {
            builder1.PutFood(child.ChildGender);
            builder1.PutToy(child.GoodDeeds, child.BadDeeds, child.ChildGender);
            builder1.PutWish(child.GoodDeeds, child.BadDeeds, child.ChildGender, child.Name);

            return builder1.Build();
        }

        public IGift GetGift2(Child child)
        {
            builder2.PutFood(child.ChildGender);
            builder2.PutToy(child.GoodDeeds, child.BadDeeds, child.ChildGender);
            builder2.PutWish(child.GoodDeeds, child.BadDeeds, child.ChildGender, child.Name);

            return builder2.Build();
        }
    }
}
