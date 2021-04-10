using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color HoverColor;
    public Color NotEnoughtMoneyColor;
    public Vector3 positionOffset;
    
    
    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color StartColor;

    

    BuildManager buildManager;

    //Intializing the color
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;

        buildManager = BuildManager.instance;
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset; 
    }
     // Displaying if something was built or not on the node/tile
     void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if(turret != null)
        {
            Debug.Log("Something is already here");
            return;
        }

        buildManager.BuildTurretOn(this);
    }
    // Basically when the mouse hovers change the color to whatever we sent in the inspector
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if(buildManager.HasMoney)
        {
            rend.material.color = HoverColor;
        }
        else
        {
            rend.material.color = NotEnoughtMoneyColor;
        }
        
    } 
    //Setting the color back to the color it was.
     void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
}
