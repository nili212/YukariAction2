using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Jsonデータ管理場
/// </summary>
public class JsonDataManager : MonoBehaviour
{
    public static JsonDataManager instance;

    private string[] jsonDatastr;

    //JsonDataファイルまでのパス
    private string JsonDataPathStr;

    //#region 格納データリスト(JsonDictionaryInit()でのinitializeを忘れないように)
    //public List<WeaponData> weaponListData;
    //public List<EnemyGropuData> enemyGroupListData;
    //public List<ExpTableData> expTableListData;
    //#endregion

    //Jsonのデータを全て入れるDictionary
    public Dictionary<string, object> JsonData;

    void JsonDictionaryInit()
    {
        //weaponListData = new List<WeaponData>();
        //enemyGroupListData = new List<EnemyGropuData>();
        //expTableListData = new List<ExpTableData>();

        JsonData = new Dictionary<string, object>();
        //JsonDataファイルまでのパスを指定
        JsonDataPathStr = Application.dataPath + "/Resources/JsonData";
    }

    void Awake()
    {
        //インスタンス化しておく
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        JsonDictionaryInit();

        //Resources配下にあるJsonDataを読み込んできて、そこからjsonフォルダの数だけデータを取得する
        string[] path_array = Directory.GetFiles(JsonDataPathStr, "*.json", SearchOption.TopDirectoryOnly);
        int array_num = path_array.Length;
        for (int i = 0; i < array_num; i++)
        {
            //パスの指定(Resources.Loadのパス指定に必要)
            string path = Path.GetFileNameWithoutExtension(path_array[i]);
            //ResourcesにあるJsonデータの読み込み
            TextAsset JsonDataTex = Resources.Load("JsonData/" + path) as TextAsset;

            //データ配列化するために分割
            jsonDatastr = JsonDataTex.ToString().Split("|{"[0]);
            //リストに格納
            ListSet(path);
        }
    }

    /// <summary>
    /// Jsonデータをリストに格納する
    /// </summary>
    /// <param name="path">Json名を取ってきて格納するクラスを指定</param>
    void ListSet(string path)
    {
        ////Resources/JsonData内にあるフォルダ名を参照
        //switch (path)
        //{
        //    case "weaponData":
        //        for (int j = 0; j < jsonDatastr.Length; j++)
        //        {
        //            WeaponData data = JsonUtility.FromJson<WeaponData>(jsonDatastr[j]);
        //            weaponListData.Add(data);
        //        }
        //        break;
        //    case "enemyGroupData":
        //        for (int j = 0; j < jsonDatastr.Length; j++)
        //        {
        //            EnemyGropuData data = JsonUtility.FromJson<EnemyGropuData>(jsonDatastr[j]);
        //            enemyGroupListData.Add(data);
        //        }
        //        break;
        //    case "expTableData":
        //        for (int j = 0; j < jsonDatastr.Length; j++)
        //        {
        //            ExpTableData data = JsonUtility.FromJson<ExpTableData>(jsonDatastr[j]);
        //            expTableListData.Add(data);
        //        }
        //        break;
        //    default:
        //        break;
        //}
    }

    #region 経験値関連

    //プレイヤーの現在経験値を渡すとレベルを返す関数
    public int PlayerLevelCheck(int exp)
    {
        //for(int i = 0; i < expTableListData.Count; i++)
        //{
        //    if(exp - expTableListData[i].needExp <= 0)
        //        return expTableListData[i].id;
        //}
        //エラー時-1を通す
        return -1;
    }

    //次の必要経験値確認
    public int PlayerNextExpCheck(int exp)
    {
        //for(int i = 0; i < expTableListData.Count; i++)
        //{
        //    if(expTableListData[i].needExp - exp > 0)
        //    {
        //        return expTableListData[i].needExp - exp;
        //    }
        //}
        //エラー時-1を通す
        return -1;
    }
    #endregion
}
