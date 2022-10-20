using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Arrow;
    public GameObject RedRaySet;
    public int BatteryRemain;
    public bool isCameraOpen = false;
    private float time = 0;

    public Sprite B100;
    public Sprite B75;
    public Sprite B50;
    public Sprite B25;

    public Image BatteryPic;
    private Renderer[] Rd;
    //public GameObject BatteryObject;
    // Start is called before the first frame update
    void Start()
    {
        BatteryRemain = 100;
        Rd = RedRaySet.GetComponentsInChildren<Renderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab)&&BatteryRemain>0)
        {
            ChangeCamera();
            
        }
        if (isCameraOpen)
        {
            Arrow.SetActive(true);
            for (int i = 0; i < Rd.Length; i++)
            {
                Rd[i].enabled = true;
            }

            time += Time.deltaTime;

            if (time >= 1)
            {
                time = 0;

                UseBattery();
            }
        }
        if (!isCameraOpen)
        {
            Arrow.SetActive(false);
            for (int i = 0; i < Rd.Length; i++)
            {
                Rd[i].enabled = false;
            }
        }
        if (BatteryRemain <= 0)
        {
            Camera.transform.GetComponent<CRTEffect>().enabled = false;
            isCameraOpen = false;
            BatteryPic.enabled = false;
            Arrow.SetActive(false);
        }
        if (0 < BatteryRemain && BatteryRemain <= 25)
        {
            BatteryPic.sprite = B25;
        }
        if (25 < BatteryRemain && BatteryRemain <= 50)
        {
            BatteryPic.sprite = B50;
        }
        if (50 < BatteryRemain && BatteryRemain <= 75)
        {
            BatteryPic.sprite = B75;
        }
        if (75 < BatteryRemain && BatteryRemain <= 100)
        {
            BatteryPic.sprite = B100;
        }

    }
    public void ChangeCamera()
    {
        Debug.Log("?");
        Camera.transform.GetComponent<CRTEffect>().enabled = !Camera.transform.GetComponent<CRTEffect>().enabled;
        isCameraOpen = !isCameraOpen;
        BatteryPic.enabled = !BatteryPic.enabled;
    }
    public void UseBattery()
    {
        if (BatteryRemain > 0)
        {
            BatteryRemain--;
        }
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("RedRay"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
