using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
	/// <summary>名前入力フィールド。</summary>
	[SerializeField] InputField InputFieldName;

	/// <summary>HP 入力フィールド。</summary>
	[SerializeField] InputField InputFieldHP;

	/// <summary>攻撃力入力フィールド。</summary>
	[SerializeField] InputField InputFieldAttack;

	/// <summary>お金入力フィールド。</summary>
	[SerializeField] InputField InputFieldMoney;

	/// <summary>パステキスト。</summary>
	[SerializeField] Text TextPath;


	/// <summary>最初に一度だけ呼ばれます。</summary>
	private void Start()
	{
		TextPath.text = Application.persistentDataPath;
	}


	/// <summary>セーブデータ。</summary>
	public class SaveData
	{
		public string Name;
		public string HP;
		public string Attack;
		public string Money;
	}

	/// <summary>
	/// 保存ボタンをクリックしたときの処理。
	/// </summary>
	public void OnClickSave()
	{
		// 保存するデータを作成
		var data = new SaveData()
		{
			Name = InputFieldName.text,
			HP = InputFieldHP.text,
			Attack = InputFieldAttack.text,
			Money = InputFieldMoney.text,
		};

		// オブジェクトを JSON 文字列にシリアライズ
		var json = JsonUtility.ToJson(data);

		// 所定の場所にテキストファイルとして保存
		File.WriteAllText(Path.Combine(Application.persistentDataPath, "SaveData.txt"), json);

		Debug.Log("保存しました。");
	}

	/// <summary>
	/// 読み込みボタンをクリックしたときの処理。
	/// </summary>
	public void OnClickLoad()
	{
		// 保存されているテキストファイルを読み込む
		var json = File.ReadAllText(Path.Combine(Application.persistentDataPath, "SaveData.txt"));

		// JSON テキストから指定したオブジェクトにデシリアライズ
		var data = JsonUtility.FromJson<SaveData>(json);

		// 読み込んだ値を各フィールドにセット
		InputFieldName.text = data.Name;
		InputFieldHP.text = data.HP;
		InputFieldAttack.text = data.Attack;
		InputFieldMoney.text = data.Money;

		Debug.Log("読み込みました。");
	}
}
