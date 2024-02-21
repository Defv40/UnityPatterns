using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueUnitCreator : MonoBehaviour, IUnitCreator
{
    private GameObject prefab;

    private void Awake()
    {
        prefab = Resources.Load<GameObject>("factory_method/units/BlueUnit");
    }

    public IUnit Create()
    {
        GameObject unit = Instantiate(prefab, transform.position + new Vector3(10, 0, 0), Quaternion.identity);
        return unit.GetComponent<IUnit>();
    }
}
