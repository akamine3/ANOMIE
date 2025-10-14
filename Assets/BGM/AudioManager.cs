using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    void Awake()
    {
        // ���łɑ��݂���ꍇ�͔j���i�d���h�~�j
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // �C���X�^���X��ێ����A�V�[�����ׂ��ł��j������Ȃ��悤�ɂ���
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}