/* Copyright (c) 2022 Scott Tongue
 * 
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
 * CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
 * TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. THE SOFTWARE 
 * SHALL NOT BE USED IN ANY ABLEISM WAY.
 */

using System;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(SFXPlayer))]
public class Player : MonoBehaviour,IHandlerInput
{

   
    private SFXPlayer m_sfxPlayer;
    private bool m_isDead =false;
  

    #region UnityAPI
    
    private void Start()
    {
        Setup();
    }

    #endregion



    #region  Private
    private void AxisXMovement(float value)
    {
        if (m_isDead)
            return;
       

    }
    private void AxisYMovement(float value)
    {
        if (m_isDead)
            return;
        //TODO:Paddle Movement Here
    }

    private void Jump()
    {
        if (m_isDead)
            return;
       //TODO: JUMP ACTION
    }

    private void Action()
    {
        if (m_isDead)
            return;
        //TODO: Fire Weapon pickup if your game has firing in it 
    }
    
    #endregion
    
 
    
    #region Interfaces
    
    public void Setup()
    {
        Debug.Log("Adding Player Input");
        InputController.Instance.AxisX += AxisXMovement;
        InputController.Instance.AxisY += AxisYMovement;
        InputController.Instance.JumpPressed += Jump;
        InputController.Instance.FirePressed += Action;
        InputController.Instance.CleanUp += CleanUp;
        InputController.Instance.SetHandler = this.GetComponent<IHandlerInput>();
    }

    public void CleanUp()
    {
        Debug.Log("Removing Player Input");
        InputController.Instance.AxisX -= AxisXMovement;
        InputController.Instance.AxisY -= AxisYMovement;
        InputController.Instance.JumpPressed -= Jump;
        InputController.Instance.FirePressed -= Action;
        InputController.Instance.CleanUp -= CleanUp;
        
    } 
    #endregion
}
