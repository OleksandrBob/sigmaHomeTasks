using System;
using System.Collections.Generic;
using System.Text;

namespace Saint
{
    interface IGift 
    {
        IToy toyInGift { get; }
        IFood foodInGift { get; }
        string wishInGift { get; }
    }

    class Gift: IGift
    {
        public IToy toyInGift { get; private set; }
        public IFood foodInGift { get; private set; }
        public string wishInGift { get; private set; }//...

        public Gift(AbstractBuilder builder) 
        {
            this.toyInGift = builder.toyForChild;
            this.wishInGift = builder.wishForChild;
            this.foodInGift = builder.foodForChild;
        }

        public override string ToString()
        {
            return $"{toyInGift.ToString()}, {foodInGift.ToString()}, {wishInGift}";
        }
    }
}
