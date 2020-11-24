using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DxLibDLL;

public class handleclass : MonoBehaviour
{
    //ハンドルコントローラーのボタン一覧
    public enum Buttons
    {
        A,
        B,
        C,
        X,
        Y,
        Z,
        ShiftDown,
        ShiftUp
    };
    //アクセルか、ブレーキか
    public enum Pedals
    {
        accelerator,
        brake
    };
    //この値であそびの増減ができる、増やせば増やすほど感度が悪くなる
    public int HANDLE_LIMIT = 100;
    //ハンドルコントローラーの判定を取る変数
    DX.DINPUT_JOYSTATE input;
    //連打機能に必要な変数
    bool[] m_repeatButtonFlag = new bool[8] {false,false,false,false, false, false, false, false};
    //KeepButtonに必要な変数
    bool [] m_keepButtonFlag = new bool[8] { false, false, false, false, false, false, false, false };
    bool[] m_keyState = new bool[8] { false, false, false, false, false, false, false, false };
    public void UpdateJoyPad()
    {
        DX.GetJoypadDirectInputState(DX.DX_INPUT_PAD1, out input);
    }
    public float LimitHandle()
    {
        if (Mathf.Abs(input.X) < Mathf.Abs(HANDLE_LIMIT))
            return 0;
        return (float)input.X/1000;
    }

   public float Pedal(Pedals pedal)
    {
        if(pedal == Pedals.accelerator)
        {
            return (2000.0f - ((float)input.Y + 1000.0f)) / 2000;
        }
        else
        {
            return (2000.0f - ((float)input.Rz + 1000.0f)) / 2000;
        }
    }
    public bool Button(Buttons button)
    {
        switch(button)
        {
            case Buttons.A:
                if (input.Buttons0 != 0)
                    return true;
                break;
            case Buttons.B:
                if (input.Buttons1 != 0)
                    return true;
                break;
            case Buttons.C:
                if (input.Buttons2 != 0)
                    return true;
                break;
            case Buttons.X:
                if (input.Buttons3 != 0)
                    return true;
                break;
            case Buttons.Y:
                if (input.Buttons4 != 0)
                    return true;
                break;
            case Buttons.Z:
                if (input.Buttons5 != 0)
                    return true;
                break;
            case Buttons.ShiftDown:
                if (input.Buttons6 != 0)
                    return true;
                break;
            case Buttons.ShiftUp:
                if (input.Buttons7 != 0)
                    return true;
                break;
            default:
                break;
        }
        return false;
    }

    public bool RepeatButton(Buttons button)
    {
        switch (button)
        {
            case Buttons.A:
                if (input.Buttons0 != 0 && !m_repeatButtonFlag[(int)Buttons.A])
                {
                    m_repeatButtonFlag[(int)Buttons.A] = true;
                    return true;
                }
                m_repeatButtonFlag[(int)Buttons.A] = false;
                return false;
            case Buttons.B:
                if (input.Buttons1 != 0 && !m_repeatButtonFlag[(int)Buttons.B])
                {
                    m_repeatButtonFlag[(int)Buttons.B] = true;
                    return true;
                }
                m_repeatButtonFlag[(int)Buttons.B] = false;
                return false;
            case Buttons.C:
                if (input.Buttons2 != 0 && !m_repeatButtonFlag[(int)Buttons.C])
                {
                    m_repeatButtonFlag[(int)Buttons.C] = true;
                    return true;
                }
                m_repeatButtonFlag[(int)Buttons.C] = false;
                return false;
            case Buttons.X:
                if (input.Buttons3 != 0 && !m_repeatButtonFlag[(int)Buttons.X])
                {
                    m_repeatButtonFlag[(int)Buttons.X] = true;
                    return true;
                }
                m_repeatButtonFlag[(int)Buttons.X] = false;
                return false;
            case Buttons.Y:
                if (input.Buttons4 != 0 && !m_repeatButtonFlag[(int)Buttons.Y])
                {
                    m_repeatButtonFlag[(int)Buttons.Y] = true;
                    return true;
                }
                m_repeatButtonFlag[(int)Buttons.Y] = false;
                return false;
            case Buttons.Z:
                if (input.Buttons5 != 0 && !m_repeatButtonFlag[(int)Buttons.Z])
                {
                    m_repeatButtonFlag[(int)Buttons.Z] = true;
                    return true;
                }
                m_repeatButtonFlag[(int)Buttons.Z] = false;
                return false;
            case Buttons.ShiftDown:
                if (input.Buttons6 != 0 && !m_repeatButtonFlag[(int)Buttons.ShiftDown])
                {
                    m_repeatButtonFlag[(int)Buttons.ShiftDown] = true;
                    return true;
                }
                m_repeatButtonFlag[(int)Buttons.ShiftDown] = false;
                return false;
            case Buttons.ShiftUp:
                if (input.Buttons7 != 0 && !m_repeatButtonFlag[(int)Buttons.ShiftUp])
                {
                    m_repeatButtonFlag[(int)Buttons.ShiftUp] = true;
                    return true;
                }
                m_repeatButtonFlag[(int)Buttons.ShiftUp] = false;
                return false;
            default:
                break;
        }
        return false;
    }

