using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.CardScripts.CardEffect.CardAction;

public class IntentionScript : MonoBehaviour
{
    private TMP_Text ValueText;

    // Start is called before the first frame update
    void Start()
    {
        ValueText = transform.Find("ValueCounter").GetComponent<TMP_Text>();
    }

    public void UpdateByAction(ICardAction action)
    {
        ValueText.text = "" + action.Value;
    }

    
}
