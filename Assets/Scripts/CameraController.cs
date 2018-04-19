/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   CameraController.cs                                :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: agougaut <alex.code@icloud.com>            +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/19 12:33:16 by agougaut          #+#    #+#             */
/*   Updated: 2018/04/19 12:34:24 by agougaut         ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField]
	private float Speed = 5f;
	void Update(){
		transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Speed * Time.deltaTime);
		transform.Translate(Vector3.forward * Input.GetAxis("Horizontal") * Speed * Time.deltaTime);
	}
}
