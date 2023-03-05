using System;
using System.Data;


public class PhrasalVerbInfoItem {
    private int _verbId;
    private int _modelId;
    private string _verb;
    private string _verbTranslation;

    public PhrasalVerbInfoItem(int verbId, int modelId, string verb, string verbTranslation) {
        _verbId = verbId;
        _modelId = modelId;
        _verb = verb;
        _verbTranslation = verbTranslation;
    }

    public PhrasalVerbInfoItem(in IDataReader reader) {
        _verbId = Convert.ToInt32(reader["verbId"]);
        _modelId = Convert.ToInt32(reader["modelId"]);
        _verb = Convert.ToString(reader["verb"]);
        _verbTranslation = Convert.ToString(reader["verbTranslation"]);
    }

    public int VerbId {
        get { return _verbId; }
        set { _verbId = value; }
    }
    public int ModelId {
        get { return _modelId; }
        set { _modelId = value; }
    }
    public string Verb {
        get { return _verb; }
        set { _verb = value; }
    }
    public string VerbTranslation {
        get { return _verbTranslation; }
        set { _verbTranslation = value; }
    }
}
 
 