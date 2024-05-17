//#define EXAMPLE_TYPE_METHOD
//#define EXAMPLE_TYPE_CLASS
#define EXAMPLE_TYPE_PROPERTY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Ŭ���� / �޼��� / ������Ƽ
/*

�� C# ��� Ŭ����

- C# Ŭ������ ���� Ÿ���̴�.
    �� ��ü�� ������ ���簡 ����Ǳ� ���ؼ��� �ݵ�� ���� ���翡 �ش��ϴ� ������ �����ؾ� �Ѵ�.

- C# Ŭ������ ��ǥ �����ڸ� ������ �� �ִ�.
    �� ��ǥ �����ڸ� ���� ��ü�� �ʱ�ȭ ������ ����ȭ ��Ű�� ���� �����ϴ�.

- C# Ŭ���� ��ø Ŭ������ �����Ѵ�.
    �� C#�� ��ø Ŭ������ C++���� �޸� �ڽ��� �����ϴ� �ܺ� Ŭ������ private ���� �ȿ� �����ϴ� ���� �����ϴ�.

- C# Ŭ������ �Ҹ��ڸ� �������� �ʴ� ���� ��Ģ���� �Ѵ�.
     �� ������ ���������� ���� �� GC�� �޸� ������ ���� ���� �� ����.

- C# Ŭ������ �θ� Ŭ������ �ǹ��ϴ� Ű���带 �����Ѵ�.
    �� Base - Derived Ŭ������ ��µȴ�.

- C# Ŭ������ Sealed Ű���带 ���� ��� ���θ� ������ �� �ִ�.

- C# Ŭ������ Partial Ű���带 ���� Ŭ���� ������ �����Ѵ�.
    �� ���� �̸��� Ŭ������ 5�� �����ΰ� �տ� Partial�� ���̸� �ϳ��� Ŭ������ �νĵ�
    �� Ex) �÷��̾��� ��ų, �÷��̾� ������.. �̷��� Ŭ������ ���� �� ����.
    �� ����ȭ ��ų �� �ִ�.

- C# Ŭ������ ���� ��Ӹ��� �����Ѵ�.
    �� ��, �������̽��� ���ؼ� ���� ����� �����Ѵ�.



�� C# �޼���

- C#�� �޼���� �⺻������ ���� ���� ȣ���̴�.
    �� Call By Value

- C# ��� �޼���� ref �Ǵ� out �̶�� Ű���带 ���ؼ� ������ ���� ȣ���� �ϴ� ���� �����ϴ�.
    �� Call By Reference

- C# �޼���� params Ű���带 ���ؼ� ���� ���� �Ű������� ó���� �� �ִ�.
    �� �̰Ŵ� C/C++ .... �� ����� ������ �Ѵ�. (���� ����)
    �� printf�� ���� ���� �Լ���.

- C# �޼���� ȣ�� �� ���� �Ѱ��� �Ű� ������ �̸��� ���� ����ϴ� ���� �����ϴ�.
    �� �̷��� ����� ���ӵ� �Ű�������� �Ѵ�.
    �� �Ű������� �Ѱ��� �� Ÿ���� ĳ������ �����ϴ�(ġȯ�� �����ϴ�)

- C# �޼���� �ڽ� Ŭ�������� �������ϱ� ���ؼ��� virtual Ű���带 �ݵ�� �������� �Ѵ�.
    �� ���� �ڽ� Ŭ���������� override Ű���带 ���ؼ� �θ� Ŭ������ �ɹ� �Լ��� ������ �ϰ� �ִٴ� ����
       ����� ��� �Ѵ�. C++�� �ٸ��� override Ű���带 ������� ������ ������ ����

�� �θ� Ŭ������ �޼��带 �������̵� ���� �ʰ� ������ �̸��� ���ο� �޼��带 �ڽ� Ŭ�������� �����ϱ� ���ؼ���..
    �� new

- C# ����� �޼��� ���� sealed Ű���带 ���ؼ� �ڽ� Ŭ�������� �ɹ� �Լ��� �������̵� �ϴ� ���� ���� �� �ִ�.


  ref Ű����� out Ű����

- out Ű����� �ǹ������� ����� �Ѵٴ� ��
�� ������ �ۼ��� �� �߻��� �� �ִ� �ʱ�ȭ �Ǽ��� �����Ϸ� �ܰ迡�� ������ �����ϴ�.

- ref Ű����� �ݴ�� ������ �ʱ�ȭ ������ ������ ���� �ʴ´�.
�� ���� ������ �����ִ� Ű����

- C# ���� ��쿡�� �⺻������ �ʱ�ȭ ���� ���� ���� ������ ����� �� ����.
�� �ʱ�ȭ ���� ���� ������ ����� �� ������ ������ �߻��Ѵ�.

- ���� Ư¡�� ���� ref Ű���带 �̿��ؼ� ���� ���� ������ ��� �ݵ�� �ش� ������ �ʱ�ȭ�� �Ǿ� �־�� �Ѵ�.

- �ݸ鿡 out Ű���带 �̿��� ��� �ش� Ű����� ���� ���� ���� ���� �޼��忡�� �ݵ�� ���� �ʱ�ȭ �ȴٴ� ������ ���� �� �ֱ� ������
�ʱ�ȭ ���� �ʴ� ������ ���� ���� �����ϴ� �͵� �����ϴ�.

�� ������Ƽ

- ��ü�� ���� �ִ� �ʵ忡 �����ϰ� ���� / �����ϱ� ���� ������ �Լ��� ���Ѵ�. (������ �Ѵ�.)
    �� Get / Set

- ������ ���ϰ� �ִ� Getter / Setter �Լ��� �� �� ���ϰ� �̿��ϱ� ������ ����
    �� �����͸��� ����ϰ� �Ǹ� �ڵ带 �����ϰ� ���� �� �� ������ + ������ ���� ���� ���� ���� �� �ִ�.

- C# ��� ������Ƽ�� Ư¡
    �� c#��ũ��Ʈ�� �������� �ν����� â�̴�.

- C# ���� ������Ƽ�� ���ؼ� �����ϰ� ������ �Լ��� ����� ���� �����ϴ�.
    �� ��, �Ϲ������� ������Ƽ�� �ɹ� ������ �����̱� ������ ������Ƽ �ȿ��� �����͸� �����ϱ� ����
       �ɹ� ������ �ʿ��ϴ�.

- ���� C# ������ ������Ƽ�� ����� �� ���� ������ �ܼ��� ��� �̸� �ڵ������� �������ִ� ���� ������Ƽ
����� �����Ѵ�. ���� ������Ƽ�� ����ϸ� ������Ƽ ������ �ܼ��ϰ� �� �� ������ �ش� ������Ƽ�� ����
������ ������ ������ ������ �ʾƵ� �ȴ�.

- C# ���� ������Ƽ�� �̿��ؼ� ��ȸ�� �����͸� �����ϴ� ���� ����
    �� �̸� ���� Ÿ�� �����Ͷ�� �Ѵ�.
    �� ���� �����ʹ� �⺻������ �������� �̸��� �������� �ʱ� ������ �ݵ�� var�� ���ؼ� �Ҵ��� �ؾ� �Ѵ�.

- ������Ƽ�� ����ؼ� Ŭ������ �ʱ�ȭ �ϴ� �͵� �����ϸ� �̴� ����ü���� �����ϰ� ������ �ȴ�.

- ���������� C#�� ������Ƽ�� virtual + override Ű���带 ���ؼ� ������ ĳ�Ӵ����� ������ �� �ִ�.

 
 */
