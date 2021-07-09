using Assets.Scripts.CardScripts.CardEffect.CardAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CardScripts.CardEffect
{
    public class DefaultDamageEffect : ICardEffect
    {
        public TargetTypes Target { get; set; }
    
        public List<ICardAction> Actions { get; set; }

        public DefaultDamageEffect(int value)
        {
            Target = TargetTypes.enemy;
            Actions = new List<ICardAction>
            {
                new Damage(value)
            };
        }
    }
}
