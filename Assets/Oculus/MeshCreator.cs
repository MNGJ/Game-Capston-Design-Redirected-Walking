using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{

    Vector3[] vertices = new Vector3[] {new Vector3(-0.1f, 0f, -0.1f), new Vector3(0.1f, 0f, -0.1f),
                                        new Vector3(0.1f, 0f, 0.1f), new Vector3(-0.1f, 0f, 0.1f) };
    int[] triangles = new int[] { 0, 2, 1,
                                 0, 3, 2};
    Mesh mesh;

    public static Vector3[,] mesh_Div = new Vector3[10, 10];

    public GameObject meshCenter;
    public GameObject meshCenter2;
    public GameObject playerController;
    public GameObject goal;

    public GameObject player_localPos;
    float local_x = 0f, local_z = 0f;
    float max_x = 0f, max_z = 0f, min_x = 0f, min_z = 0f;

    public bool isSetMesh = false;
    public bool test = false;

    void Start()
    {
        mesh = new Mesh();
        
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        GetComponent<MeshFilter>().mesh = mesh;

        //Material material = new Material(Shader.Find("Standard"));
        //GetComponent<MeshRenderer>().material = material;
    }

    void Update()
    {
        if (isSetMesh == true)
            return;
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstick) && isSetMesh == false) //OVRInput.Get(OVRInput.Button.PrimaryThumbstick) 오큘러스 사용시 | test == true : PC로 테스트할 때
        {
            for (int i = 0; i < 10; i++)
            {
                float row = max_x - ((max_x - min_x)*0.1f*(i+1) - (max_x - min_x)*0.05f);
                for (int j = 0; j < 10; j++)
                {
                    float col = max_z - ((max_z - min_z) * 0.1f * (j + 1) - (max_z - min_z) * 0.05f);
                    mesh_Div[i, j] = new Vector3(row, 0f, col);
                    Debug.Log("["+i+", "+j+"] = " + mesh_Div[i,j]);
                }
            }
            GameObject.Find("UIManager").GetComponent<UIManager>().Set_Mesh();
            //meshCenter.transform.position = new Vector3(this.transform.position.x + mesh_Div[0,0].x - (mesh_Div[0,0].x - mesh_Div[9,9].x)/2, player_localPos.transform.position.y, this.transform.position.z + mesh_Div[0,0].z - (mesh_Div[0,0].z - mesh_Div[9,9].z)/2);
            meshCenter.transform.position = new Vector3(this.transform.position.x, player_localPos.transform.position.y, this.transform.position.z);
            //meshCenter2.transform.position = new Vector3(this.transform.position.x + mesh_Div[0, 0].x - (mesh_Div[0, 0].x - mesh_Div[9, 9].x) / 2, player_localPos.transform.position.y, this.transform.position.z + mesh_Div[0, 0].z - (mesh_Div[0, 0].z - mesh_Div[9, 9].z) / 2);
            //meshCenter2.transform.parent = GameObject.Find("Tmp1").transform;

            GameObject.Find("UIManager").GetComponent<UIManager>().Set_Active_IntroText();

            isSetMesh = true;
        }
        //Debug.Log("Local_x")
        local_x = player_localPos.transform.localPosition.x;
        local_z = player_localPos.transform.localPosition.z;

        if (local_x >= max_x)
            max_x = local_x;

        if (local_x <= min_x)
            min_x = local_x;

        if (local_z >= max_z)
            max_z = local_z;

        if (local_z <= min_z)
            min_z = local_z;

        //if(local_x < 0 && local_z > 0)

        //Debug.Log(vertices[0]);
        vertices[0] = new Vector3(min_x, 0f, min_z); ;
        vertices[1] = new Vector3(max_x , 0f, min_z );
        vertices[2] = new Vector3(max_x , 0f, max_z );
        vertices[3] = new Vector3(min_x , 0f, max_z );
        mesh.vertices = vertices;

        GetComponent<MeshFilter>().mesh = mesh;
    }

    public bool Cal_Distance_Goal()
    {
        if (Vector3.Distance(goal.transform.position, player_localPos.transform.position) > Vector3.Distance(goal.transform.position, meshCenter.transform.position))
            return true;
        else
            return false;
    }

    public void Set_MeshCenter()
    {
        meshCenter.transform.rotation = GameObject.Find("Tmp1").transform.rotation;
        meshCenter.transform.position = new Vector3(this.transform.position.x + mesh_Div[0, 0].x - (mesh_Div[0, 0].x - mesh_Div[9, 9].x) / 2, player_localPos.transform.position.y, this.transform.position.z + mesh_Div[0, 0].z - (mesh_Div[0, 0].z - mesh_Div[9, 9].z) / 2);
        //meshCenter.transform.position = meshCenter2.transform.position;
    }

}
