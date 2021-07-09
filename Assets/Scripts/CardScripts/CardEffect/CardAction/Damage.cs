using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CardScripts.CardEffect.CardAction
{
    public class Damage : ICardAction
    {
        public ActionTypes Type { get; set; }
        public int Value { get; set; }
        
        public Damage(int value)
        {
            Type = ActionTypes.Damage;
            Value = value;
        }
    }
}
