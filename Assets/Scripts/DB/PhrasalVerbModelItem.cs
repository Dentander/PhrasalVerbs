using System;
using System.Data;


public class PhrasalVerbModelItem {
    private int _modelId;
    private string _path;

    public PhrasalVerbModelItem(int modelId, string path) {
        _modelId = modelId;
        _path = path;
    }

    public PhrasalVerbModelItem(in IDataReader reader) {
        _modelId = Convert.ToInt32(reader["modelId"]);
        _path = Convert.ToString(reader["path"]);
    }

    public int ModelId {
        get { return _modelId; }
        set { _modelId = value; }
    }
    public string Path {
        get { return _path; }
        set { _path = value; }
    }
}
