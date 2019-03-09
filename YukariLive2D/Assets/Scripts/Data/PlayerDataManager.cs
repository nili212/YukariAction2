using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerDataManager : MonoBehaviour {

    public static readonly string playerDataKey = "playerData";

    [SerializeField]
    private int myBuildVersion = 1;

    public static int buildVersion;

    public static PlayerDataManager instance = null;

    public PlayerData playerData = null;

	public bool loadEnd = false;

    void Awake()
    {
        //インスタンス化しておく
        if (instance == null)
        {
            buildVersion = myBuildVersion;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

		#region セーブデータから読み込みを行っていく
		playerDataLoad();
		#endregion
    }

    // Use this for initialization
    void Start () {       
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void playerDataLoad()
    {
        //Jsonから持ってくる
        playerData = SaveData.GetClass<PlayerData>(playerDataKey, new PlayerData());

        //新規プレイヤーまたはバージョンが古い場合
		if (!playerData.SaveFlag || playerData.version < buildVersion) {
			//処理
			playerData = new PlayerData ();
			playerData.SaveDataInit ();
			playerData.SaveFlag = true;
			SaveData.SetClass<PlayerData> (playerDataKey, playerData);
			SaveData.Save ();
		} else {
			Debug.Log ("ロード完了");
		}

		loadEnd = true;
    }
}
