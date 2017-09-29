﻿using System;

namespace UnityEngine.MaterialGraph
{
    [Serializable]
    public class Vector3ShaderProperty : VectorShaderProperty
    {
        public override PropertyType propertyType
        {
            get { return PropertyType.Vector3; }
        }

        public override Vector4 defaultValue
        {
            get { return new Vector4(value.x, value.y, value.z, 0); }
        }

        public override PreviewProperty GetPreviewMaterialProperty()
        {
            return new PreviewProperty()
            {
                m_Name = referenceName,
                m_PropType = PropertyType.Vector3,
                m_Vector4 = value
            };
        }
    }
}
