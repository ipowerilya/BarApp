using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Human;
    public GameObject Cont;
    public static float SpawnTime = 4;
    public bool waiting;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = Time.time + SpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        GameObject go = Instantiate(Human, transform.position, transform.rotation) as GameObject;
        //        for(int i = 0; i< go.GetComponent<BuyDrinkAndSeat>().waypointsBars.Length; i++)
        //        go.GetComponent<BuyDrinkAndSeat>().waypointsBars[i] = Cont.GetComponent<ContOfVar>().barCont[i];
        //        go.GetComponent<BuyDrinkAndSeat>().waysToTables = Cont.GetComponent<ContOfVar>().Ways;


        //    }
        //StartCoroutine(Spawning());
        if(Timer < Time.time)
        {
            GameObject go = Instantiate(Human, transform.position, transform.rotation) as GameObject;
            for (int i = 0; i < go.GetComponent<BuyDrinkAndSeat>().waypointsBars.Length; i++)
                go.GetComponent<BuyDrinkAndSeat>().waypointsBars[i] = Cont.GetComponent<ContOfVar>().barCont[i];
            go.GetComponent<BuyDrinkAndSeat>().waysToTables = Cont.GetComponent<ContOfVar>().Ways;
            Timer = Time.time + SpawnTime;
        }
    }
    public void SpawnObj()
    {
        GameObject go = Instantiate(Human, transform.position, transform.rotation) as GameObject;
        for (int i = 0; i < go.GetComponent<BuyDrinkAndSeat>().waypointsBars.Length; i++)
            go.GetComponent<BuyDrinkAndSeat>().waypointsBars[i] = Cont.GetComponent<ContOfVar>().barCont[i];
        go.GetComponent<BuyDrinkAndSeat>().waysToTables = Cont.GetComponent<ContOfVar>().Ways;
    }
    IEnumerator Spawning()
    {
        waiting = true;
        yield return new WaitForSeconds(SpawnTime);
        if (waiting)
        {
            GameObject go = Instantiate(Human, transform.position, transform.rotation) as GameObject;
            for (int i = 0; i < go.GetComponent<BuyDrinkAndSeat>().waypointsBars.Length; i++)
                go.GetComponent<BuyDrinkAndSeat>().waypointsBars[i] = Cont.GetComponent<ContOfVar>().barCont[i];
            go.GetComponent<BuyDrinkAndSeat>().waysToTables = Cont.GetComponent<ContOfVar>().Ways;
        }
        waiting = false;
        yield return new WaitForSeconds(SpawnTime);
    }
}
