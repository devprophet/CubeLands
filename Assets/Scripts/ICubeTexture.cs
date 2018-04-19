/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   ICubeTexture.cs                                    :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/19 13:56:33 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/19 14:05:38 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */

using UnityEngine;

public interface ICubeTexture {
	string jsonPath {get;}
	Vector2 FacePosition(int face);
}
