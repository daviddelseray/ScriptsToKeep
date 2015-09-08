using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class ScriptSaveandLoad: MonoBehaviour {

   
    List<string> m_List = new List<string>();

    string m_SaveString;
    string m_File = "SavingFile";

    public Text m_TextField;

	// Use this for initialization
	void Start () {
        //m_TextField.text = (Application.persistentDataPath);
	
	}
	
	public void ListComposing(string String)
    {
        m_List.Add(String);
        Debug.Log(String);
    }

    public void Save()
    {
        foreach(string data in m_List)
        {
            m_SaveString += data + "/";
        }
        File.WriteAllText(Application.persistentDataPath + m_File + ".txt", m_SaveString);
    }

    public void Load()
    {
        StringReader Reader = new StringReader(File.ReadAllText(Application.persistentDataPath + m_File + ".txt"));

        string s = Reader.ReadLine();

        while (s!=null)
        {
            char[] delimiter = { '/' };
            string [] result = s.Split(delimiter);
            m_List.Add(result[0]);

            foreach (string part in result)
            {
                m_TextField.text+=part+"\n";
            }
            

            s = Reader.ReadLine();
        }

    }
}
