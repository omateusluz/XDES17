using UnityEngine;

public class DeslocamentoBG : MonoBehaviour
{
    private Renderer objetoRender;
    private Material obejtoMaterial;
    public float offset;//deslocamento
    public float offsetIncremento;
    public float offsetVelocidade;

    public string sortingLayer;
    public int    orderinLayer;


void Start()
{
    objetoRender = GetComponent<MeshRenderer>();

    objetoRender.sortingLayerName = sortingLayer;
    objetoRender.sortingOrder = orderinLayer;


    obejtoMaterial = objetoRender.material;
}

void Update()
{
    offset += offsetIncremento;
    obejtoMaterial.SetTextureOffset("_MainTex", new Vector2(offset * offsetVelocidade, 0));
}
}