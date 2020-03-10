using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCheck : MonoBehaviour
{
    public containerEnd containerEnd;
    private clearAndReset clearAndReset;
    private inventoryManager inventoryManager;
    private List<string> containers = new List<string> { "A", "B", "C"};
    string checker;
    public List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer button;
    private float timeLeft = 5;
    void Start()
    {
        button = this.GetComponent<SpriteRenderer>();
        button.sprite = sprites[0];
        resetPotions();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))//right click
        {
            string result = "";
            result = containerEnd.Check();
            Debug.Log(result);
            Debug.Log(checker);
            if (result == checker)
            {
                Debug.Log("congrats");
                timeLeft = 3;
                button.sprite = sprites[1];
                resetPotions();
            }
            else
            {
                Debug.Log("nope");
                button.sprite = sprites[2];
                timeLeft = 3;
            }
        }
    }

    private void resetPotions()
    {
        checker = "";
        for (int i = 0; i < containers.Count; i++)
        {
            string temp = containers[i];
            int randomIndex = Random.Range(i, containers.Count);
            containers[i] = containers[randomIndex];
            containers[randomIndex] = temp;
        }
        foreach (string containers in containers)
        {
            checker += containers;
        }
        inventoryManager.INSTANCE.closeContainer();
        clearAndReset.INSTANCE.jumbleContainers();
    }

    private void LateUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            button.sprite = sprites[0];
            timeLeft = 60;
        }
    }

}