#endregion

public class Example_05 : MonoBehaviour
{
    private int m_nValue = 100;
    public void Awake()
    {
#if EXAMPLE_TYPE_CLASS
        var DerivedA = new CDerived("Hellfire", this);
        var DerivedB = new CDerived(10, 3.14f, "Hello", this);

        DerivedA.ShowInfo(); // 2������(�θ�, �ڽ�)
        // 0, 0
        // Hellofire, 100


        DerivedB.ShowInfo(); // 2������(�θ�, �ڽ�)
        // 10, 3.14f
        // Hello, 100

#elif EXAMPLE_TYPE_METHOD

        int nLhs = 10;
        int nRhs = 20;

        // debug: 10, 20
        SwapByValue(nLhs, nRhs);
        Debug.LogFormat("Lhs: {0}, Rhs: {1}", nLhs, nRhs);

        // debug: 20, 10
        SwapByReference(ref nLhs, ref nRhs);
        Debug.LogFormat("Lhs: {0}, Rhs: {1}", nLhs, nRhs);

        int nValueA;
        int nValueB;

        this.InitValue(out nValueA, out nValueB);

        // debug: 10, 20
        Debug.LogFormat("nValueA: {0}, nValueB: {1}", nValueA, nValueB);


        CBase oBase = new CLeaf();

        // 3�� �� ȣ�� ��
        // base���� ȣ���� �Ǵµ�, �� base���� ȣ���� �Ǵ��� override ����
        oBase.ShowInfo();


        int nSumValueA = this.GetSumValue(1, 2, 3, 4, 5, 1.0f, 2.0f, 3.0f, 4.0f);
        int nSumValueB = this.GetSumValue(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

        Debug.LogFormat("nSumValueA: {0}, nSumValueB: {1}", nSumValueA, nSumValueB);


#else
        CWidget widgetA = new CWidget();
        widgetA.Value = 10;
        widgetA.String = "Hell Fire";
        widgetA.SetString("Help, Me");


        CWidget widgeB = new CWidget()
        {
            Value = 20,
            String = "Help"
        };
        // �ΰ��� ��ü ���� �ʱ�ȭ�� ���̰� �ִ�.
        // �ڵ� inline�� ���ִ��� �� ���ִ��� ����
        // �� �ϳ��� ������ ����ġ��, �ϳ��� ���ÿ� ���� ���´�.
        // ���� ������ ã��!!!!!!!!!!!!!!!!!!!



        string oString = "";
        var oStringBuilder = new System.Text.StringBuilder();


        /*
         String VS StringBuilder

        String: �бⰡ ���� ��쿡 �����ϴ�.

        StringBuilder: ��ü�� ���� ���� ������ �����Ѵ�. (�߰�, ����, ����)
            �� ���ο� ��ü�� ������ �ʰ� ���ڿ��� �����ϰ� ���� �� ����Ѵ�.

        EX)
        - ���� + �����ڸ� ���� ���ڿ� ������ �ϰ� �ʹ�.
         �� �̷��� ���� �� ��û �ſ�ſ� ������.
            �� �ݺ����� ���� ���� + �ٸ� �޸��� ���� �����ϱ� ����
        
         */

        for (int i = 0; i < 100; i++)
        {
            oStringBuilder.Append((i + 1).ToString());
        }
        oString = oStringBuilder.ToString();

        // 10, Hell Fire
        Debug.LogFormat("���� ����: {0}, {1}, {2}", widgetA.Value, widgetA.String, widgetA.GetString());

        // 20, Help
        Debug.LogFormat("���� ����: {0}, {1}, {2}", widgeB.Value, widgeB.String, widgeB.GetString());



        // ����: �̸��� ���� ����
        // �� ���� ������ ����� ���ÿ� �ν��Ͻ��� �Ҵ��Ѵ�.
        // �� ���� ������ ����� ���� ������� ���� �� �����ϳ� ���� ������ ������Ƽ�� �Ҵ�� ����
        //    ������ �Ұ��� �ϴ�.
        // �� �ѹ� ������ �ν��Ͻ��� �б⸸ �����ϴ�.
        var oAnonymousData = new
        {
            Value = 10,
            String = "Help"
        };
        // ���������� ������ �� �ϰڴ�
        // �����Ҵ��� �ϸ� ���������� GC�� ȣ��ȴ�. -> GC���� ó���� �ñ�ڴ�.
        // ��ȸ�� �����Ϳ� ���ش�.

        Debug.LogFormat("Data ����: {0}, {1}", oAnonymousData.Value, oAnonymousData.String);

#endif
    }

#if EXAMPLE_TYPE_CLASS

    /*
     ���� ���� / ���� ����

    - C# Ŭ������ �ᱹ ���� ����
    �� ���� ������ �ִ� ������ �� ������ �Ҵ�� ��ü�� �޸𸮸� ����Ų��.
    
    Ŭ������ ������ ���� ������ ����
    �� ������ �ϸ� �޸𸮴� ������ �ȴ�, �ݸ鿡 �ӵ� �鿡���� ����ϴ�
        �� �������� �ű�� �ͺ��� ������ ó���ϴ°� �� ������ ����
        �� ������ �� �ݴ�
     */

    //! ���� Ŭ���� 
    class CBase
    {
        protected int m_nValue = 0;
        protected float m_fValue = 0.0f;

        //! ������ / ��ǥ ������
        public CBase(int nValue, float fValue)
        {
            m_nValue = nValue;
            m_fValue = fValue;
        }

        public void ShowInfo()
        {
            Debug.LogFormat("����: {0}, �Ǽ�: {1}", m_nValue, m_fValue);
        }
    }

    // C#�� ����� �� public ���� ����(public���θ� ��� �ޱ� ������)
    // ICloneable: C# ǥ�� (���� ���縦 �����ϱ� ���� �������̽�)
    // �������̽��� ����� �ƴ϶� �����ٶ�� ������ ����.
    // C#�� Ŭ���� ����� ������ �����ڸ� 2�� ���������Ѵ�.(�θ�, �ڽĲ�)
    class CDerived : CBase, System.ICloneable
    {
        private string m_oString = "";
        private Example_05 m_oExample = null;

        public CDerived(string a_oString, Example_05 a_oExample) : this(0, 0.0f, a_oString, a_oExample)
        {

        }

        public CDerived(int a_nValue, float a_fValue, string a_oString, Example_05 a_oExample) : base(a_nValue, a_fValue)
        {
            m_oString = a_oString;
            m_oExample = a_oExample;
        }

        //!  ��ü ���� �غ�
        public object Clone()
        {
            var oDerived = new CDerived(m_nValue, m_fValue, m_oString, m_oExample);

            return oDerived;
        }

        public new void ShowInfo()
        {
            base.ShowInfo();

            Debug.LogFormat("���ڿ�: {0}, �ܺ� Ŭ����: {1}", m_oString, m_oExample.m_nValue);
        }
    }


#elif EXAMPLE_TYPE_METHOD
    class CBase
    {
        public virtual void ShowInfo()
        {
            Debug.Log("Base ���� ���");
        }
    }

    class CDerived : CBase
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Derived ���� ���");
        }
    }

    class CLeaf : CDerived
    {
        public override void ShowInfo()
        {
            base.ShowInfo();

            Debug.Log("Leaf ���� ���");
        }
    }


    // params: �޼��忡�� �迭 ������ �Ű������� ���� �� ����� �� �ִ�.
    //  �� params�� ��� �������� ��Ƽ� �迭�� ����� �ִ� ���
    // ������: params 1���� �迭�� �����ϸ� �޼����� �Ű����� �������� ��ġ�ؾ� �Ѵ�.

    //! ������ ���� ��ȯ�Ѵ�.
    private int GetSumValue(params object[] a_oParams)
    {
        int nSumValue = 0;
        float fSumValue = 0.0f;

        CBase oBase = new CDerived();

        /*
        �� as / is

        - is Ű���� + as Ű����� �� �� ������ Ÿ������ ����ȯ�� �������� �˻��ϴ� ������ �����Ѵ�.

        
         ������

        - is Ű����� �� ���� ���� ���Ŀ� ��� ����� �� ������ ����� �������� ��ȯ�� �ȴ�.

        - �ݸ� as Ű����� ���� ���Ŀ��� ����ϴ� ���� �����ϸ� ����� null �Ǵ� �ش� Ÿ���� ���� ������ ��ȯ�� �ȴ�.
        �� �̷��� Ư�� ������ as Ű����� ��ü�� ������ �ٿ� ĳ������ �ϴ� ���� �����ϰ� �Ѵ�.
        
        as�� Ŭ���� Ÿ�԰� ���� ���� ��ĳ����, �ٿ� ĳ������ �������� �˻��Ѵ�.

         */

        CDerived oDerived = oBase as CDerived;

        if (oDerived != null)
        {
            Debug.Log("�ٿ� ĳ���ÿ� ����");
        }

        for (int i = 0; i < a_oParams.Length; i++)
        {
            if (a_oParams[i] is int)
            {
                nSumValue += (int)a_oParams[i];
            }
            else
            {
                fSumValue += (float)a_oParams[i];
            }
        }

        return nSumValue;
    }

    private void InitValue(out int a_nValueA, out int a_nValueB)
    {
        a_nValueA = 10;
        a_nValueB = 20;
        // ���� �ʱ�ȭ�� �� ��������, ������ ������ ����.
    }

    // Call By Value
    private void SwapByValue(int a_nLhs, int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;

    }

    // Call By Reference
    private void SwapByReference(ref int a_nLhs, ref int a_nRhs)
    {
        int nTemp = a_nLhs;
        a_nLhs = a_nRhs;
        a_nRhs = nTemp;
    }
