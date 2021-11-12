using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    class GiftByAge: IGift
    {
        public IToy toyInGift { get; private set; }
        public IFood foodInGift { get; private set; }
        public string wishInGift { get; private set; }


        public GiftByAge(IGift giftUnadapdetToAge, IToy toyByAge)
        {
            this.toyInGift = toyByAge;
            this.wishInGift = giftUnadapdetToAge.wishInGift;
            this.foodInGift = giftUnadapdetToAge.foodInGift;
        }

        public override string ToString()
        {
            return $"{toyInGift.ToString()}, {foodInGift.ToString()}, {wishInGift}";
        }
    }
}
