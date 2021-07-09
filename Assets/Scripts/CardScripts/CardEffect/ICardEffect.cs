using Assets.Scripts.CardScripts.CardEffect;
using Assets.Scripts.CardScripts.CardEffect.CardAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CardScripts
{
    public interface ICardEffect
    {
        public TargetTypes Target { get; set; }
        public List<ICardAction> Actions { get; set; }

    }
}
