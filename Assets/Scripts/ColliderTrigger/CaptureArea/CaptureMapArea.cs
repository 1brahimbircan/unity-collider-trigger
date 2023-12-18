using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureMapArea : MonoBehaviour
{

    public enum State
    {
        Neutral,
        Captured,
    }
    private List<CaptureMapAreaCollider> mapAreaColliderList;
    private State state;
    private float progress;

    private void Awake()
    {
        mapAreaColliderList = new List<CaptureMapAreaCollider>();
        foreach(Transform child in transform)
        {
            CaptureMapAreaCollider mapAreaCollider = child.GetComponent<CaptureMapAreaCollider>();
            if(mapAreaCollider != null)
            {
                mapAreaColliderList.Add(mapAreaCollider);
            }
        }
        state = State.Neutral;
    }

    void Update()
    {
        switch (state)
        {

            case State.Neutral:

                List<PlayerMapAreas> playerMapAreasInsideList = new List<PlayerMapAreas>();

                foreach (CaptureMapAreaCollider mapAreaCollider in mapAreaColliderList)
                {
                    foreach (PlayerMapAreas playerMapAreas in mapAreaCollider.GetPlayerMapAreasList())
                    {
                        if (!playerMapAreasInsideList.Contains(playerMapAreas))
                        {
                            playerMapAreasInsideList.Add(playerMapAreas);
                        }
                    }

                }
                float progressSpeed = .5f;
                progress += playerMapAreasInsideList.Count * progressSpeed * Time.deltaTime;
                
                if (progress >= 1f)
                {
                    state = State.Captured;
                    Debug.Log("Captured");
                }
                else
                {
                    Debug.Log("PlayerCountInsideMapArea: " + playerMapAreasInsideList.Count + "; progress: " + progress);
                }
                break;
            case State.Captured:
              

                foreach (CaptureMapAreaCollider mapAreaCollider in mapAreaColliderList)
                {
                    mapAreaCollider.GetComponent<Renderer>().material.color = Color.green;


                }
                break;
        }

      
    }
}
