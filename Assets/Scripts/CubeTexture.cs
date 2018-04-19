/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   CubeTexture.cs                                     :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/19 13:58:45 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/19 14:55:52 by agougaut         ###   ########.fr       */
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
        uvs.AddRange(UVMapping.GetTileUV(64, 64, FaceBack));
        uvs.AddRange(UVMapping.GetTileUV(64, 64, FaceRight));
        uvs.AddRange(UVMapping.GetTileUV(64, 64, FaceFront));
        uvs.AddRange(UVMapping.GetTileUV(64, 64, FaceLeft));
        uvs.AddRange(UVMapping.GetTileUV(64, 64, FaceTop));
        uvs.AddRange(UVMapping.GetTileUV(64, 64, FaceBottom));
        return uvs.ToArray();
    }

}
