using Assets.Scripts.CardScripts.CardEffect.CardAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CardScripts.CardEffect
{
    public class CustomEffect : ICardEffect
    {
        public TargetTypes Target { get; set; }

        public List<ICardAction> Actions { get; set; }

        public CustomEffect(int value, List<ICardAction> actions)
        {
            Target = TargetTypes.enemy;
            Actions = actions;
        }
    }
}
