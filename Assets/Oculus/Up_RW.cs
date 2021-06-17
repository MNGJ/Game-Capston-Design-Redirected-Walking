using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_RW : MonoBehaviour
{
    public GameObject cameraRig;
    public GameObject worldMap;
    public GameObject piVot;
    public GameObject vrplayer;
    public GameObject tmp1;
    public GameObject goal;
    public GameObject meshCenter;
    Transform cameraRig_Rota;
    bool isRotate = true;
    float degree;
    public float rotateSpeed = 1f;
    float weight_Pos_Speed = 1f;
    int div_x, div_z;
    bool set_complete = false;
    Vector3 newRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(cameraRig.transform.eulerAngles.x);
        piVot.transform.position = vrplayer.transform.position;
        degree = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cameraRig.transform.rotation.eulerAngles.x);
        //Debug.Log(worldMap.transform.eulerAngles.y);
        //Debug.Log(vrplayer.transform.eulerAngles.y);
        //Debug.Log(cameraRig.transform.eulerAngles.y);
        piVot.transform.position = cameraRig.transform.position;
        if(cameraRig.transform.eulerAngles.x <= 310 && cameraRig.transform.eulerAngles.x >= 270)
        {
            //if (GameObject.Find("MeshRig").GetComponent<MeshCreator>().Cal_Distance_Goal() == true) // ÅöÅö ¸ØÃß´Â ¿À·ù
                //return;

            if (set_complete == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (MeshCreator.mesh_Div[i, j].x > Pivot_Center.player_local_position_x && MeshCreator.mesh_Div[i + 1, j].x < Pivot_Center.player_local_position_x && MeshCreator.mesh_Div[i, j].z > Pivot_Center.player_local_position_z && MeshCreator.mesh_Div[i, j + 1].z < Pivot_Center.player_local_position_z)
                        {
                            Debug.Log("mesh_div[i, j].x = " + MeshCreator.mesh_Div[i, j].x);
                            Debug.Log("mesh_div[i+1, j].x = " + MeshCreator.mesh_Div[i + 1, j].x);
                            Debug.Log("mesh_div[i, j].z = " + MeshCreator.mesh_Div[i, j].z);
                            Debug.Log("mesh_div[i+1, j].z = " + MeshCreator.mesh_Div[i, j + 1].z);
                            Debug.Log("mesh_div[0, 0].x = " + MeshCreator.mesh_Div[0, 0].x);
                            Debug.Log("mesh_div[9, 9].x = " + MeshCreator.mesh_Div[9, 9].x);
                            Debug.Log("x = " + i);
                            Debug.Log("z = " + j);
                            if (i == 8 || j == 8 || i == 0 || j == 0)
                            {
                                weight_Pos_Speed = 1.8f;
                                GameObject.Find("UIManager").GetComponent<UIManager>().Mesh_Div_Text(i, j, weight_Pos_Speed);
                                goto EXIT;
                            }
                            else if (i == 7 || j == 7 || i == 1 || j == 1)
                            {
                                weight_Pos_Speed = 1.5f;
                                GameObject.Find("UIManager").GetComponent<UIManager>().Mesh_Div_Text(i, j, weight_Pos_Speed);
                                goto EXIT;
                            }
                            else if (i == 6 || j == 6 || i == 2 || j == 2)
                            {
                                weight_Pos_Speed = 1.3f;
                                GameObject.Find("UIManager").GetComponent<UIManager>().Mesh_Div_Text(i, j, weight_Pos_Speed);
                                goto EXIT;
                            }
                            else
                            {
                                weight_Pos_Speed = 1f;
                                GameObject.Find("UIManager").GetComponent<UIManager>().Mesh_Div_Text(i, j, weight_Pos_Speed);
                                goto EXIT;
                            }
                        }
                        else if (MeshCreator.mesh_Div[0, 0].x < Pivot_Center.player_local_position_x || MeshCreator.mesh_Div[0, 0].z < Pivot_Center.player_local_position_z || MeshCreator.mesh_Div[9, 9].x > Pivot_Center.player_local_position_x || MeshCreator.mesh_Div[9, 9].z > Pivot_Center.player_local_position_z)
                        {
                            weight_Pos_Speed = 2.3f;
                            GameObject.Find("UIManager").GetComponent<UIManager>().Mesh_Div_Text(i, j, weight_Pos_Speed);
                            goto EXIT;
                        }
                    }
            }
            EXIT:
            set_complete = true;
            Debug.Log("weigth_Speed = " + weight_Pos_Speed);

            //if (isRotate)
                //return;
            if (degree == 0)
                degree = 180;
            else
                degree = 0;
            if(!isRotate)
            {

                Quaternion originalRot = vrplayer.transform.rotation;
                Vector3 originalRotVec3 = originalRot.eulerAngles;
                newRotation = originalRotVec3 + new Vector3(0, 180, 0);

                //Vector3 v = new Vector3(0, goal.transform.position.y - vrplayer.transform.position.y, 0);
                //newRotation = new Vector3(0, 180 + Quaternion.LookRotation(v).eulerAngles.y , 0);
            }
            rotateSpeed = (Mathf.Abs(cameraRig.transform.eulerAngles.x - 310)) / 100f;
            worldMap.transform.parent = piVot.transform;
            //Debug.Log("rotateSpeed" + rotateSpeed);
            //vrplayer.transform.Rotate(cameraRig.transform.position, 180.0f);
            //vrplayer.transform.rotation = Quaternion.Lerp(vrplayer.transform.rotation, Quaternion.LookRotation(, Time.deltaTime * (1 / rotateSpeed));
            tmp1.transform.rotation = Quaternion.Lerp(tmp1.transform.rotation, Quaternion.Euler(newRotation), Time.deltaTime * (rotateSpeed) * weight_Pos_Speed);
            //vrplayer.transform.Rotate(new Vector3(0, 180, 0));
            //RenderSettings.skybox.SetFloat("_Rotation", cameraRig.transform.eulerAngles.y);
            //piVot.transform.Rotate(new Vector3(0, 180, 0));
            //StartCoroutine("RunRotate");
            isRotate = true;
        }
        else
        {
            worldMap.transform.parent = null;
            isRotate = false;
            set_complete = false;
            GameObject.Find("MeshRig").GetComponent<MeshCreator>().Set_MeshCenter();
        }
    }
    IEnumerator RunRotate()
    {
        yield return new WaitForSeconds(0.1f);
        piVot.transform.Rotate(new Vector3(0, 180, 0));
    }
}
