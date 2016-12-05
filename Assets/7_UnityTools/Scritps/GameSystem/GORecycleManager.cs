using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GORecycleManager : MonoBehaviour
{

    public Queue<GameObject> m_ReadyGO;

    public List<GameObject> m_InUseGO;

    public GameObject m_SourceGO;
    public int m_NumOfCopy = 10;

    // Use this for initialization
    void Start()
    {
        m_ReadyGO = new Queue<GameObject>();

        for (int i = 0; i < m_NumOfCopy; i++)
        {
            GameObject go = (GameObject)Instantiate(m_SourceGO, new Vector3(0f, -100f, 0f), Quaternion.identity);
            go.SetActive(false);
            m_ReadyGO.Enqueue(go);
        }
        /*
        foreach (Transform item in transform) {
            m_ReadyGO.Enqueue( item.gameObject );
            item.parent = null;
        }
		
        foreach (GameObject item in m_ReadyGO) {
            print("in ready queue" + item.name);
        }
        */
    }

    public GameObject GetGO()
    {
        if (m_ReadyGO.Count < 1)
        {
            Debug.LogError("No GO in Queue");
            return null;
        }

        GameObject go = m_ReadyGO.Dequeue();

        m_InUseGO.Add(go);

        // Detatch From parent
        //go.transform.parent = null;
        go.SetActive(true);

        return go;
    }

    public void DontUseGO(GameObject a_GO)
    {
        if (!m_ReadyGO.Contains(a_GO))
        {
            m_ReadyGO.Enqueue(a_GO);
            m_InUseGO.Remove(a_GO);

            //a_GO.transform.parent = gameObject.transform;
            a_GO.SetActive(false);
        }
    }

    public void DontUseAllGOs()
    {
        GameObject[] GOsInUse = new GameObject[m_InUseGO.Count];
        m_InUseGO.CopyTo(GOsInUse);

        for (int i = 0; i < GOsInUse.Length; i++)
        {
            DontUseGO(GOsInUse[i]);
        }
        //foreach (GameObject item in GOsInUse)
        //{
        //	DontUseGO(item);
        //}
    }
}











