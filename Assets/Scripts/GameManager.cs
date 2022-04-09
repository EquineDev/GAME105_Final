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

public class GameManager : Singleton<GameManager>
{
    public Action GamePaused;
    public Action GameResumed;
    public Action LiveLost;
    public Action EndGame;
    
    public bool IsGamePaused => m_isGamePaused;
    public GameState GetGameState => m_gameState;

    [SerializeField] private UIText m_scoreUI = null;
    [SerializeField] private UIText m_livesUI = null;

    private int m_score = 0;
    private bool m_isGamePaused = false;
    private GameState m_gameState = GameState.Playing;

    #region UnityAPI

    private void Start()
    {
        InputController.Instance.PausePressed += InputPausedCalled;
        NullChecks();
    }

    private void OnDestroy()
    {
        InputController.Instance.PausePressed -= InputPausedCalled;
    }

    #endregion

    #region Public

    public void PauseGame(bool DoGamePaused)
    {
        if (DoGamePaused)
        {
            GamePaused?.Invoke();
        }
        else
        {
            GameResumed?.Invoke();
        }

        m_isGamePaused = DoGamePaused;
        Debug.Log("GamePaused:" + DoGamePaused);
    }

    public void UpdateScore(int value)
    {
        m_score += value;
        m_scoreUI.UpdateUI(m_score);
    }

    public void UpdateLives(int value)
    {
       
        
    }

    public void LevelClear()
    {
        m_gameState = GameState.ClearLevel;
    }

    public void GameOver()
    {
        m_gameState = GameState.GameOver;
        EndGame?.Invoke();
    }

    #endregion


    #region Private

  

    private void InputPausedCalled()
    {
        if (m_gameState == GameState.GameOver)
            return;
        if (m_isGamePaused)
            PauseGame(false);
        else
            PauseGame(true);
    }

    private void NullChecks()
    {
        Assert.IsNotNull(m_scoreUI);
        Assert.IsNotNull(m_livesUI);
    }

    #endregion
}

public enum GameState
{
    Playing,
    GameOver,
    ClearLevel
}