using Assets.Scripts;
using Assets.Scripts.CardScripts;
using Assets.Scripts.CardScripts.CardEffect;
using Assets.Scripts.CardScripts.CardEffect.CardAction;
using Assets.Scripts.EntityScripts.EnemyScripts;
using Assets.Scripts.Extensions;
using Assets.Scripts.PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandPlaceScript : MonoBehaviour, IDropHandler
{
    public PlayerEntity player;
    public IEnemy enemy;

    public DeckSpaceScript DrawSpace;
    public DeckSpaceScript DropSpace;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Goblin>();
        DrawSpace = GameObject.Find("Draw Space").GetComponent<DeckSpaceScript>();
        DropSpace = GameObject.Find("Drop Space").GetComponent<DeckSpaceScript>();

        GameObject prefab = Resources.Load<GameObject>("Prefabs/Card");
        DrawSpace.cards = GetMockDeck();
        List<CardStats> Hand = DrawSpace.GetRandomList(4);
        InstansiateHand(Hand);
    }

    public void OnDrop(PointerEventData eventData)
    {
        CardDropScript card = eventData.pointerDrag.GetComponent<CardDropScript>();

        if (card)
            card.DefaultParent = transform;
    }

    public void NextTurn()
    {
        enemy.NextTurn();
        player.NextTurn();
        

        List<Transform> children = gameObject.transform.GetAllChildren();
        for (int i = 0; i < children.Count; i++)
        {
            DropSpace.Add(children[i].GetComponent<CardDropScript>().Stats);
            Destroy(children[i].gameObject);
        }
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Card");
        List<CardStats> Hand;
        int DrawCount = DrawSpace.cards.Count;
        if (DrawCount < 4) 
        {
            Hand = DrawSpace.GetRandomList(DrawCount);
            DrawSpace.Add(DropSpace.GetRandomAll());
            Hand.AddRange(DrawSpace.GetRandomList(4 - DrawCount));
        }
        else
        {
            Hand = DrawSpace.GetRandomList(4);
        }
        InstansiateHand(Hand);
    }
    
   
    public List<CardStats> GetMockDeck()
    {

        CardStats LightHit = new CardStats("Percise Hit",
            "Does 2 damage",
            new BasicCardCost(0),
            new DefaultDamageEffect(2));

        CardStats Throw = new CardStats("Throw",
            "Does 5 damage",
            new BasicCardCost(2),
            new DefaultDamageEffect(5));

        CardStats PowerPunch = new CardStats("PowerPunch",
            "Does 7 damage",
            new BasicCardCost(4),
            new DefaultDamageEffect(7));

        CardStats PerciseHit = new CardStats("Percise Hit",
            "Does 17 damage",
            new BasicCardCost(7),
            new DefaultDamageEffect(20));

        CardStats GuardBlock = new CardStats("Guard Block",
            "Gain 2 block",
            new BasicCardCost(0),
            new DefaultBlockEffect(2));

        CardStats DodgeRoll = new CardStats("Dodge Roll",
            "Gain 1 dodge point",
            new BasicCardCost(0),
            new DefaultDodgeEffect(1));

        CardStats DirtyParry = new CardStats("Dirty Parry",
            "Gain 4 Parry point",
            new BasicCardCost(0),
            new DefaultParryEffect(4));

        CardStats HealthPotion = new CardStats("Health Potion",
            "Heal 20 points",
            new BasicCardCost(9),
            new DefaultHealEffect(20));

        CardStats UltimateCard = new CardStats("Ultimate",
            "Deal 1x4 damage, gain 1 dodge point, heal 1 point, gain 1 parry point, and make your pp hard",
            new BasicCardCost(5),
            new CustomEffect(
                20, new List<ICardAction> 
                { 
                    new Damage(1),
                    new Dodge(1),
                    new Heal(1),
                    new Parry(1),
                    new Damage(1),
                    new Damage(1),
                    new Damage(1) 
                }    
                ));

        List<CardStats> MockDeck = new List<CardStats>
        {
            LightHit,
            LightHit,
            Throw,
            Throw,
            PowerPunch,
            PowerPunch,
            PerciseHit,
            PerciseHit,
            GuardBlock,
            GuardBlock,
            DodgeRoll,
            DodgeRoll,
            DirtyParry,
            DirtyParry,
            HealthPotion,
            UltimateCard
        };

        return MockDeck;
    }

    public void InstansiateHand(List<CardStats> MockDeck)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Card");
        for (int i = 0; i < MockDeck.Count; i++)
        {
            GameObject gameObject = Instantiate(prefab);
            gameObject.GetComponent<CardDropScript>().Stats = MockDeck[i];
            gameObject.transform.SetParent(transform, false);
        }
    }
}
