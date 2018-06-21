using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace UnityEditor.Experimental.Rendering.HDPipeline
{
    class ShaderNameGUI : BaseUnlitGUI
    {
        protected static class Styles
        {
            public static string InputsText = "Inputs";

            public static GUIContent baseColorText = new GUIContent("Base Color + Opacity", "Albedo (RGB) and Opacity (A)");
        }


        protected MaterialProperty baseColor = null;
        protected const string kBaseColor = "_BaseColor";
        protected MaterialProperty baseColorMap = null;
        protected const string kBaseColorMap = "_BaseColorMap";

        override protected void FindMaterialProperties(MaterialProperty[] props)
        {
            baseColor = FindProperty(kBaseColor, props);
            baseColorMap = FindProperty(kBaseColorMap, props);
        }

        protected override void MaterialPropertiesGUI(Material material)
        {
            EditorGUILayout.LabelField(Styles.InputsText, EditorStyles.boldLabel);

            m_MaterialEditor.TexturePropertySingleLine(Styles.baseColorText, baseColorMap, baseColor);
            m_MaterialEditor.TextureScaleOffsetProperty(baseColorMap);

            var surfaceTypeValue = (SurfaceType)surfaceType.floatValue;
            if (surfaceTypeValue == SurfaceType.Transparent)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField(StylesBaseUnlit.TransparencyInputsText, EditorStyles.boldLabel);
                ++EditorGUI.indentLevel;

                DoDistortionInputsGUI();

                --EditorGUI.indentLevel;
            }
        }

        protected override void MaterialPropertiesAdvanceGUI(Material material)
        {
        }

        protected override void VertexAnimationPropertiesGUI()
        {

        }

        protected override bool ShouldEmissionBeEnabled(Material mat)
        {
            return false;
            //return mat.GetFloat(kEmissiveIntensity) > 0.0f;
        }

        protected override void SetupMaterialKeywordsAndPassInternal(Material material)
        {
            SetupMaterialKeywordsAndPass(material);
        }

        // All Setup Keyword functions must be static. It allow to create script to automatically update the shaders with a script if code change
        static public void SetupMaterialKeywordsAndPass(Material material)
        {
            SetupBaseUnlitKeywords(material);
            SetupBaseUnlitMaterialPass(material);
        }
    }
} // namespace UnityEditor
