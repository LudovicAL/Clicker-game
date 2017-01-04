using UnityEngine;
using UnityEngine.UI;

public abstract class Achievement {
	public string name { get; protected set; }
	public string description { get; protected set; }
	public int currentLevel { get; protected set; }
	public double currentValue { get; protected  set; }
	public double[] valuesTable { get; protected  set; }
	public float progress { get; protected  set; }
	public bool revealed { get; protected  set; }
	public GameObject aPanel { get; set; }
	public Image aProgressBar { get; set; }

	public Achievement(string name, string description, bool revealed, double[] valuesTable) {
		this.name = name;
		this.description = description;
		this.currentLevel = 1;
		this.currentValue = 0;
		this.progress = 0.0f;
		this.revealed = revealed;
		this.valuesTable = valuesTable;
	}

	public void OnMouseOver(ToolTip tt) {
		tt.TurnToolTipOn (
			aPanel,
			name,
			currentLevel.ToString() + "/" + valuesTable.Length.ToString(),
			description + " " + progress.ToString("P0")
		);
	}

	public void CalculateCurrentLevel() {
		int i = currentLevel;
		for (; i < valuesTable.Length; i++) {
			if (currentValue < valuesTable[i]) {
				break;
			}
		}
		if (i > currentLevel) {
			currentLevel = i;
			if (PersistentData.achievementsNotifications && !PersistentData.notificationList.Contains(this)) {
				PersistentData.notificationList.Add (this);
			}
		}
	}

	public void CalculateProgress() {
		progress = (currentLevel >= valuesTable.Length) ? 100.0f : (float)(currentValue / valuesTable[currentLevel]);
	}

	public void UpdateProgressBar() {
		aProgressBar.fillAmount = progress;
	}

	public abstract void UpdateAchievement();
}
