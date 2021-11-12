using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    class Child
    {
        public string Name { get; private set; }
        public Gender ChildGender { get; private set; }
        public int GoodDeeds { get; private set; }
        public int BadDeeds { get; private set; }
        public int Age { get; private set; }
        public IGift ChildGift { get; set; }


        public Child(string name, Gender gender, int goodDeeds, int badDeeds, int age)
        {
            this.BadDeeds = badDeeds;
            this.GoodDeeds = goodDeeds;
            this.Name = name;
            this.Age = age;
            this.ChildGender = gender;
        }


        public void GetMyGift1(IGiftSender nicholas) 
        {
            ChildGift = nicholas.GetGift1(this);
        }
        public void GetMyGift2(IGiftSender nicholas)
        {
            ChildGift = nicholas.GetGift2(this);
        }
    }
}
