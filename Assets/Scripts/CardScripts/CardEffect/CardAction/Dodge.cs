using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CardScripts.CardEffect.CardAction
{
    public class Dodge : ICardAction
    {
        public ActionTypes Type { get; set; }
        public int Value { get; set; }

        public Dodge(int value)
        {
            Type = ActionTypes.Dodge;
            Value = value;
        }
    }
}
