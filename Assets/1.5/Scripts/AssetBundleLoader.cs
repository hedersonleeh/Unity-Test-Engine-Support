using UnityEngine;

public class AssetBundleLoader : MonoBehaviour
{
    void Start()
    {
        var pathCube1Bundle = Application.streamingAssetsPath + "/cube/" + "1";
        var pathCube2Bundle = Application.streamingAssetsPath + "/cube/" + "2";
        var pathMaterialBundle = Application.streamingAssetsPath + "/material/" + "cubes";

        var cubeBundle1 = AssetBundle.LoadFromFile(pathCube1Bundle);
        var cubeBundle2 = AssetBundle.LoadFromFile(pathCube2Bundle);
        var MaterialBundle = AssetBundle.LoadFromFile(pathMaterialBundle);

        MaterialBundle.LoadAllAssets<Material>();
        Debug.Log("Loaded Material bundle:" + MaterialBundle.name);
        var gObjs1 = cubeBundle1.LoadAllAssets<GameObject>();
        Debug.Log("Loaded Cube1 bundle:" + cubeBundle1.name);
        var gObjs2 = cubeBundle2.LoadAllAssets<GameObject>();
        Debug.Log("Loaded Cube2 bundle:" + cubeBundle2.name);

        foreach (var gO in gObjs1)
        {
            var obj = Instantiate(gO);
            obj.transform.position = Vector3.right;
        }
        foreach (var gO in gObjs2)
        {
            var obj = Instantiate(gO);
            obj.transform.position = Vector3.left;

        }
    }

}
