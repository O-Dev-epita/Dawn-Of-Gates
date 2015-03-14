 Shader "Custom/outline" {
    Properties {
       _MainTex ("Color (RGB) Alpha (A)", 2D) = "white"
    }
    SubShader {
    Tags { "Queue"="Transparent" "RenderType"="Transparent" }
      CGPROGRAM
      #pragma surface surf Lambert alpha
      struct Input {
          float2 uv_MainTex;
      };
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
      
          o.Emission = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
          
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }