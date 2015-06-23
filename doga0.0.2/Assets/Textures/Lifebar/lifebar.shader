 Shader "Custom/lifebar" {
    Properties {
       _Life ("Life", Color) = (0,0,0,0)
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
      float4 _Life;
      
      
      void surf (Input IN, inout SurfaceOutput o) {
      
      	  o.Emission = _Life.rgb;
          o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
          
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }
