using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoBehaviour
{
	[Header("ChanPrefabs")]
	public GameObject UnityChanPrefab;
	public GameObject PrototypeChanPrefab;
    public Transform startPos;
	private GameObject ChanPrefab;
    ChanManager _PlayerData;
    // Start is called before the first frame update
    void Start()
    {
        _PlayerData = GameObject.FindWithTag("ChanManager").GetComponent<ChanManager>();
		if (_PlayerData.ChanType == null || _PlayerData.ChanType == "")
		{
			ChanPrefab = UnityChanPrefab;
		}
        if (_PlayerData.ChanType == "UnityChan")
		{
			ChanPrefab = UnityChanPrefab;
		}
		if (_PlayerData.ChanType == "PrototypeChan")
		{
			ChanPrefab = PrototypeChanPrefab;
		}
        Instantiate(ChanPrefab, startPos.position, startPos.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
