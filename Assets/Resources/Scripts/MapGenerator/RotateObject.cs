using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 100;
    [SerializeField] private float scale;
    private float mouseXValue;
    private float mouseYValue;
    private bool isEnableRotation;

    void Update()
    {
        if (isEnableRotation)
        {
            if (Input.GetMouseButton(0))
            {
                ChangeObjectScale(scale);
                RoundMouseXValue();
                transform.Rotate(new Vector3(0, mouseXValue, 0) * Time.deltaTime * rotateSpeed);
            }
            else
            {
                ChangeObjectScale(1);
            }
        }
    }

    public void EnableRotation()
    {
        isEnableRotation = true;
    }
    public void DisableRotation()
    {
        isEnableRotation = false;
    }

    void ChangeObjectScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void RoundMouseXValue()
    {
        if(Input.GetAxis("Mouse X") > 0f)
        {
            mouseXValue = 1;
        }
        else if (Input.GetAxis("Mouse X") < 0f)
        {
            mouseXValue = -1;
        }
        else
        {
            mouseXValue = 0;
        }
    }
    void RoundMouseYValue()
    {
        if (Input.GetAxis("Mouse Y") > 0f)
        {
            mouseYValue = 1;
        }
        else if (Input.GetAxis("Mouse Y") < -0f)
        {
            mouseYValue = -1;
        }
        else
        {
            mouseYValue = 0;
        }
    }
}
