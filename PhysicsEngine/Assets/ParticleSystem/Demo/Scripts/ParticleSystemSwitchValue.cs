using UnityEngine;
using UnityEngine.UI;

public class ParticleSystemSwitchValue : MonoBehaviour
{
    // 创建粒子系统对象
    ParticleSystem ps;
    [Tooltip("修改属性 Dropdown")]
    public Dropdown dropdown;
    public Dropdown velocityOverLifetimeSpaceDropdown;
    public Dropdown colorOverLifetime1Dropdown;
    public Dropdown colorOverLifetime2Dropdown;
    [Tooltip("网格")]
    public Mesh mesh;
    // 所要检验数字的输入游戏对象数组
    private GameObject[] inputFieldGameObjects;
    [Tooltip("Emission 面板")]
    public GameObject emissionPanel;
    [Tooltip("velocityOverLifetime 面板")]
    public GameObject velocityOverLifetimePanel;
    [Tooltip("sizeBySpeed 面板")]
    public GameObject sizeBySpeedPanel;
    [Tooltip("colorOverLifetime 面板")]
    public GameObject colorOverLifetimePanel;
    [Tooltip("forceOverLifetime 面板")]
    public GameObject forceOverLifetimePanel;

    private void Awake()
    {
        InitInputField();
        Debug.Log(emissionPanel);
        emissionPanel.SetActive(false);
        velocityOverLifetimePanel.SetActive(false);
        colorOverLifetimePanel.SetActive(false);
        forceOverLifetimePanel.SetActive(false);
        sizeBySpeedPanel.SetActive(false);
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!Constants.selected.Equals(dropdown.options[dropdown.value].text))
        {
            Constants.selected = dropdown.options[dropdown.value].text;
            ValueSetting(Constants.selected);
        }
    }
    private void InitInputField()
    {
        // 只能输入数字
        inputFieldGameObjects = GameObject.FindGameObjectsWithTag("InputField");
        for (int i = 0; i < inputFieldGameObjects.Length; i++)
        {
            inputFieldGameObjects[i].GetComponent<InputField>().characterValidation = InputField.CharacterValidation.Decimal;
        }
    }
    public void GetEmissionInput()
    {
        GameObject rateGameObject = GameObject.Find("Canvas/Panel/Emission/InputField");
        float rate = float.Parse(rateGameObject.GetComponent<InputField>().text);

        GameObject timeGameObject = GameObject.Find("Canvas/Panel/Emission/Bursts/InputFieldTime");
        GameObject minObject = GameObject.Find("Canvas/Panel/Emission/Bursts/InputFieldMin");
        GameObject maxGameObject = GameObject.Find("Canvas/Panel/Emission/Bursts/InputFieldMax");
        float time = float.Parse(timeGameObject.GetComponent<InputField>().text);
        short min = short.Parse(minObject.GetComponent<InputField>().text);
        short max = short.Parse(maxGameObject.GetComponent<InputField>().text);

        GameObject time2GameObject = GameObject.Find("Canvas/Panel/Emission/Bursts/InputFieldTime2");
        GameObject min2GameObject = GameObject.Find("Canvas/Panel/Emission/Bursts/InputFieldMin2");
        GameObject max2GameObject = GameObject.Find("Canvas/Panel/Emission/Bursts/InputFieldMax2");
        float time2 = float.Parse(time2GameObject.GetComponent<InputField>().text);
        short min2 = short.Parse(min2GameObject.GetComponent<InputField>().text);
        short max2 = short.Parse(max2GameObject.GetComponent<InputField>().text);
        Emission(rate, time, min, max, time2, min2, max2);
    }
    public void GetVelocityOverLifetimeInput()
    {
        GameObject key1GameObject = GameObject.Find("Canvas/Panel/VelocityOverLifetime/InputFieldKey1");
        float key1 = float.Parse(key1GameObject.GetComponent<InputField>().text);
        GameObject key2GameObject = GameObject.Find("Canvas/Panel/VelocityOverLifetime/InputFieldKey2");
        float key2 = float.Parse(key2GameObject.GetComponent<InputField>().text);
        GameObject key3GameObject = GameObject.Find("Canvas/Panel/VelocityOverLifetime/InputFieldKey3");
        float key3 = float.Parse(key3GameObject.GetComponent<InputField>().text);
        GameObject key4GameObject = GameObject.Find("Canvas/Panel/VelocityOverLifetime/InputFieldKey4");
        float key4 = float.Parse(key4GameObject.GetComponent<InputField>().text);

        string s = velocityOverLifetimeSpaceDropdown.options[velocityOverLifetimeSpaceDropdown.value].text;

        VelocityOverLifetime(key1, key2, key3, key4, s);
    }
    public void GetSizeBySpeedInput()
    {
        GameObject key1GameObject = GameObject.Find("Canvas/Panel/SizeBySpeed/InputFieldKey1");
        float key1 = float.Parse(key1GameObject.GetComponent<InputField>().text);
        GameObject key2GameObject = GameObject.Find("Canvas/Panel/SizeBySpeed/InputFieldKey2");
        float key2 = float.Parse(key2GameObject.GetComponent<InputField>().text);
        GameObject key3GameObject = GameObject.Find("Canvas/Panel/SizeBySpeed/InputFieldKey3");
        float key3 = float.Parse(key3GameObject.GetComponent<InputField>().text);
        GameObject key4GameObject = GameObject.Find("Canvas/Panel/SizeBySpeed/InputFieldKey4");
        float key4 = float.Parse(key4GameObject.GetComponent<InputField>().text);
        GameObject key5GameObject = GameObject.Find("Canvas/Panel/SizeBySpeed/InputFieldKey5");
        float key5 = float.Parse(key5GameObject.GetComponent<InputField>().text);
        GameObject key6GameObject = GameObject.Find("Canvas/Panel/SizeBySpeed/InputFieldKey6");
        float key6 = float.Parse(key6GameObject.GetComponent<InputField>().text);
        SizeBySpeed(key1, key2, key3, key4, key5, key6);
    }
    public void GetColorOverLifeTimeInput()
    {
        GameObject key1GameObject = GameObject.Find("Canvas/Panel/ColorOverLifeTime/InputFieldKey1");
        float key1 = float.Parse(key1GameObject.GetComponent<InputField>().text);
        GameObject key2GameObject = GameObject.Find("Canvas/Panel/ColorOverLifeTime/InputFieldKey2");
        float key2 = float.Parse(key2GameObject.GetComponent<InputField>().text);
        GameObject key3GameObject = GameObject.Find("Canvas/Panel/ColorOverLifeTime/InputFieldKey3");
        float key3 = float.Parse(key3GameObject.GetComponent<InputField>().text);
        GameObject key4GameObject = GameObject.Find("Canvas/Panel/ColorOverLifeTime/InputFieldKey4");
        float key4 = float.Parse(key4GameObject.GetComponent<InputField>().text);
        GameObject key5GameObject = GameObject.Find("Canvas/Panel/ColorOverLifeTime/InputFieldKey5");
        float key5 = float.Parse(key5GameObject.GetComponent<InputField>().text);
        GameObject key6GameObject = GameObject.Find("Canvas/Panel/ColorOverLifeTime/InputFieldKey6");
        float key6 = float.Parse(key6GameObject.GetComponent<InputField>().text);

        string s1 = colorOverLifetime1Dropdown.options[colorOverLifetime1Dropdown.value].text;
        string s2 = colorOverLifetime2Dropdown.options[colorOverLifetime2Dropdown.value].text;

        ColorOverLifetime(s1, s2, key1, key2, key3, key4, key5, key6);
    }
    public void GetForceOverLifetimeInput()
    {
        GameObject key1GameObject = GameObject.Find("Canvas/Panel/ForceOverLifetime/InputFieldKey1");
        float key1 = float.Parse(key1GameObject.GetComponent<InputField>().text);
        GameObject key2GameObject = GameObject.Find("Canvas/Panel/ForceOverLifetime/InputFieldKey2");
        float key2 = float.Parse(key2GameObject.GetComponent<InputField>().text);
        GameObject key3GameObject = GameObject.Find("Canvas/Panel/ForceOverLifetime/InputFieldKey3");
        float key3 = float.Parse(key3GameObject.GetComponent<InputField>().text);
        GameObject key4GameObject = GameObject.Find("Canvas/Panel/ForceOverLifetime/InputFieldKey4");
        float key4 = float.Parse(key4GameObject.GetComponent<InputField>().text);
        ForceOverLifetime(key1, key2, key3, key4);
    }
    private void HideAllPanel()
    {
        emissionPanel.SetActive(false);
        velocityOverLifetimePanel.SetActive(false);
        colorOverLifetimePanel.SetActive(false);
        forceOverLifetimePanel.SetActive(false);
        sizeBySpeedPanel.SetActive(false);
    }
    private void ValueSetting(string value)
    {
        switch (value)
        {
            case "喷射":
                HideAllPanel();
                emissionPanel.SetActive(true);
                break;
            case "速度":
                HideAllPanel();
                velocityOverLifetimePanel.SetActive(true);
                break;
            case "作用力":
                HideAllPanel();
                forceOverLifetimePanel.SetActive(true);
                break;
            case "颜色":
                HideAllPanel();
                colorOverLifetimePanel.SetActive(true);
                break;
            case "大小":
                HideAllPanel();
                sizeBySpeedPanel.SetActive(true);
                break;
            default:
                HideAllPanel();
                emissionPanel.SetActive(true);
                break;
        }

    }
    private void Emission(float rate, float time, short min, short max, float time2, short min2, short max2)
    {
        Debug.Log("Emission");
        ParticleSystem.EmissionModule emission = ps.emission;
        // 启用粒子喷射
        emission.enabled = true;

        // 设置喷射的时间和喷射粒子数量
        emission.SetBursts(new ParticleSystem.Burst[] {
             new (time, min, max),
             new (time2, min2, max2)
        });

        // 创建动画曲线
        AnimationCurve curve = new();
        // 设置关键帧
        curve.AddKey(0.0f, 0.1f);
        curve.AddKey(0.75f, 1.0f);
        // 喷射速度参数设置为动画曲线
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(rate, curve);
    }
    private void VelocityOverLifetime(float key1, float key2, float key3, float key4, string s)
    {
        Debug.Log("VelocityOverLifetime");
        ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = ps.velocityOverLifetime;
        velocityOverLifetime.enabled = true;
        if (string.Equals(s, "相对坐标系"))
        {
            velocityOverLifetime.space = ParticleSystemSimulationSpace.Local;
        }
        else
        {
            velocityOverLifetime.space = ParticleSystemSimulationSpace.World;
        }
        // 创建动画曲线
        AnimationCurve curve = new();
        // 设置关键帧值
        curve.AddKey(key1, key2);
        curve.AddKey(key3, key4);
        // x 轴曲线设置为动画曲线
        velocityOverLifetime.x = new ParticleSystem.MinMaxCurve(10.0f, curve);
    }
    private void ForceOverLifetime(float key1, float key2, float key3, float key4)
    {
        Debug.Log("ForceOverLifetime");
        ParticleSystem.ForceOverLifetimeModule fo = ps.forceOverLifetime;
        fo.enabled = true;

        // 创建动画曲线
        AnimationCurve curve = new();
        // 设置关键帧值
        curve.AddKey(key1, key2);
        curve.AddKey(key3, key4);
        // x 轴曲线设置为动画曲线
        fo.x = new ParticleSystem.MinMaxCurve(1.5f, curve);
    }
    private void ColorOverLifetime(string s1, string s2, float key1, float key2, float key3, float key4, float key5, float key6)
    {
        ParticleSystem.ColorOverLifetimeModule colorOverLifetime = ps.colorOverLifetime;
        colorOverLifetime.enabled = true;
        // 创建动画颜色渐变
        Gradient gradient = new();
        if (string.Equals(s1, s2))
        {
            if (string.Equals(s1, "蓝色"))
            {
                gradient.SetKeys(new GradientColorKey[] {
                    new (Color.blue, key1),
                    new (Color.blue, key2)
                }, new GradientAlphaKey[] {
                    new (key3, key4),
                    new (key5, key6)
                });
            }
            else
            {
                gradient.SetKeys(new GradientColorKey[] {
                    new (Color.green, key1),
                    new (Color.green,key2)
                }, new GradientAlphaKey[] {
                    new (key3, key4),
                    new (key5, key6)
                });
            }
        }
        else if (string.Equals(s1, "蓝色"))
        {
            gradient.SetKeys(new GradientColorKey[] {
                new (Color.blue, key1),
                new (Color.green, key2)
            }, new GradientAlphaKey[] {
                new (key3, key4),
                new (key5, key6)
            });
        }
        else
        {
            gradient.SetKeys(new GradientColorKey[] {
                new (Color.green,key1),
                new (Color.blue, key2)
            }, new GradientAlphaKey[] {
                new (key3, key4),
                new (key5, key6)
            });
        }
        // 设置动画颜色渐变
        colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
    }
    private void SizeBySpeed(float key1, float key2, float key3, float key4, float key5, float key6)
    {
        ParticleSystem.SizeBySpeedModule ss = ps.sizeBySpeed;
        ss.enabled = true;
        ss.range = new Vector2(key1, key2);

        AnimationCurve curve = new();
        curve.AddKey(key3, key4);
        curve.AddKey(key5, key6);
        ss.size = new ParticleSystem.MinMaxCurve(10.0f, curve);
    }
}
