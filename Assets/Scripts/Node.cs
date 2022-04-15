using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject turret;


    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Turret already build. Can't build more! - TODO: Display on screen.");
            return;
        }
        
        // TODO: Build a turret
        GameObject turretToBuiltd = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuiltd, transform.position + positionOffset, transform.rotation);

    }
    private void OnMouseEnter()
    {
       rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
