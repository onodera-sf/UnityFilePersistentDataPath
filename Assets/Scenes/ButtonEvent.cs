using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
	/// <summary>���O���̓t�B�[���h�B</summary>
	[SerializeField] InputField InputFieldName;

	/// <summary>HP ���̓t�B�[���h�B</summary>
	[SerializeField] InputField InputFieldHP;

	/// <summary>�U���͓��̓t�B�[���h�B</summary>
	[SerializeField] InputField InputFieldAttack;

	/// <summary>�������̓t�B�[���h�B</summary>
	[SerializeField] InputField InputFieldMoney;

	/// <summary>�p�X�e�L�X�g�B</summary>
	[SerializeField] Text TextPath;


	/// <summary>�ŏ��Ɉ�x�����Ă΂�܂��B</summary>
	private void Start()
	{
		TextPath.text = Application.persistentDataPath;
	}


	/// <summary>�Z�[�u�f�[�^�B</summary>
	public class SaveData
	{
		public string Name;
		public string HP;
		public string Attack;
		public string Money;
	}

	/// <summary>
	/// �ۑ��{�^�����N���b�N�����Ƃ��̏����B
	/// </summary>
	public void OnClickSave()
	{
		// �ۑ�����f�[�^���쐬
		var data = new SaveData()
		{
			Name = InputFieldName.text,
			HP = InputFieldHP.text,
			Attack = InputFieldAttack.text,
			Money = InputFieldMoney.text,
		};

		// �I�u�W�F�N�g�� JSON ������ɃV���A���C�Y
		var json = JsonUtility.ToJson(data);

		// ����̏ꏊ�Ƀe�L�X�g�t�@�C���Ƃ��ĕۑ�
		File.WriteAllText(Path.Combine(Application.persistentDataPath, "SaveData.txt"), json);

		Debug.Log("�ۑ����܂����B");
	}

	/// <summary>
	/// �ǂݍ��݃{�^�����N���b�N�����Ƃ��̏����B
	/// </summary>
	public void OnClickLoad()
	{
		// �ۑ�����Ă���e�L�X�g�t�@�C����ǂݍ���
		var json = File.ReadAllText(Path.Combine(Application.persistentDataPath, "SaveData.txt"));

		// JSON �e�L�X�g����w�肵���I�u�W�F�N�g�Ƀf�V���A���C�Y
		var data = JsonUtility.FromJson<SaveData>(json);

		// �ǂݍ��񂾒l���e�t�B�[���h�ɃZ�b�g
		InputFieldName.text = data.Name;
		InputFieldHP.text = data.HP;
		InputFieldAttack.text = data.Attack;
		InputFieldMoney.text = data.Money;

		Debug.Log("�ǂݍ��݂܂����B");
	}
}
