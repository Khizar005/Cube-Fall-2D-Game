using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{

    public float scroll_Speed;
    public string mainTex = "_MainTex";

    private MeshRenderer mesh_Renderer;
    // Start is called before the first frame update
    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        scroll();
    }

    private void scroll()
    {
        Vector2 offSet = mesh_Renderer.sharedMaterial.GetTextureOffset(mainTex);
        offSet.y += Time.deltaTime * scroll_Speed;

        mesh_Renderer.sharedMaterial.SetTextureOffset(mainTex, offSet);
    }
}
