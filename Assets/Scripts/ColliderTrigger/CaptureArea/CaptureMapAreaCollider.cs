 using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CaptureMapAreaCollider : MonoBehaviour
{

    [SerializeField] private GameObject box;
    private Renderer boxRenderer;
    private Color boxColor;
    [SerializeField] private CaptureMapArea mapArea;
   

    private void Start()
    {
        boxRenderer = box.GetComponent<Renderer>();
        mapArea = mapArea.GetComponent<CaptureMapArea>();
      
    }
  
    private List<PlayerMapAreas> playerMapAreasList = new List<PlayerMapAreas>();


    private void OnTriggerEnter(Collider collider)
    {
 
        boxColor = Color.yellow;
        
        if (collider.TryGetComponent<PlayerMapAreas>(out PlayerMapAreas playerMapAreas))
        {
            playerMapAreasList.Add(playerMapAreas);
            boxRenderer.material.color = boxColor; 
           
        }
    }
    private void OnTriggerExit(Collider collider)
    {

        boxColor = Color.red;

        if (collider.TryGetComponent<PlayerMapAreas>(out PlayerMapAreas playerMapAreas))
        {
            playerMapAreasList.Remove(playerMapAreas);
            boxRenderer.material.color = boxColor;
        }
    }

    public List<PlayerMapAreas> GetPlayerMapAreasList()
    {
        return playerMapAreasList;
    }

}
