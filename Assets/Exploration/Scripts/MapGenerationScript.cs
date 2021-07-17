using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationScript : MonoBehaviour
{
    public GameObject Player;
    public List<List<GameObject>> Nodes;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        GameObject Node = Resources.Load<GameObject>("Prefabs/Node");
        GameObject Line = Resources.Load<GameObject>("Prefabs/Line");

        List<GameObject> curRow = new List<GameObject>();
        curRow.Add(Instantiate(Node, transform.position, transform.rotation, transform));
        GenerateBranch(curRow, 5);
    }

    List<GameObject> GenerateBranch(List<GameObject> curRow, int amount = 3)
    {
        List<GameObject> nextRow = new List<GameObject>();
        GameObject Node = Resources.Load<GameObject>("Prefabs/Node");
        GameObject Line = Resources.Load<GameObject>("Prefabs/Line");

        for (int i = 0; i < amount; i++)
        {
            Vector3 DefNodeVector = new Vector3( (float)-((amount-1) * 3) / 2, 3);

            nextRow.Add(Instantiate(Node, transform.position + new Vector3((float)3 * i, 0) + DefNodeVector, transform.rotation, transform));
            GameObject line = Instantiate(Line, curRow[0].transform);
            line.GetComponent<LineRenderer>().SetPositions(new Vector3[2] { new Vector3(0, 0, -1), new Vector3((float)3 * i, 0) + DefNodeVector });
        } 
        

        return nextRow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
