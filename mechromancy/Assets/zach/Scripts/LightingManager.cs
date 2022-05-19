using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class LightingManager : MonoBehaviour
{
    //references
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;

    //variables
    [SerializeField, Range(0, 24)] public static float TimeOfDay;

    public float clock;
    public float rate;

    private void Start()
    {
        //TimeOfDay = 15f;    
    }

    private void Update()
    {
        clock = TimeOfDay;

        if(Preset == null)
        return;

        if(Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime * rate;
            TimeOfDay %= 24; //clamp between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0f));
        }
    }

    private void OnValidate()
    {
        if(DirectionalLight != null)
        return;

        if(RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

}
