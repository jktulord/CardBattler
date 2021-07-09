using Assets.Scripts.CardScripts;
using Assets.Scripts.CardScripts.CardEffect;
using Assets.Scripts.CardScripts.CardEffect.CardAction;
using Assets.Scripts.DropScripts;
using Assets.Scripts.EntityScripts.EnemyScripts;
using Assets.Scripts.PlayerScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.EntityScripts
{
    public static class AttackManager 
    { 
        public static void Play(ICardEffect card, IEntity self, IEntity target)
        {
            for (int i = 0; i < card.Actions.Count; i++)
            {
                Act(card.Actions[i], self, target);
            }
        }

        public static void Act(ICardAction action, IEntity self, IEntity target)
        {
            switch (action.Type)
            {
                case ActionTypes.Damage:
                    Damage(target, action.Value);
                    break;
                case ActionTypes.Heal:
                    Heal(target, action.Value);
                    break;
                case ActionTypes.TargetHeal:
                    Heal(target, action.Value);
                    break;
                case ActionTypes.SelfHeal:
                    Heal(self, action.Value);
                    break;
                case ActionTypes.Block:
                    Block(self, action.Value);
                    break;
                case ActionTypes.Parry:
                    Parry(self, action.Value);
                    break;
                case ActionTypes.Dodge:
                    Dodge(self, action.Value);
                    break;
                default:
                    
                    break;
            }
            
        }

        public static void Damage(IEntity target, int value)
        {
            value = BlockDamage(target, value);
            
            target.Hp -= value;
            
            
            target.ShowDamageNumber(value);
        }

        public static int BlockDamage(IEntity target, int value)
        {
            if (target.Block > 0)
            {
                if (target.Block - value < 0)
                {
                    value -= target.Block;
                    target.Block = 0;

                }
                else
                {
                    target.Block -= value;
                    value = 0;
                }
            }
            return value;
        }

        // --- Damage functs --- 
        public static void Heal(IEntity target, int value)
        {
            target.Hp += value;
        }
        public static void Block(IEntity target, int value)
        {
            target.Block += value;
        }
        public static void Parry(IEntity target, int value)
        {
            target.ParryPoints += value;
        }
        public static void Dodge(IEntity target, int value)
        {
            target.DodgePoints += value;
        }

    }
}
