using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mono.Data.Sqlite;
//using System.Data;


public class PhrasalVerbsDB : MonoBehaviour {
    private static GameObject _instance=null;

    private GameObject _chosenPhrasalVerbPrefab;
    private string _chosenPhrasalVerbName;
    private string _chosenPhrasalVerbTranslation;

    public GameObject ChosenPhrasalVerbPrefab {
        get { return _chosenPhrasalVerbPrefab; }
        set { _chosenPhrasalVerbPrefab = value; }
    }
    public string ChosenPhrasalVerbName {
        get { return _chosenPhrasalVerbName; }
        set { _chosenPhrasalVerbName = value; }
    }
    public string ChosenPhrasalVerbTranslation {
        get { return _chosenPhrasalVerbTranslation; }
        set { _chosenPhrasalVerbTranslation = value; }
    }

    private void Start() {
        if (_instance == null) {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }

        //IDbConnection dbConnection = CreateAndOpenDatabase();
    }

    static public GameObject GetInstance() {
        return _instance;
    }

    static public PhrasalVerbsDB GetInstanceComponent() {
        return _instance.GetComponent<PhrasalVerbsDB>();
    }

 /*   private IDbConnection CreateAndOpenDatabase() {
        string dbUri = "URI=file:PhrasalVerbs.sqlite"; 
        IDbConnection dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open(); 

        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand();
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS HitCountTableSimple (id INTEGER PRIMARY KEY, hits INTEGER )"; // 7
        dbCommandCreateTable.ExecuteReader();

        return dbConnection;
    }*/
}
