using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyDrinkAndSeat : MonoBehaviour
{
    //public GameObject[,,] waypointsAll;
    public GameObject[] waypointsBars;
    //public GameObject[] waypointsRoads;
    public GameObject[] waypointsTables;
    public GameObject[] players;
    public GameObject[] childArray;
    public int current = 0;
    public float speed;
    public static float buy = 4;
    public static float drink = 4;
    private float WPradius = 1;
    public bool buyingSmthng = false;
    private bool drinking = false;
    public bool nowFree = true;
    private bool getOverHere = true;
    private bool getOverHerePrev = true;
    isFree allowedBars;
    isFree allowedBarsPrev;
    public bool needToWait;
    public int stage=0;
    public bool lastOne = false;
    public float randDist;
    public int curBar=2;
    public int goThere = 2;
    public bool ochered = false;
    public GameObject closest = null;
    public int nearestPoint;
    public int current2 = 0;
    public int current3 = 0;
    public Transform[] childs;
    public GameObject[] childObjects;
    public bool notSet = true;
    int value = 0;
    public GameObject waysToTables;
    public string newString;
    public int newInt;
    public bool[] freeTable;
    public int TableCount;
    public bool startedMooving;
    public bool TableSet;
    public bool ArrayDone;
    public bool wasThird;
    public bool wasThird2;
    public int getI;
    public bool goAgain;
    public bool InOrder;

    
    


    void Start()
    {
        
    }
    void Update()
    {
        
        if (stage == 0)
        {
            if (!buyingSmthng)
            {
                if (nowFree)
                    MovingTo(waypointsBars, current, speed);

                if (!waypointsBars[current].GetComponent<isFree>().FreeNow)
                {
                    if (current < waypointsBars.Length - 1)
                        current++;
                    if (current >= waypointsBars.Length - 1)
                    {
                        lastOne = true;
                        wasThird = true;
                        wasThird2 = true;

                    }
                }
                
                
                    for (int i = current; i >= 0; i--)
                    {
                        if (waypointsBars[i].GetComponent<isFree>().FreeNow)
                        {
                            nearestPoint = i;
                        }
                    }
                    current = nearestPoint;
                
                
               
                //MovingTo(waypointsBars, current, speed);

                // Debug.Log("isHere");
                if (playerOrder() != null)
                        if (Vector3.Distance(playerOrder().transform.position, transform.position) <= 20 && transform.position.x == playerOrder().transform.position.x)
                        {
                        if (Vector3.Distance(waypointsBars[1].transform.position, transform.position) < Vector3.Distance(waypointsBars[2].transform.position, transform.position))
                            wasThird2 = false;
                        if(!playerOrder().GetComponent<BuyDrinkAndSeat>().buyingSmthng || playerOrder().GetComponent<BuyDrinkAndSeat>().wasThird2)
                        //randDist = Vector3.Distance(waypointsBars[waypointsBars.Length - 1].transform.position, transform.position);
                            
                                nowFree = false;
                        }
                        else
                            nowFree = true;

                startWaiting(waypointsBars, current, buy);

            }
            
            
            
        }

        if (stage >= 1)
        {
            
            
            if (notSet)
            {
                if (!ArrayDone)
                {
                    childs = waysToTables.GetComponentsInChildren<Transform>();
                    childObjects = new GameObject[childs.Length];
                    foreach (Transform trans in childs)
                    {
                        value++;
                        childObjects.SetValue(trans.gameObject, value - 1);
                    }
                    ArrayDone = true;
                }
                for (int i = childObjects.Length - 1; i > 0; i--)
                {
                    if (childObjects[i].tag == "Table")
                    {
                        
                        if (childObjects[i].GetComponent<isFree>().FreeNow && childObjects[i].GetComponent<isFree>().TableOpen && !childObjects[i].GetComponent<isFree>().targeted)
                        {
                            if (!wasThird)
                            {
                                current2 = i;
                                Debug.Log(current2);
                                TableSet = true;
                            }
                            else
                                
                                StartCoroutine(WaitIsneed());
                            
                        }
                        //TableCount++;
                    }
                }
                if (TableSet)
                {
                    newString = childObjects[current2].name.Substring(childObjects[current2].name.Length - 1);
                    for (int i = childObjects.Length - 1; i > 0; i--)
                    {
                        if (childObjects[i].tag == newString)
                        {
                            
                            current3 = i;
                            
                        }
                    }
                    //freeTable = new bool[TableCount];
                    notSet = false;
                    startedMooving = true;
                    childObjects[current2].GetComponent<isFree>().targeted = true;
                }
                else
                    if (Vector3.Distance(waypointsBars[0].transform.position, transform.position) > 1)
                    MovingTo(childObjects, 0, speed);
                //current3 = 5;
            }

            if (TableSet)
            {
                Debug.Log(childObjects[current2].name);

                if (Vector3.Distance(childObjects[current3].transform.position, transform.position) <= 1)
                {
                    current3++;
                }
                if (!buyingSmthng && current3 !=0)
                    MovingTo(childObjects, current3, speed);
                if (childObjects[current3].tag == "Table")
                    startWaiting(childObjects, current3, drink);
                if (childObjects[current3].tag == "Exit" && Vector3.Distance(childObjects[current3].transform.position, transform.position) <= 1)
                    gameObject.SetActive(false);
            }



            //foreach (char c in childObjects[current2].name)
            //{
            //    if (int.TryParse(c.ToString(), out newInt))
            //    {
            //        newString += c.ToString();
            //    }
            //}
            //newInt = int.Parse(newString);

            /*
            //for (int i = 9; i>0; i--) 
            //{
            //    foreach(Transform child in waypointsTables[i].transform)
            //    {
            //        if(child.tag == "Table")
            //        {
            //            if (child.GetComponent<isFree>().FreeNow)
            //            {
            //                current2 = i;
            //            }
            //        }
            //    }
            //}
            /*
            if (nowFree)
            {
                Transform[] children = waypointsTables[current2].transform.GetComponentsInChildren<Transform>();
                Debug.Log(children.Length);
                 childArray = new GameObject[waypointsTables[current2].transform.childCount+1];
                Debug.Log(childArray.Length);
                for ( int i = 0; i<=children.Length; i++)
                {
                    childArray[i] = children[i].gameObject;
                }
                Debug.Log(childArray);

                //MovingTo(a, current, speed);
            }
            */
        }

        
    }
  
    public int GetClosestThing(GameObject[] waypoints, int curent, int footstep)
    {
        int tMin = current;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        for(int i = 0; i <= curent; i=i+footstep)
        {
            float dist = Vector3.Distance(waypoints[i].transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = i;
                minDist = dist;
            }
        }
        return tMin;
    }

    public void MovingTo(GameObject[] waypoints, int current, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
    
    public void startWaiting(GameObject[] waypoints, int current, float HowMuch)
    {
        if(!InOrder)
            if (current != 0)
                if (waypointsBars[current - 1].GetComponent<isFree>().FreeNow)
                {
                    goAgain = true;
                    current = current - 1;
                    if (goAgain)
                    MovingTo(waypointsBars, current, speed);
                }

        if (Vector3.Distance(waypoints[current].transform.position, transform.position) <= 1)
        {
            
            StartCoroutine(Wait(HowMuch, waypointsBars));
            
        }
        
    }
    
    public GameObject playerOrder()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in players)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance != 0 && go.transform.position.z > position.z && go.transform.position.x == position.x && go.transform.position.y == position.y)
            {
                closest = go;
                distance = curDistance;
            }
        }
       
        
        return(closest);
    }
    

    IEnumerator Wait(float HowMuch, GameObject[] waypoints)
    {
        goAgain = false;
        buyingSmthng = true;
        if (stage == 0)
        if (current != 0)
            if (waypointsBars[current - 1].GetComponent<isFree>().FreeNow)
            {
                current = current - 1;
                MovingTo(waypointsBars, 0, speed);
            }

        yield return new WaitForSeconds(HowMuch);
        if(stage >=1)
        childObjects[current2].GetComponent<isFree>().targeted = false;

        buyingSmthng = false;
        if (stage == 0)
        {
            BtnController.Money = BtnController.Money + 5;
           
        }

        InOrder = true;
        stage++;
    }

    IEnumerator WaitIsneed()
    {
        yield return new WaitForSeconds(0.1f);
        wasThird = false;
        Debug.Log(current2);
        
    }

}
    /*
    //move to bar

    if (!needToWait && CanYouGo(waypointsBars, current))
    {
        MovingTo(waypointsBars, current, speed);
    }

    if (Vector3.Distance(waypointsBars[current].transform.position, transform.position) < WPradius)
    {

    }
    }
    public void MovingTo(GameObject[] waypoints, int current, float speed)
    {
    transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
    public bool CanYouGo(GameObject[] waypoints, int current)
    {
    bool getOverHere = waypoints[current].GetComponent<isFree>().FreeNow;
    return (getOverHere);
    }
    public void NextStep ()
    {
    }
    /*
    //Bar
    allowedBars = waypointsBars[current].GetComponent<isFree>();
    if (current != 0)
    {
        allowedBarsPrev = waypointsBars[current - 1].GetComponent<isFree>();
        getOverHerePrev = allowedBarsPrev.FreeNow;
    }
    getOverHere = allowedBars.FreeNow;

    /*
    if (current !=  )
    {
        if (getOverHerePrev && !buyingSmthng && !drinking)
        {
            current--;
            transform.position = Vector3.MoveTowards(transform.position, waypointsBars[current].transform.position, Time.deltaTime * speed);
        }
    }

    else */ /* if (getOverHere && !buyingSmthng && !drinking)
    {
        transform.position = Vector3.MoveTowards(transform.position, waypointsBars[current].transform.position, Time.deltaTime * speed);
    }
    else
    {
        current++;
    }
    if (current >= waypointsBars.Length)
    {
        if (!buyingSmthng && !drinking)
        {
            while (Vector3.Distance(waypointsBars[current].transform.position, transform.position) > 6)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypointsBars[current].transform.position, Time.deltaTime * speed);
            }
            if (getOverHere)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypointsBars[current].transform.position, Time.deltaTime * speed);
                StartCoroutine(BuyDrink());
            }
        }

    }
    /*
    if (Vector3.Distance(waypoints[current].transform.position, transform.position) < 10 && !getOverHere && Vector3.Distance(waypoints[current].transform.position, transform.position) > 5)
    {
        current++;
    }
    if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
    {
        Debug.Log(buyingSmthng);
        if (waypoints[current].tag == "Bar" && !buyingSmthng)
        {
            StartCoroutine(BuyDrink());   
        }
        if (waypoints[current].tag == "Table" && !drinking)
        {
            StartCoroutine(DrinkVodka());
        }
        current++;


    }

    if (!buyingSmthng && !drinking)
    transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }
    */







    /*
    public void DoneThing(GameObject[] waypoints, int GetRadius, bool forWhat, int Buy)
    {
        int current = 0;
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < GetRadius)
        {
            if (waypointsBars[current].tag == "Bar" && !buyingSmthng)
            {
                needToWait = true;
                current = 0;
            }
        }
    }
}
*/
