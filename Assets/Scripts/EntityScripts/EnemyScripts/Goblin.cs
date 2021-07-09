using Assets.Scripts.CardScripts;
using Assets.Scripts.CardScripts.CardEffect;
using Assets.Scripts.EntityScripts.EnemyScripts.Intentions;
using Assets.Scripts.PlayerScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets.Scripts.EntityScripts.EnemyScripts
{
    public class Goblin : BasicEntity, IEnemy
    {
        private IntentionScript Intention { get; set; }
        private PlayerEntity player;
        public List<ICardEffect> Attacks { get; set; }
        public ICardEffect NextAttack { get; set; }
        public int NumberOfAttack { get; set; }

        public Goblin()
        {
            IsPlayer = false;
            MaxHp = 100;
            Hp = MaxHp;
            Attacks = new List<ICardEffect>
            {
                new DefaultDamageEffect(10),
                new DefaultDamageEffect(6),
                new DefaultDamageEffect(2),
                new DefaultDamageEffect(11)
            };
            NextAttack = Attacks[0];
            ShowNextIntetion();
        }
        public void Start()
        {
            HpCounter = transform.Find("HpCounter").GetComponent<TMP_Text>();
            Intention = transform.Find("EnemyIntention").GetComponent<IntentionScript>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
        }

        public void NextTurn()
        {
            Attack();
            ChangeAttack();
            ShowNextIntetion();
        }

        public void Attack()
        {
            AttackManager.Play(NextAttack, player, player);
        }

        public void ChangeAttack()
        {
            if (NumberOfAttack < Attacks.Count - 1)
            {
                NumberOfAttack++;
            }
            else
            {
                NumberOfAttack = 0;
            }
            NextAttack = Attacks[NumberOfAttack];
        }

        public void ShowNextIntetion()
        {
            Intention.UpdateByAction(NextAttack.Actions[0]);            
        }
    }
}
