using UnityEngine;
using UnityEditor.AssetImporters;

[ScriptedImporter(1,"bare")]
public class BareImporter : ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext ctx)
    {
        Texture2D tex = new Texture2D(32,32, TextureFormat.ARGB32, false);
        ctx.AddObjectToAsset("Texture", tex);
        ctx.SetMainObject(tex);
    }
}
