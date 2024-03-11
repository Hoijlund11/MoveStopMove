using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using System.Collections.Generic;


public class DataManager : Singleton<DataManager>
{
    public void SetLockitem(ItemType type, int id, bool lockitem)
    {
        PlayerPrefs.SetInt($"lockitem{type}_{id}", lockitem ? 1 : 0);
    }
    public bool IsLockItem(ItemType type, int id)
    {     
        return PlayerPrefs.GetInt($"lockitem{type}_{id}",0) == 0 ;    
    }
    
}
