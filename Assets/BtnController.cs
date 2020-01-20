using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnController : MonoBehaviour
{
    public GameObject[] childArray;
    public Transform[] childs;
    public GameObject[] childObjects;
    public GameObject waysToTables;
    public Text txt;
    public GameObject button;
    int value = 0;
    public bool upgraded;
    public static int Money = 0;
    public int MMnoney;
    public int lastAmount = 10;
    // Start is called before the first frame update
    void Start()
    {
        txt.text = "Money: " + Money;
        childs = waysToTables.GetComponentsInChildren<Transform>();
        childObjects = new GameObject[childs.Length];
        foreach (Transform trans in childs)
        {
            value++;
            childObjects.SetValue(trans.gameObject, value - 1);
        }
        
    }
    public void Upgrade()
    {
       // MMnoney = Money;
       
        upgraded = false;
        for (int i = 0; i < childObjects.Length - 1; i++)
        {
            if (childObjects[i].tag == "Table" && !childObjects[i].GetComponent<isFree>().TableOpen && !upgraded && Money >= lastAmount)
            {
                childObjects[i].GetComponent<isFree>().TableOpen = true;
                upgraded = true;
                lastAmount = lastAmount + 10;
                button.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Money: " + Money;
        if(Money >= lastAmount)
        {
            button.gameObject.SetActive(true);
        }
    }
}
