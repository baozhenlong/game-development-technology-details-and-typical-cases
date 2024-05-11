using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRippleGUI : MonoBehaviour
{
   public Material material;
   public AudioSource flowAudioSource;

   private void Start()
   {
      WaveOn();
   }

   // 开启水波纹
   private void WaveOn()
   {
      material.SetVector(("_Aim1"), new Vector4(3,0,3,-2.5f));
      material.SetVector(("_Aim2"), new Vector4(5,0,-5,0));
      material.SetVector(("_Aim3"), new Vector4(-3,0,-3,0));
      material.SetVector(("_Aim4"), new Vector4(-5,0,5,0));
      material.SetFloat(("_High"),1);
      flowAudioSource.Play();
   }
   
   // 关闭水波纹
   private void WaveOff()
   {
      material.SetVector(("_Aim1"), new Vector4(3,0,3,0));
      material.SetVector(("_Aim2"), new Vector4(5,0,-5,0));
      material.SetVector(("_Aim3"), new Vector4(-3,0,-3,0));
      material.SetVector(("_Aim4"), new Vector4(-5,0,5,0));
      material.SetFloat(("_High"),0);
      flowAudioSource.Stop();
   }

   private void OnGUI()
   {
      if(GUI.Button(new Rect(10,10,58,30),"有波纹"))
      {
         WaveOn();
      }
      if(GUI.Button(new Rect(10,50,58,30),"无波纹"))
      {
         WaveOff();
      }
   }
}
