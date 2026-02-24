using UnityEngine;
using UnityEditor.AssetImporters;
using System.IO;

[ScriptedImporter(1, "tex")]
public class TexImporter : ScriptedImporter
{
    public float blue = 0;

    public override void OnImportAsset(AssetImportContext ctx)
    {
        int width = 0;
        int height = 0;
        Texture2D tex = null;
        string[] lines = File.ReadAllLines(ctx.assetPath);

        foreach(var l in lines)
        {
            var tokens = l.Split(' ');
            if(tokens.Length >0 )
            {
                switch(tokens[0])
                {
                    case "circle":
                        if (tokens.Length >= 7)
                        {
                            int cx = int.Parse(tokens[1]);
                            int cy = int.Parse(tokens[2]);
                            int rad = int.Parse(tokens[3]);
                            float red = float.Parse(tokens[4]);
                            float green = float.Parse(tokens[5]);
                            float blue = float.Parse(tokens[6]);
                            for(int oy = -rad;oy<=rad;oy++)
                            {
                                for (int ox = -rad; ox <= rad; ox++)
                                {
                                    int dist = (int)Mathf.Sqrt(ox * ox + oy * oy);
                                    if(dist<=rad)
                                    {
                                        // Todo, make sure coords are on the texture.
                                        tex.SetPixel(cx+ox,cy+oy,new Color(red,green,blue));
                                    }
                                }

                            }
                            tex.Apply();
                        }
                        break;
                    case "resolution":
                        if(tokens.Length>=3)
                        {
                            width = int.Parse(tokens[1]);
                            height = int.Parse(tokens[2]);
                            if (width < 16384 && height < 16384)
                            {
                                tex = new Texture2D(width, height, TextureFormat.ARGB32, false);
                                for (int y = 0; y < height; y++)
                                {
                                    for (int x = 0; x < width; x++)
                                    {
                                        tex.SetPixel(x,y,new Color(x/(float)(width-1),y/(float)(height-1),blue));
                                    }
                                }
                                tex.Apply();
                            }
                        }
                        break;
                }
            }

        }


        if (tex)
        {
            ctx.AddObjectToAsset("Texture", tex);
            ctx.SetMainObject(tex);
        }
    }
}
