using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCheck : MonoBehaviour
{
    public containerEnd containerEnd;
    private List<string> alpha = new List<string> { "A", "B", "C"};
    string checker;
    void Start()
    {
        for (int i = 0; i < alpha.Count; i++)
        {
            string temp = alpha[i];
            int randomIndex = Random.Range(i, alpha.Count);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }
        foreach (string alpha in alpha)
        {
            checker += alpha;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))//right click
        {
            Debug.Log(checker);
            string result = containerEnd.Check();
            Debug.Log(result);
            if (result == checker)
            {
                Debug.Log("congrats");
            }
            else
                Debug.Log("nope");
        }
    }
}
