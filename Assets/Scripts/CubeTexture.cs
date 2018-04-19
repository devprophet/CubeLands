/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   CubeTexture.cs                                     :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/19 13:58:45 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/19 16:56:17 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeTexture
{
    public string Author;
    public string TextureName;
    public string TextureTileSet;
    public bool isLocal;
    public int ElementsOnXAxis;
    public int ElementsOnYAxis;
    public bool RangeOnXAxis;
    public int XMin;
    public int XMax;
    public bool RangeOnYAxis;
    public int YMin;
    public int YMax;
    
    public Vector2 FaceBack;
    public Vector2 FaceRight;
    public Vector2 FaceFront;
    public Vector2 FaceLeft;
    public Vector2 FaceTop;
    public Vector2 FaceBottom;
    
    public Vector2[] FaceToArray(){
        return new Vector2[] {
            FaceBack,
            FaceRight,
            FaceFront,
            FaceLeft,
            FaceTop,
            FaceBottom
        };
    }

    public Vector2[] CalculatedUV(){
        List<Vector2> uvs = new List<Vector2>();
        System.Random rand = new System.Random();
        Vector2 r = new Vector2( RangeOnXAxis ? rand.Next(XMin, XMax) : 0, RangeOnYAxis ? rand.Next(YMin, YMax) : 0);
        var ba = FaceBack + r;
        var ri = FaceRight + r;
        var fr = FaceFront + r;
        var le = FaceLeft + r;
        var to = FaceTop + r;
        var bo = FaceBottom + r;

        uvs.AddRange(UVMapping.GetTileUV(ElementsOnXAxis, ElementsOnYAxis, ba));
        uvs.AddRange(UVMapping.GetTileUV(ElementsOnXAxis, ElementsOnYAxis, ri));
        uvs.AddRange(UVMapping.GetTileUV(ElementsOnXAxis, ElementsOnYAxis, fr));
        uvs.AddRange(UVMapping.GetTileUV(ElementsOnXAxis, ElementsOnYAxis, le));
        uvs.AddRange(UVMapping.GetTileUV(ElementsOnXAxis, ElementsOnYAxis, to));
        uvs.AddRange(UVMapping.GetTileUV(ElementsOnXAxis, ElementsOnYAxis, bo));
        return uvs.ToArray();
    }

}
