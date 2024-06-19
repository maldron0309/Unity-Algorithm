using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour
{
    // ArrayList
    // Hashtable
    // Stack
    // Queue

    void Start()
    {
        ArrayList();
        Hashtable();
    }

#region ArrayList
    void ArrayList()
    {
        ArrayList list = new ArrayList();
        list.Add("Hello");
        list.Add(6);
        list.Add("Word");
        list.Add(true);

        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.Insert(1, 15);

        list.Remove(0);

        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
    }
#endregion

#region Hashtable

    void Hashtable()
    {
        Hashtable table = new Hashtable();
        table["Book"] = "책";
        table["Cook"] = "요리";
        table["Wind"] = "바람";
        table[1.5f] = 15;

        Debug.Log(table["Book"]);
        Debug.Log(table["Cook"]);
        Debug.Log(table["Wind"]);
        Debug.Log(1.5f);
    }

#endregion


}
