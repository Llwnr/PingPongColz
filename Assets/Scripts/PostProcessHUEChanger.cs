using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessHUEChanger : MonoBehaviour
{
    private PostProcessVolume ppVolume;
    private Bloom bloom;
    [SerializeField]private float changeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ppVolume = GetComponent<PostProcessVolume>();
        ppVolume.profile.TryGetSettings(out bloom);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeHueInBloom();
    }

    void ChangeHueInBloom(){
        float hue, s, v;
        //Post processing uses color parameter instead of normal unity color property
        ColorParameter colorParameter = new ColorParameter();
        //Get current color and convert it to hsv
        Color.RGBToHSV(bloom.color, out hue, out s, out v);
        //Increase current color slightly
        hue *= 360;
        hue += changeSpeed;
        hue %= 360;
        //Convert it back into rgb and then set it
        Color newColor = Color.HSVToRGB(hue/360f, s, v);
        colorParameter.value = newColor;

        //Update the color of bloom
        bloom.color.Override(colorParameter);
    }
}
