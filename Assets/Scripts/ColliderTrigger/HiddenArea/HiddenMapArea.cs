using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenMapArea : MonoBehaviour
{

    public enum State
    {
        Neutral,
        Captured,
    }
    private List<HiddenMapAreaCollider> mapAreaColliderList;
    private State state;
    private float progress;

    private void Awake()
    {
        mapAreaColliderList = new List<HiddenMapAreaCollider>();
        foreach (Transform child in transform)
        {
            HiddenMapAreaCollider mapAreaCollider = child.GetComponent<HiddenMapAreaCollider>();
            if (mapAreaCollider != null)
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

                foreach (HiddenMapAreaCollider mapAreaCollider in mapAreaColliderList)
                {
                    foreach (PlayerMapAreas playerMapAreas in mapAreaCollider.GetPlayerMapAreasList())
                    {
                        if (!playerMapAreasInsideList.Contains(playerMapAreas))
                        {
                            playerMapAreasInsideList.Add(playerMapAreas);
                        }
                    }

                }
                float progressSpeed = 2f;
                progress += playerMapAreasInsideList.Count * progressSpeed * Time.deltaTime;

                if (progress >= 1f)
                {
                    state = State.Captured;
                    Debug.Log("Hidden");
                }
                else
                {
                    Debug.Log("PlayerCountInsideMapArea: " + playerMapAreasInsideList.Count + "; progress: " + progress);
                }
                break;
            case State.Captured:


                foreach (HiddenMapAreaCollider mapAreaCollider in mapAreaColliderList)
                {
                   
                    mapAreaCollider.gameObject.SetActive(false);

                }
                break;
        }


    }
}
