using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContOfVar : MonoBehaviour
{
    public GameObject[] barCont;
    public GameObject Ways;
    public Text txt;
    public Text txt2;
    public Text txt3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "respawn time " + Spawner.SpawnTime;
        txt2.text = "Buy time " + BuyDrinkAndSeat.buy;
        txt3.text = "Drink time " + BuyDrinkAndSeat.drink;
    }
    public void SpawnUp()
    {
        Spawner.SpawnTime++;
    }
    public void SpawnDown()
    {
        Spawner.SpawnTime--;
    }
    public void BuyUp()
    {
        BuyDrinkAndSeat.buy++;
    }
    public void BuyDown()
    {
        BuyDrinkAndSeat.buy--;
    }
    public void DrinkUp()
    {
        BuyDrinkAndSeat.drink++;
    }
    public void DrinkDown()
    {
        BuyDrinkAndSeat.drink--;
    }
}
