using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    string fileName = "";

    [System.Serializable]

    public class Player
    {
        public string Name;
        public int HighlightAtGaze;
        public int totalTime;
    }
    [System.Serializable]

    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();

    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.dataPath + "/test.csv";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            WriteCSV();
    }

    public void WriteCSV()
    {
        if(myPlayerList.player.Length > 0)
        {
            TextWriter tw = new StreamWriter(fileName, false);
            tw.WriteLine("Name, HighlightAtGaze, totalTime");
            tw.Close();

            tw = new StreamWriter(fileName, true);

            for(int i = 0; i < myPlayerList.player.Length; i++)
            {
                tw.WriteLine(myPlayerList.player[i].Name + "," + myPlayerList.player[i].HighlightAtGaze + "," + myPlayerList.player[i].totalTime);


            }
            tw.Close();
        }
    }
}
