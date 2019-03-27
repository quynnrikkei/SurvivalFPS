using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitManager : MonoBehaviour {

    public static MedkitManager instance;

    [SerializeField]
    private GameObject Medkit_Prefab;

    public Transform[] Medkit_SpawnPoints;

    private int Medkit_Count;

    private int initial_Medkit_Count;

    //public float wait_Start_Medkit = 10f;

    private void Awake()
    {
        MakeInstance();
    }

    // Use this for initialization
    void Start () {
        initial_Medkit_Count = Medkit_Count;
        SpawnMedkit();
	}

    private void SpawnMedkit()
    {
        int index = 0;
        for(int i = 0; i < Medkit_Count; i++)
        {
            if(index >= Medkit_SpawnPoints.Length)
            {
                index = 0;
            }
            Instantiate(Medkit_Prefab, Medkit_SpawnPoints[index].position, Quaternion.identity);

            index++;
        }
        Medkit_Count = 0;
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
