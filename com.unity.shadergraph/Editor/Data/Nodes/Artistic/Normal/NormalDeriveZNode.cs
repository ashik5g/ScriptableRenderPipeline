using System.Reflection;
using UnityEngine;

namespace UnityEditor.ShaderGraph
{
    [Title("Artistic", "Normal", "Normal Derive Z")]
    public class NormalDeriveZNode : CodeFunctionNode
    {
        public NormalDeriveZNode()
        {
            name = "Normal Derive Z";
        }

        public override string documentationURL
        {
            get { return "https://github.com/Unity-Technologies/ShaderGraph/wiki/Normal-Derive-Z-Node"; }
        }

        protected override MethodInfo GetFunctionToConvert()
        {
            return GetType().GetMethod("NormalDeriveZ", BindingFlags.Static | BindingFlags.NonPublic);
        }

        static string NormalDeriveZ(
            [Slot(0, Binding.None)] Vector2 In,
            [Slot(2, Binding.None, ShaderStageCapability.Fragment)] out Vector3 Out)
            
        {
            Out = Vector3.zero;
            return
                @"
{
    float deriveZ = sqrt(1 - ( In.x * In.x + In.y * In.y));
    float3 normalVector = float3(In.x, In.y, deriveZ);
    Out = normalize(normalVector);
}";
        }
    }
}
