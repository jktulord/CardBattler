using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CardScripts.CardEffect.CardAction
{
    public class Block : ICardAction
    {
        public ActionTypes Type { get; set; }
        public int Value { get; set; }

        public Block(int value)
        {
            Type = ActionTypes.Block;
            Value = value;
        }
    }
}
