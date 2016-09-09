Shader "Mobile/Transparent/Vertex Color No Main Tex" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex("Main Texture", 2D) = "white"
}

Category {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	ZWrite Off
	ZTest LEqual
	//Alphatest Greater 0
	Blend SrcAlpha OneMinusSrcAlpha 
	
	SubShader {
		Material {
			Diffuse [_Color]
			Ambient [_Color]
		}
		Pass {
			ColorMaterial AmbientAndDiffuse
			Fog { Mode Off }
			Lighting Off
			SeparateSpecular On
        	SetTexture [_MainTex] {
            Combine texture * primary, texture * primary
        }
        SetTexture [_MainTex] {
            constantColor [_Color]
            Combine constant DOUBLE, constant
        }  
		}
	} 
}
}