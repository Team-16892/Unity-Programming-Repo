using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null){
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;    
    }
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab; 



    private TurretBlueprint TurretToBuild;

    public bool CanBuild { get { return TurretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= TurretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < TurretToBuild.cost)
        {
            Debug.Log("Not enough money come back later.");
            return;
        }

        PlayerStats.money -= TurretToBuild.cost;
        GameObject Turret = (GameObject)Instantiate(TurretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = Turret;
        Debug.Log("Turret Build. Money left:" + PlayerStats.money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        TurretToBuild = turret;
    }
}
