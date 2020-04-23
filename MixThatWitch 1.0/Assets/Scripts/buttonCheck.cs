using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCheck : MonoBehaviour
{
    public containerEnd containerEnd;
    private clearAndReset clearAndReset;
    private inventoryManager inventoryManager;
    private List<string> potionMix = new List<string> { "A", "B", "C"};
    string checker;
    public List<Sprite> feedback = new List<Sprite>();
    private SpriteRenderer button;
    private float timeLeft = 5;

    public List<GameObject> potionUI = new List<GameObject>();
    public List<Sprite> potionIcon = new List<Sprite>();
    private SpriteRenderer potionDisplay;
    

    

    void Start()
    {
        button = this.GetComponent<SpriteRenderer>();
        button.sprite = feedback[0];
        resetPotions();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))//left click
        {
            string result = "";
            result = containerEnd.Check();
            //Debug.Log(result);
            //Debug.Log(checker);
            if (result == checker)
            {
                //Debug.Log("congrats");
                timeLeft = 3;
                button.sprite = feedback[1];
                resetPotions();
            }
            else
            {
                //Debug.Log("nope");
                button.sprite = feedback[2];
                timeLeft = 3;
            }
        }
    }

    private void resetPotions()
    {
        checker = "";
        for (int i = 0; i < potionMix.Count; i++)
        {
            Sprite temp2 = potionIcon[i];
            string temp = potionMix[i];
            int randomIndex = Random.Range(i, potionMix.Count);
            potionMix[i] = potionMix[randomIndex];
            potionMix[randomIndex] = temp;

            potionIcon[i] = potionIcon[randomIndex];
            potionIcon[randomIndex] = temp2;
            potionDisplay = potionUI[i].GetComponent<SpriteRenderer>();
            potionDisplay.sprite = potionIcon[i];

        }
        //Debug.Log(potionIcon[0].ToString() + potionIcon[1].ToString() + potionIcon[2].ToString());
        foreach (string potions in potionMix)
        {
            checker += potions;
        }
        inventoryManager.INSTANCE.closeContainer();
        clearAndReset.INSTANCE.jumbleContainers();
    }

    private void LateUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            button.sprite = feedback[0];
            timeLeft = 60;
        }
    }

}
