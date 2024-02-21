using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class CreateUnitButton : MonoBehaviour
{
    [SerializeField] private GameObject creator;
    private IUnitCreator unitCreator;



    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            unitCreator.Create();
        });
        
    }

   

    private void OnValidate()
    {
        var c = creator.GetComponent<IUnitCreator>();
        
        if (c == null)
        {
            Debug.LogError("Данный объект не реализует интерфейс IUnitCreator");
            creator = null;
        }

        unitCreator = c as IUnitCreator;
    }
}
