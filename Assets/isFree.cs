using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFree : MonoBehaviour
{
    public bool FreeNow = true;
    public GameObject[] players;
    public GameObject closest = null;
    public bool targeted;
    public bool TableOpen = false;
    // Update is called once per frame
    void Update()
    {
        
        players = GameObject.FindGameObjectsWithTag("Player");
       
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        if (players.Length !=0)
        {
            foreach (GameObject go in players)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }

            float curDist = Vector3.Distance(closest.transform.position, position);


            //var GetDeltaz = transform.position.z - GameObject.FindWithTag("Player").transform.position.z;
            //var GetDeltax = transform.position.x - GameObject.FindWithTag("Player").transform.position.x;
            if ((curDist <= 3f && closest.GetComponent<BuyDrinkAndSeat>().buyingSmthng) || (targeted && this.TableOpen))
            {
                FreeNow = false;
            }
            else
            {
                FreeNow = true;
            }
        }
        //Debug.Log(closest.GetComponent<BuyDrinkAndSeat>().buyingSmthng);
    }
}
