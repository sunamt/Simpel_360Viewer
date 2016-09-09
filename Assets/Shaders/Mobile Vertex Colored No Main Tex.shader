Shader "Mobile/Vertex Colored No Texture" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex("Main Texture", 2D) = "white"
}
 
SubShader {
    Pass {
        ColorMaterial AmbientAndDiffuse
        Lighting Off
        Fog { Mode Off }
        SetTexture [_MainTex] {
            Combine texture * primary, texture * primary
        }
        SetTexture [_MainTex] {
            constantColor [_Color]
            Combine previous * constant DOUBLE, previous * constant
        } 
    }
}
 
Fallback " VertexUnLit", 1
}