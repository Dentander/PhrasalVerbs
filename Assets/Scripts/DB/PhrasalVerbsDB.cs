using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System;


[Serializable]
public struct InterpreterItem {
    public string path;
    public GameObject verb;
}


public class PhrasalVerbsDB : MonoBehaviour {
    [SerializeField] private List<InterpreterItem> _phrasalVerbModelInterpreterToConvert;

    private Dictionary<string, GameObject> _phrasalVerbModelInterpreter=new();

    private PhrasalVerbInfoItem _chosenPhrasalVerbInfoItem;
    private PhrasalVerbModelItem _chosenPhrasalVerbMoelItem;
    private List<PhrasalVerbInfoItem> _phrasalVerbInfoItems = new();
    private Dictionary<int, PhrasalVerbModelItem> _phrasalVerbModelItems = new();

    private string _dbName = "PhrasalVerbs.sqlite";
    private IDbConnection _connection;

    public string ChosenPhrasalVerbName {
        get { return _chosenPhrasalVerbInfoItem.Verb; }
    }
    public string ChosenPhrasalVerbTranslation {
        get { return _chosenPhrasalVerbInfoItem.VerbTranslation; }
    }
    public GameObject ChosenPhrasalVerbModel {
        get { return _phrasalVerbModelInterpreter[_chosenPhrasalVerbMoelItem.Path]; }
    }
    public PhrasalVerbInfoItem ChosenPhrasalVerbItem {
        get { return _chosenPhrasalVerbInfoItem; }
        set { 
            _chosenPhrasalVerbInfoItem = value;
            _chosenPhrasalVerbMoelItem = _phrasalVerbModelItems[_chosenPhrasalVerbInfoItem.VerbId];
        }
    }
    public List<PhrasalVerbInfoItem> PhrasalVerbInfoItems {
        get { return _phrasalVerbInfoItems; }
    }

    private string GetPath() {
        string path = "";
#if UNITY_EDITOR
        path = Application.dataPath + "\\StreamingAssets" + "/" + _dbName;
        Debug.Log("Windows Mode");

#elif UNITY_ANDROID
        path = Application.persistentDataPath + "/" + _dbName; 
        Debug.Log("Android Mode");
#endif
        return path;
    }

    private void Awake() {
        // ============ SINGLETON ==========
        if (_instance == null) {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
        else {
            Destroy(gameObject);
        }

        // ========== PREPARE AND READ DATABASE ==========
        StartCoroutine(PrepareDatabase(_dbName));

        ConvertInterpreter();
        OpenDatabase();
        ReadPhrasalVerbInfo();
        ReadPhrasalVerbModel();
    }

    private void ConvertInterpreter() {
        foreach (var item in _phrasalVerbModelInterpreterToConvert) {
            _phrasalVerbModelInterpreter[item.path] = item.verb;
        }
    }

    private IEnumerator PrepareDatabase(string databaseName) {
        try { 
            string path = Application.streamingAssetsPath + "/" + databaseName;
            UnityWebRequest unityWebRequest = UnityWebRequest.Get(path);
            yield return unityWebRequest.SendWebRequest();

            while (!unityWebRequest.isDone) { }

            byte[] data = unityWebRequest.downloadHandler.data;
            File.WriteAllBytes(Application.persistentDataPath + "/" + _dbName, data);
        } finally { }
    }
    private void OpenDatabase() {
        _connection = new SqliteConnection("URI=file:" + GetPath());
        _connection.Open(); 
    }
    private void ReadPhrasalVerbInfo() {
        IDbCommand command = _connection.CreateCommand();
        command.CommandText = "SELECT * FROM PhrasalVerbInfo ORDER BY verbId";
        IDataReader reader = command.ExecuteReader();

        while (reader.Read()) {
            PhrasalVerbInfoItem item = new(reader);
            _phrasalVerbInfoItems.Add(item);
        }
    }
    private void ReadPhrasalVerbModel() {
        IDbCommand command = _connection.CreateCommand();
        command.CommandText = "SELECT * FROM PhrasalVerbModel ORDER BY modelId";
        IDataReader reader = command.ExecuteReader();

        while (reader.Read()) {
            PhrasalVerbModelItem item = new(reader);
            _phrasalVerbModelItems[item.ModelId] = item;
        }
    }

    // ========== STATIC ========
    protected static GameObject _instance = null;

    static public GameObject GetInstance() {
        return _instance;
    }
    static public PhrasalVerbsDB GetInstanceComponent() {
        return _instance.GetComponent<PhrasalVerbsDB>();
    }
}
