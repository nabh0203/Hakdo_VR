using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlant : MonoBehaviour
{
    //������ ǥ���� �����ϰ��� ��ź�� �״�� �ݿ��Ǳ⿡, ǥ���� �׻� defalut(1,1,1)�� �����ؾ� �Ѵ�.
    
    //��ź ��ġ ���� ���� - Ȱ��ȭ �� ī��Ʈ�� 
    private bool attached = true;

    private void OnTriggerEnter(Collider other)
    {
        //���� ��ġ ������ Ʈ���ŵǰ�, ��ź�� ��ġ������ ���¸�,
        if (other.gameObject.CompareTag("Bomb") && attached)
        {

            //��ź�� ��ġ������ �θ�� �����.
            transform.parent = other.transform;
            //��ġ���� transform�� null������ ���� 
            transform.parent = null;
            //��ġ���� �ٽü����Ѵ�.
            transform.parent = other.transform;
            //��ź�� ȸ������ �����Ѵ�.
            transform.rotation = Quaternion.identity;
            //��ġ �Ұ����� ���·� ����� - �ߺ� Ʈ���Ű� �Ǿ� BombCount�� �߸��۵��ϴ� ���� �����ϱ� ���� 
            attached = false;
            //��ź �Ŵ����� BombCount �Լ��� ���� ���۽�Ų��. 
            //3�� ���� ���۵Ǹ�, �̺�Ʈ�� �Ͼ���� �����Ͽ���. � �̺�Ʈ�� ��������� BombManager���� ����.
            BombManager.Instance.BombCount();
        }
    }
}
