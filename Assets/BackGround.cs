using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform mainCam;
    public Transform midBg;
    public Transform sideBg;
    public float length;
    // Update is called once per frame
    void Update()
    {
        if (mainCam.position.x > midBg.position.x)
        {
            UpdateBackGroundPosition(Vector3.right);
        }
        else if (mainCam.position.x < midBg.position.x)
        {
            UpdateBackGroundPosition(Vector3.left);
        }
    }
    void UpdateBackGroundPosition(Vector3 direction)
    {
        sideBg.position = midBg.position + direction * length;
        Transform temp = midBg;
        midBg = sideBg;
        sideBg=temp;
    }
}