#else

    class CWidget
    {
        private int m_nValue = 0;
        private string m_oString = "";

        public int Value
        {

            get
            {
                return m_nValue;
            }

            set
            {
                // value: ���� ���� ���ڰ��� �ǹ��Ѵ�.
                m_nValue = value;
            }
        }

        // ���� ������Ƽ
        // �� �ڵ带 �����ϰ� ���ָ� �����ڿ� ������ ���� ��� ����� �� �� �ִ�.
        // �� �� ������ �� �ǵ��� private �����ڸ� �߰��ϰų� �ʱⰪ�� �ʿ��� ��� �ʱⰪ���� �Ҵ� ����
        public int CNumber
        {
            get; private set;
        } = 100;
        // const���� �������̰� �������� ����.
        // ex) 5���� ��ü�� Cnumber�� �����ϰ� ���� �� 4���� ��ü�� set�� ���ƹ����� ������ ��ü�� private�� Ǯ���� �� �ִ�.

        public string String
        {
            get; set;
        }

        public int GetValue()
        {
            return m_nValue;
        }

        public string GetString()
        {
            return m_oString;
        }

        public void SetValue(int nValue)
        {
            m_nValue = nValue;
        }

        public void SetString(string str)
        {
            m_oString = str;
        }
        // ������Ƽ�� ������� ����ü, Ŭ������ �ʿ��ϴ�.
        // ������Ƽ ȥ�ڸ� ���� �ʱ�

    }
#endif
}