    public bool KeepButton(Buttons button)
    {
        switch (button)
        {
            case Buttons.A:
                if (input.Buttons0 != 0)
                {
                    if (!m_keyState[(int)Buttons.A])
                    {
                        m_keyState[(int)Buttons.A] = true;
                        m_keepButtonFlag[(int)Buttons.A] = !m_keepButtonFlag[(int)Buttons.A];
                    }
                }
                else
                {
                    m_keyState[(int)Buttons.A] = false;
                }
                if (m_keepButtonFlag[(int)Buttons.A])
                    return true;
                break;
            case Buttons.B:
                if (input.Buttons1 != 0)
                {
                    if (!m_keyState[(int)Buttons.B])
                    {
                        m_keyState[(int)Buttons.B] = true;
                        m_keepButtonFlag[(int)Buttons.B] = !m_keepButtonFlag[(int)Buttons.B];
                    }
                }
                else
                {
                    m_keyState[(int)Buttons.B] = false;
                }
                if (m_keepButtonFlag[(int)Buttons.B])
                    return true;
                break;
            case Buttons.C:
                if (input.Buttons2 != 0)
                {
                    if (!m_keyState[(int)Buttons.C])
                    {
                        m_keyState[(int)Buttons.C] = true;
                        m_keepButtonFlag[(int)Buttons.C] = !m_keepButtonFlag[(int)Buttons.C];
                    }
                }
                else
                {
                    m_keyState[(int)Buttons.C] = false;
                }
                if (m_keepButtonFlag[(int)Buttons.C])
                    return true;
                break;
            case Buttons.X:
                if (input.Buttons3 != 0)
                {
                    if (!m_keyState[(int)Buttons.X])
                    {
                        m_keyState[(int)Buttons.X] = true;
                        m_keepButtonFlag[(int)Buttons.X] = !m_keepButtonFlag[(int)Buttons.X];
                    }
                }
                else
                {
                    m_keyState[(int)Buttons.X] = false;
                }
                if (m_keepButtonFlag[(int)Buttons.X])
                    return true;
                break;
            case Buttons.Y:
                if (input.Buttons4 != 0)
                {
                    if (!m_keyState[(int)Buttons.Y])
                    {
                        m_keyState[(int)Buttons.Y] = true;
                        m_keepButtonFlag[(int)Buttons.Y] = !m_keepButtonFlag[(int)Buttons.Y];
                    }
                }
                else
                {
                    m_keyState[(int)Buttons.Y] = false;
                }
                if (m_keepButtonFlag[(int)Buttons.Y])
                    return true;
                break;
            case Buttons.Z:
                if (input.Buttons5 != 0)
                {
                    if (!m_keyState[(int)Buttons.Z])
                    {
                        m_keyState[(int)Buttons.Z] = true;
                        m_keepButtonFlag[(int)Buttons.Z] = !m_keepButtonFlag[(int)Buttons.Z];
                    }
                }
                else
                {
                    m_keyState[(int)Buttons.Z] = false;
                }
                if (m_keepButtonFlag[(int)Buttons.Z])
                    return true;
                break;
            case Buttons.ShiftDown:
                if (input.Buttons6 != 0)
                {
                    if (!m_keyState[(int)Buttons.ShiftDown])
                    {
                        m_keyState[(int)Buttons.ShiftDown] = true;
                        m_keepButtonFlag[(int)Buttons.ShiftDown] = !m_keepButtonFlag[(int)Buttons.ShiftDown];
                    }
                }
                else
                {
                    m_keyState[(int)Buttons.ShiftDown] = false;
                }
                if (m_keepButtonFlag[(int)Buttons.ShiftDown])
                    return true;
                break;
            case Buttons.ShiftUp:
                if (input.Buttons7 != 0)
                {
                    if (!m_keyState[(int)Buttons.ShiftUp])
                    {
                        m_keyState[(int)Buttons.ShiftUp] = true;
                        m_keepButtonFlag[(int)Buttons.ShiftUp] = !m_keepButtonFlag[(int)Buttons.ShiftUp];
                    }
                }
                else
                {
                    m_keyState[(int)Buttons.ShiftUp] = false;
                }
                if (m_keepButtonFlag[(int)Buttons.ShiftUp])
                    return true;
                break;
            default:
                break;
        }
        return false;
    }
}
