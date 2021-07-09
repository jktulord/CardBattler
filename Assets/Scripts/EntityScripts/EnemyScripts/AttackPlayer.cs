using Assets.Scripts.CardScripts;
using Assets.Scripts.CardScripts.CardEffect.CardAction;
using Assets.Scripts.PlayerScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.EntityScripts.EnemyScripts.Intentions
{
    public static class AttackPlayer
    {
        public static void DoEffect(PlayerEntity player, ICardEffect effect)
        {
            for (int i = 0; i < effect.Actions.Count; i++)
            {
                Act(player, effect.Actions[i]);
            }
        }

        public static void Act(PlayerEntity player, ICardAction action)
        {
            if (action.Type == CardScripts.CardEffect.ActionTypes.Damage)
            {
                DoDamage(player, action.Value);
            }
        }

        public static void DoDamage(PlayerEntity player, int value)
        {
            player.Hp -= value;
            player.ShowDamageNumber(value);
        }
    }
}
