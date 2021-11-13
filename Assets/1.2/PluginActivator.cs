using System.Runtime.InteropServices;
using UnityEngine;

public class PluginActivator : MonoBehaviour
{
    [StructLayout(LayoutKind.Sequential)]
   public struct TwoStrings
    {
       public string string1;
       public string string2;
       public string concatenated;

        public TwoStrings(string string1, string string2) : this()
        {
            this.string1 = string1;
            this.string2 = string2;
        }

        public override string ToString()
        {
            return $"String1: {string1}\tString2: {string2}\tConcatenated: {concatenated}";
        }
    }
    [DllImport("LibraryTestUnity")]//,CharSet = CharSet.Auto,CallingConvention = CallingConvention.Cdecl)]
    private static extern TwoStrings FillStruct (TwoStrings tStrings);
    void Start()
    {
        var a = new TwoStrings("Hello","World");
        Debug.Log("Before Plugin");
        Debug.Log(a.ToString());
        var result = FillStruct(a);
        Debug.Log("After Plugin");
        Debug.Log(result.ToString());
      
    }
}
