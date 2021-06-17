using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text angle_X;
    private Text station_Position_X;
    private Text station_Position_Z;
    private Text world_Position_X;
    private Text world_Position_Z;
    private Text local_Position_X;
    private Text local_Position_Z;
    private Text set_Mesh;
    public GameObject cameraRig;
    public GameObject station_Position;
    public GameObject player_WorldPos;
    public GameObject player_localPos;
    public Text scoreText;
    public Text mesh_div;
    public GameObject intro_text;
    public static int score;
    

    // Start is called before the first frame update
    void Start()
    {
        angle_X = GameObject.Find("Angle_X").GetComponent<Text>();
        station_Position_X = GameObject.Find("Station_X").GetComponent<Text>();
        station_Position_Z = GameObject.Find("Station_Z").GetComponent<Text>();
        world_Position_X = GameObject.Find("World_X").GetComponent<Text>();
        world_Position_Z = GameObject.Find("World_Z").GetComponent<Text>();
        local_Position_X = GameObject.Find("Local_X").GetComponent<Text>();
        local_Position_Z = GameObject.Find("Local_Z").GetComponent<Text>();
        set_Mesh = GameObject.Find("Set_Mesh").GetComponent<Text>();
        mesh_div = GameObject.Find("Mesh_Div").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        angle_X.text = "Angle : " + cameraRig.transform.eulerAngles.x;
        station_Position_X.text = "X : " + station_Position.transform.position.x;
        station_Position_Z.text = "Z : " + station_Position.transform.position.z;
        world_Position_X.text = "X : " + player_WorldPos.transform.position.x;
        world_Position_Z.text = "Z : " + player_WorldPos.transform.position.z;
        local_Position_X.text = "X : " + player_localPos.transform.localPosition.x;
        local_Position_Z.text = "Z : " + player_localPos.transform.localPosition.z;
        scoreText.text = "Score : " + score;
        
    }
    
    public void Set_Mesh()
    {
        set_Mesh.text = "Set Mesh : On";
    }

    public void Mesh_Div_Text(int x, int y, float speed)
    {
        mesh_div.text = "Weight Index [x, y] : " + x  + ", " + y + "\nWeight Speed : " + speed;
    }
    public void Set_Active_IntroText()
    {
        intro_text.SetActive(false);
    }
}
